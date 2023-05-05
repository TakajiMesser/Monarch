using Monarch.Shared.Logs.Entries;
using System;
using System.Collections.Generic;

namespace Monarch.Shared.Logs
{
    public class Log : ILog
    {
        private readonly List<IEntry> _entries = new();

        public int EntryCount => _entries.Count;

        public event EventHandler<LogEntryArgs> EntriesAdded;

        public void AddEntry(IEntry entry)
        {
            _entries.Add(entry);
            EntriesAdded?.Invoke(this, new LogEntryArgs(EntryCount));
        }

        public void AddEntries(IEnumerable<IEntry> entries)
        {
            _entries.AddRange(entries);
            EntriesAdded?.Invoke(this, new LogEntryArgs(EntryCount));
        }

        public IEntry GetEntry(int index) => _entries[index];
    }
}
