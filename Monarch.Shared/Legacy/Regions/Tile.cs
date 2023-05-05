using Monarch.Shared.Building;
using Monarch.Shared.Game.Boards;
using Monarch.Shared.Goods;
using Monarch.Shared.Populations;
using Monarch.Shared.Statistics;
using Monarch.Shared.Statistics.Modifiers;
using System;
using System.Collections.Generic;

namespace Monarch.Shared.Regions
{
    public class Tile
    {
        public List<Biome> Biomes { get; } = new();
    }
}
