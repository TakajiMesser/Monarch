using Monarch.Shared.Game.Boards;
using Monarch.Shared.Game.Players;
using Monarch.Shared.Game.Players.Actions;
using Monarch.Shared.Game.Setup;
using Monarch.Shared.Logs;

namespace Monarch.Shared.Game
{
    public interface IGameManager
    {
        int TurnIndex { get; }
        int RoundNumber { get; }
        int PlayerCount { get; }

        GameState State { get; }
        RoundPhase Phase { get; }
        ILog Log { get; }
        IBoard Board { get; }

        IPlayer GetPlayer(int index);

        void SetUp(IGameConfig config);
        void Start();
        void TakeAction(IPlayerAction action);
        void EndTurn();
    }

    /**
     * How should game flow work?
     *  Start Turn
     *      Each Player takes action
     *          Units
     *              Move
     *              Perform
     *                  Settle
     *                  Mine/Log Resources
     *                  Diplomacy
     *                  Build Roads
     *                  Attack
     *                  Invade
     *          Settlement
     *              Build Structure
     *      For Human Players, Game waits for input
     *      For AI Players, Game decides actions
     *          We may need to show these actions happening to the player
     *          We can just execute the actions, and then return the user with a sequential log of what happened!
     *  End Turn
     */
}
