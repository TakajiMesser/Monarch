namespace Monarch.Engine.ECS.Archetypes
{
    public class ArchetypeCollection
    {
        private readonly List<Archetype> _archetypes = new();
        private readonly SortedSet<ArchetypeQuery> _queries = new();
        private ArchetypeQuery _query = new();

        public ArchetypeQuery RegisterQuery(params Type[] componentTypes)
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
        }

        public void RegisterArchetype(Archetype archetype)
        {
            _archetypes.Add(archetype);

            foreach (var query in _queries)
            {
                if (query.IsMatch(archetype))
                {
                    query.Matches.Add(archetype);
                }
            }
        }
    }
}
