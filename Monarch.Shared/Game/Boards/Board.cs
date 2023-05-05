using System;
using System.Collections.Generic;

namespace Monarch.Shared.Game.Boards
{
    public class Board : IBoard
    {
        private readonly List<Tile> _tiles = new();

        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public ITile GetTile(int rowIndex, int columnIndex) => _tiles[rowIndex * ColumnCount + columnIndex];

        public void SetUp(int nRows, int nColumns, Random randomizer)
        {
            RowCount = nRows;
            ColumnCount = nColumns;

            for (var r = 0; r < nRows; r++)
            {
                for (var c = 0; c < nColumns; c++)
                {
                    // TODO - Somehow randomize biome placement (with a set of rules)
                    var biomeType = (BiomeType)randomizer.Next(Enum.GetNames<BiomeType>().Length);
                    var biomeStrength = randomizer.Next(30, 100);
                    var biome = new Biome(biomeType, biomeStrength);
                    var tile = new Tile(biome);

                    if (r > 0)
                    {
                        var northTile = _tiles[(r - 1) * nColumns + c];

                        tile.North = northTile;
                        northTile.South = tile;
                    }

                    if (c > 0)
                    {
                        var westTile = _tiles[r * nColumns + c - 1];

                        tile.West = westTile;
                        westTile.East = tile;
                    }

                    _tiles.Add(tile);
                }
            }
        }
    }
}
