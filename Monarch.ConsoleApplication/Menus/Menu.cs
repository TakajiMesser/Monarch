using System;
using System.Collections.Generic;
using System.Linq;

namespace Monarch.ConsoleApplication.Menus
{
    public class Menu : IMenu
    {
        private IOption _currentOption;
        private readonly Stack<IOption> _optionStack = new();

        public Menu(IOption rootOption) => _currentOption = rootOption;

        public void Present()
        {
            var arguments = Array.Empty<string>();

            while (_currentOption != null)
            {
                PresentOptions(arguments);
                var input = Console.ReadLine();
                Console.Clear();
                arguments = ParseInput(input);
            }
        }

        private void PresentOptions(string[] arguments)
        {
            _currentOption.Select(arguments);

            if (_optionStack.Count > 0)
            {
                Console.WriteLine("B - Back");
            }

            Console.WriteLine("Q - Quit");
            Console.WriteLine(IMenu.LINE);
            Console.WriteLine();
            Console.WriteLine("Please select an option:");
        }

        private string[] ParseInput(string input)
        {
            var splitInput = input.Split(' ');

            if (splitInput.Length == 0)
            {
                Console.WriteLine("Failed to parse input.");
            }
            else
            {
                var inputOption = splitInput[0];
                var inputArguments = splitInput.Skip(1).ToArray();

                if (_optionStack.Count > 0 && (input == "b" || input == "B"))
                {
                    _currentOption = _optionStack.Pop();
                }
                else if (input == "q" || input == "Q")
                {
                    _currentOption = null;
                }
                else
                {
                    var match = _currentOption.GetMatch(inputOption);

                    if (match.Options.Any())
                    {
                        _optionStack.Push(_currentOption);
                        _currentOption = match;
                    }
                    else
                    {
                        match.Action(inputArguments);
                    }

                    return inputArguments;
                }
            }

            return Array.Empty<string>();
        }
    }
}
