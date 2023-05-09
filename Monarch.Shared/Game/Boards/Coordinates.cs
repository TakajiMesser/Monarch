namespace Monarch.Shared.Game.Boards
{
    public struct Coordinates
    {
        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }
    }
}
