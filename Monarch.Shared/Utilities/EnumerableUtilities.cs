using System.Collections.Generic;

namespace Monarch.Shared.Utilities
{
    public static class EnumerableUtilities
    {
        public static IEnumerable<T> Generate<T>(params T[] items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        public static IEnumerable<T> Yield<T>(this T item)
        {
            if (item != null)
            {
                yield return item;
            }
        }

        public static IEnumerable<T> YieldOrDefault<T>(this T item)
        {
            yield return (item != null) ? item : default;
        }
    }
}
