using System;
using System.Collections.Generic;
using Monarch.Shared.Statistics;
using Monarch.Shared.Statistics.Modifiers;

namespace Monarch.Shared.Building
{
    /// <summary>
    /// Structures can serve a number of uses
    /// - Allow you to build new recipes
    /// - Give you resource multipliers
    /// - Automatically produce resources based on formulas
    /// - Give you stat boosts
    /// - Give you stat setbacks
    /// </summary>
    public class Structure : ICraftable
    {
        private Dictionary<string, int> _multiplierByResourceName = new Dictionary<string, int>();

        public string Name { get; set; }

        public List<Recipe> Recipes { get; }
        public List<Formula> Formulas { get; }
        public List<IModifier> Modifiers { get; }

        public bool HasMultiplier(string resourceName) => _multiplierByResourceName.ContainsKey(resourceName);

        public int GetMultiplier(string resourceName) => _multiplierByResourceName[resourceName];
    }
}
