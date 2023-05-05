using System;

namespace Monarch.Shared.Logs
{
    public class LogEntryArgs : EventArgs
    {
        public LogEntryArgs(int entryCount) => EntryCount = entryCount;

        public int EntryCount { get; }
    }
}
 