using Monarch.Shared.Logs.Entries;
using System;
using System.Collections.Generic;

namespace Monarch.Shared.Logs
{
    public interface ILog
    {
        int EntryCount { get; }

        event EventHandler<LogEntryArgs> EntriesAdded;

        void AddEntry(IEntry entry);
        void AddEntries(IEnumerable<IEntry> entries);
        IEntry GetEntry(int index);
    }
}
