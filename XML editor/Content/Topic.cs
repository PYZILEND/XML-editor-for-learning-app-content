using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor.Content
{
    public class Topic
    {
        List<Entry> entries;
        int id;
        string title;

        public Topic(int id, string title)
        {
            entries = new List<Entry>();
            this.id = id;
            this.title = title;
        }

        public int GetId()
        {
            return id;
        }
        
        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public List<Entry> GetEntries()
        {
            return entries;
        }

        public Entry GetEntryById(int id)
        {
            foreach (Entry entry in entries)
            {
                if(entry.GetId() == id)
                {
                    return entry;
                }
            }
            return null;
        }

        public void AddTheory(int id, string text)
        {
            entries.Add( new Theory(id, text) );
        }

        public void AddChallenge(int id, string text, Challenge.Type type, List<string> answers)
        {
            entries.Add(new Challenge(id, text, type, answers));
        }

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        public void RemoveEntry(Entry entry)
        {
            entries.Remove(entry);
        }
    }
}
