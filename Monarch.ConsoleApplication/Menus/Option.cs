using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monarch.ConsoleApplication.Menus
{
    public class Option : IOption
    {
        public Option(
            string key,
            string description,
            IList<string> arguments,
            Action<IList<string>> action,
            params IOption[] options)
        {
            Key = key;
            Description = description;
            Arguments = arguments;
            Action = action;
            Options = options;
        }

        public string Key { get; }
        public string Description { get; }
        public IList<string> Arguments { get; }
        public Action<IList<string>> Action { get; }
        public IList<IOption> Options { get; }

        public bool IsMatch(string key) => string.Compare(Key, key, true) == 0;
        public IOption GetMatch(string key) => Options.FirstOrDefault(c => c.IsMatch(key));

        public void Present()
        {
            var builder = new StringBuilder();

            builder.Append(Key + " - " + Description);

            if (Arguments.Count > 0)
            {
                builder.Append('(');

                for (var i = 0; i < Arguments.Count; i++)
                {
                    if (i > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(Arguments[i]);
                }

                builder.Append(')');
            }

            Console.WriteLine(builder.ToString());
        }

        public void Select(IList<string> arguments)
        {
            Console.WriteLine(IMenu.LINE);
            Action(arguments);
            Console.WriteLine(IMenu.LINE);

            foreach (var option in Options)
            {
                option.Present();
            }
        }

        public static Option CreateSimple(
            string key,
            string description,
            Action action) => new(key, description, Array.Empty<string>(), (_) => { action(); }, Array.Empty<IOption>());
    }
}
