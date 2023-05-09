namespace Monarch.Shared.Game.Boards
{
    public interface IBoard
    {
        int RowCount { get; }
        int ColumnCount { get; }

        ITile? GetTile(Coordinates coordinates);
    }
}
