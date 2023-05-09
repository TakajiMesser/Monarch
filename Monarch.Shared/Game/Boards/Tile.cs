using System;

namespace Monarch.Shared.Game.Boards
{
    public class Tile : ITile
    {
        private Tile? _northTile;
        private Tile? _westTile;
        private Tile? _southTile;
        private Tile? _eastTile;

        public Tile(Biome biome) => Biome = biome;

        public Biome Biome { get; }

        public ITile? GetTile(Direction direction) => direction switch
        {
            Direction.North => _northTile,
            Direction.West => _westTile,
            Direction.South => _southTile,
            Direction.East => _eastTile,
            _ => throw new ArgumentOutOfRangeException("Could not handle direction " + direction)
        };

        public void SetTile(Direction direction, Tile tile)
        {
            switch (direction)
            {
                case Direction.North:
                    _northTile = tile;
                    break;
                case Direction.West:
                    _westTile = tile;
                    break;
                case Direction.South:
                    _southTile = tile;
                    break;
                case Direction.East:
                    _eastTile = tile;
                    break;
            }
        }
    }
}
