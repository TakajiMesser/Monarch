using System;
using System.Collections.Generic;

namespace Monarch.ConsoleApplication.Menus
{
    public interface IOption
    {
        string Key { get; }
        string Description { get; }
        IList<string> Arguments { get; }
        Action<IList<string>> Action { get; }
        IList<IOption> Options { get; }

        bool IsMatch(string key);
        IOption? GetMatch(string key);
        void Present();
        void Select(IList<string> arguments);
    }
}
