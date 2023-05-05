using Monarch.ConsoleApplication.Games;
using Monarch.Shared.Game;
using System;
using System.Collections.Generic;

namespace Monarch.ConsoleApplication.Menus.Screens
{
    public abstract class GameScreen
    {
        protected IGameManager _game;
        protected ILog _log;

        public GameScreen(IGameManager game, ILog log)
        {
            _game = game;
            _log = log;
        }

        public IOption Option { get; protected set; }

        protected void InitializeOption() => Option = new Option(
            Key,
            Description,
            Arguments,
            Action,
            Options);

        protected abstract string Key { get; }
        protected abstract string Description { get; }
        protected virtual string[] Arguments { get; } = Array.Empty<string>();
        protected virtual Action<IList<string>> Action { get; } = null;
        protected virtual IOption[] Options { get; } = Array.Empty<IOption>();
    }
}
