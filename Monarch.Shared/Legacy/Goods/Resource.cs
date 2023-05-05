using System;
using Monarch.Shared.Building;
using Monarch.Shared.Statistics;

namespace Monarch.Shared.Goods
{
    public class Resource : ICraftable
    {
        public Resource(string name, int amount = 0)
        {
            Name = name;
            Amount = new Count(amount);
        }

        public string Name { get; }
        public Count Amount { get; set; }
    }
}
