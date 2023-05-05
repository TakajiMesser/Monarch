using System;
using System.Collections.Generic;
using System.Linq;

namespace Monarch.ConsoleApplication.Menus
{
    public class Menu : IMenu
    {
        private readonly Stack<IOption> _optionStack = new();
        private IOption _currentOption;
        private bool _isQuitting;

        public Menu(IOption rootOption) => _currentOption = rootOption;

        public void Present()
        {
            string[] arguments = Array.Empty<string>();

            while (!_isQuitting)
            {
                PresentOptions(arguments);
                var input = Console.ReadLine();
                Console.Clear();

                if (input != null)
                {
                    arguments = ParseInput(input);
                }
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
                    _isQuitting = true;
                }
                else
                {
                    var match = _currentOption.GetMatch(inputOption);

                    if (match != null)
                    {
                        if (match.Options.Any())
                        {
                            _optionStack.Push(_currentOption);
                            _currentOption = match;
                        }
                        else
                        {
                            match.Action(inputArguments);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to parse input.");
                        return Array.Empty<string>();
                    }

                    return inputArguments;
                }
            }

            return Array.Empty<string>();
        }
    }
}
