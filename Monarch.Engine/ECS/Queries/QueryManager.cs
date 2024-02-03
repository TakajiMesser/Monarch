using Monarch.Engine.ECS.Archetypes;
using System.Collections;

namespace Monarch.Engine.ECS.Queries
{
    public class QueryManager
    {
        /// <summary>
        /// Processors/Systems expect to be able to query for a set of components.
        /// We will support them specifying required, optional, and restricted component types when they perform this query.
        /// We will require Processors/Systems to "register" their query at initialization, to avoid lookup each frame iteration.
        /// Ultimately, they expect to have an enumeration of a set of components.
        /// 
        /// For efficient queries, we want each query to use a set of BitArrays.
        /// For efficient query caching, we want each query to have a "Signature," which 
        /// </summary>
        private readonly List<BitArray> _archetypeSignatures = new();
        private readonly Dictionary<BitArray, Archetype> _archetypeBySignature = new();
        private readonly Dictionary<QuerySignature, Query> _queryBySignature = new();
        private readonly Dictionary<Type, int> _bitIndexByComponentType = new();

        public void RegisterComponentType<T>()
        {
            var index = _bitIndexByComponentType.Count;
            _bitIndexByComponentType.Add(typeof(T), index);
        }

        public void RegisterArchetype(params Type[] componentTypes)
        {
            var signature = GetBits(componentTypes);
            

            if (!_archetypeBySignature.ContainsKey(signature))
            {
                var archetype = new Archetype(componentTypes, signature, 100);
                _archetypeBySignature.Add(signature, archetype);
            }

            /*foreach (var query in _queries)
            {
                if (query.IsMatch(archetype))
                {
                    query.Matches.Add(archetype);
                }
            }*/
        }

        public QuerySignature RegisterQuery(Query query)
        {
            var signature = GetQuerySignature(query);

            if (!_queryBySignature.ContainsKey(signature))
            {
                _queryBySignature.Add(signature, query);
            }

            return signature;
        }

        /*public ArchetypeQuery RegisterQuery(params Type[] componentTypes)
        {
            _query.ComponentTypes = componentTypes;

            if (!_queries.TryGetValue(_query, out ArchetypeQuery cachedQuery))
            {
                _query.Matches = _archetypes.Where(a => _query.IsMatch(a)).ToList();
                cachedQuery = _query;
                _queries.Add(cachedQuery);
                _query = new();
            }

            return cachedQuery;
        }*/

        public IEnumerable<Archetype> GetArchetypes(QuerySignature signature)
        {
            foreach (var archetypeSignature in _archetypeSignatures)
            {
                //signature.RequiredBits;

                // TODO - Compare archetype signature against query signature
                // If match, lookup archetype and yield return
                var archetype = _archetypeBySignature[archetypeSignature];

                yield return archetype;
            }
        }

        private BitArray GetBits(params Type[] componentTypes)
        {
            var bits = new BitArray(_bitIndexByComponentType.Count);

            foreach (var componentType in componentTypes)
            {
                var bitIndex = _bitIndexByComponentType[componentType];
                bits.Set(bitIndex, true);
            }

            return bits;
        }

        private QuerySignature GetQuerySignature(Query query) => new(
            RequiredBits: GetBits(query.RequiredComponentTypes),
            OptionalBits: GetBits(query.OptionalComponentTypes)
            );
    }
}
