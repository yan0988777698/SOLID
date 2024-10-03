using System;
using System.Collections.Generic;
using System.IO;

namespace Single_Responsibility
{
    public class Journal
    {
        private List<string> entries = new List<string>();
        private static int count = 0;
        public List<string> Entries { get { return entries; } set { entries = value; } }
        public static int Count { get { return count; } set { count = value; } }
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
    public class Presistence
    {
        public static void SaveToFile(Journal journal, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, journal.ToString());
            }
        }
        public static Journal Load(string fileName)
        {
            string[] lines = File.ReadAllText(fileName).Split(',');
            var journal = new Journal();
            foreach (var line in lines)
                journal.Entries.Add(line);
            Journal.Count = journal.Entries.Count;
            return journal;
        }
    }
}
