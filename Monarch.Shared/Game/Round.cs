namespace Monarch.Shared.Game
{
    public class Round
    {
        public int Number { get; private set; }
        public int PlayerTurn { get; private set; }

        public void IncrementRound()
        {
            Number++;
            PlayerTurn = 0;
        }

        public void IncrementTurn() => PlayerTurn++;        
    }
}
