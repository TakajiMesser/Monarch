﻿using System.Collections.Concurrent;

namespace SpiceEngine.Core.Utilities
{
    public static class QueueExtensions
    {
        public static void Clear<T>(this ConcurrentQueue<T> queue)
        {
            while (queue.TryDequeue(out _)) { }
        }
    }
}
