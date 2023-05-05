using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Monarch.Shared.Building
{
    public class StructureSet : IEnumerable<Structure>
    {
        private List<Structure> _structures = new List<Structure>();

        public IEnumerator<Structure> GetEnumerator() => _structures.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public int GetMultiplier(string resourceName)
        {
            var multiplier = 100;

            foreach (var structure in _structures)
            {
                if (structure.HasMultiplier(resourceName))
                {
                    multiplier *= structure.GetMultiplier(resourceName);
                }
            }

            return multiplier;
        }

        //public bool CanProduce(Recipe recipe) => string.IsNullOrEmpty(recipe.StructureName) || _structures.Any(s => s.Name == recipe.StructureName);
    }
}
