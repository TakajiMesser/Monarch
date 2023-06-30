using Monarch.Shared.Game;

namespace Monarch.ConsoleApplication.Menus.Screens
{
    public abstract class Screen
    {
        protected IGameManager _game;

        public Screen(IGameManager game) => _game = game;

        public IOption AsOption() => new Option(
            Key,
            Description,
            Arguments,
            Action,
            Options);

        protected abstract string Key { get; }
        protected abstract string Description { get; }
        protected virtual string[] Arguments { get; } = Array.Empty<string>();
        protected virtual Action<IList<string>> Action { get; } = (_) => { };
        protected virtual IOption[] Options { get; } = Array.Empty<IOption>();
    }
}
