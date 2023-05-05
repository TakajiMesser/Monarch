using Monarch.Shared.Legacy.Building;
using Monarch.Shared.Legacy.Goods;
using Monarch.Shared.Legacy.Populations;
using Monarch.Shared.Statistics;
using Monarch.Shared.Statistics.Modifiers;
using System;
using System.Collections.Generic;

namespace Monarch.Shared.Legacy.Regions
{
    public class Province
    {
        public Empire Owner { get; }
        public Tile Tile { get; }

        public Population Population { get; }
        public StructureSet Structures { get; } = new();

        public Percentage Security { get; } = new();

        // TODO - Method w/calculation to determine likelihood of rioting/rebellion
    
        public IEnumerable<Resource> GetRawResources()
        {
            if (Owner == null) throw new InvalidOperationException("Cannot extract resources from an unowned province");

            foreach (var biome in Tile.Biomes)
            {
                foreach (var resource in biome.GetResources())
                {
                    var multiplier = Structures.GetMultiplier(resource.Name);
                    resource.Amount.Value *= multiplier;

                    yield return resource;
                }
            }
        }

        public void ApplyStructureModifiers()
        {
            foreach (var structure in Structures)
            {
                foreach (var modifier in structure.Modifiers)
                {
                    var target = GetModifierTarget(modifier);
                    modifier.ApplyTo(target);
                }
            }
        }

        private IModifiable GetModifierTarget(IModifier modifier)
        {
            if (modifier is WageClassModifier)
            {
                return Population.Middle;
            }

            return null;
        }

        public void UpdatePopulation()
        {
            // Update population happiness


            // Update population education


            // Update population religiosity


            // Uses happiness, education, and province security to calculate
            // Check for riot/rebellion


            // Check for celebration


        }
    }
}
