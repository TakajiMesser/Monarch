using System;
using System.Collections.Generic;

namespace SpiceEngine.Core.Utilities
{
    public static class ListExtensions
    {
        public static List<T> Initialize<T>(int size, T defaultValue)
        {
            var list = new List<T>(size);

            for (var i = 0; i < size; i++)
            {
                list[i] = defaultValue;
            }

            return list;
        }

        public static List<T> Initialize<T>(int size) where T : new()
        {
            var list = new List<T>(size);

            for (var i = 0; i < size; i++)
            {
                list[i] = new T();
            }

            return list;
        }

        public static void PadTo<T>(this IList<T> source, T value, int count)
        {
            for (var i = source.Count - 1; i < count; i++)
            {
                source.Add(value);
            }
        }

        public static void Move<T>(this IList<T> source, int oldIndex, int newIndex)
        {
            if (oldIndex < 0 || newIndex < 0) throw new ArgumentOutOfRangeException("Index must be greater than or equal to zero");
            if (oldIndex >= source.Count || newIndex >= source.Count) throw new ArgumentOutOfRangeException("Index must be within item range");

            var item = source[oldIndex];

            source.RemoveAt(oldIndex);
            source.Insert(newIndex, item);
        }
    }
}
