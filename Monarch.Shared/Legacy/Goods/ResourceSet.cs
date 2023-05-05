using Monarch.Shared.Building;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Monarch.Shared.Goods
{
    public class ResourceSet : IEnumerable<Resource>
    {
        private Dictionary<string, Resource> _resourceByName = new();

        public Resource this[string name] => _resourceByName[name];

        public IEnumerator<Resource> GetEnumerator() => _resourceByName.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Contains(string name) => _resourceByName.ContainsKey(name);

        public void Add(Resource resource) => _resourceByName.Add(resource.Name, resource);
        public void AddRange(IEnumerable<Resource> resources)
        {
            foreach (var resource in resources)
            {
                Add(resource);
            }
        }

        public bool CanAfford(ICrafter crafter)
        {
            foreach (var resource in crafter.Cost)
            {
                if (!Contains(resource.Name) || this[resource.Name].Amount.Value < resource.Amount.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public T Produce<T>(ICrafter<T> crafter) where T : ICraftable
        {
            foreach (var resource in crafter.Cost)
            {
                this[resource.Name].Amount.Value -= resource.Amount.Value;
            }

            return crafter.Production;
        }

        public bool IsSubsetOf(ResourceSet resources) => this.All(r => resources.Contains(r.Name) && resources[r.Name].Amount.Value > r.Amount.Value);

        public void Subtract(ResourceSet resources)
        {
            foreach (var resource in resources)
            {
                this[resource.Name].Amount.Value -= resource.Amount.Value;
            }
        }
    }
}
