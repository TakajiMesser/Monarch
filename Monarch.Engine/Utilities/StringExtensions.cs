using System.Linq;

namespace SpiceEngine.Core.Utilities
{
    public static class StringExtensions
    {
        public static string Capitalized(this string value) => value.First().ToString().ToUpper() + value[1..];
    }
}
