using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor.Content
{
    public class Content
    {
        /// <summary>
        /// List of sections
        /// </summary>
        List<Section> sections;
        
        /// <summary>
        /// Used to give unique IDs to items
        /// </summary>
        int idCount;

        public Content()
        {
            sections = new List<Section>();
            idCount = 0;
        }

        public Content(int idCount)
        {
            sections = new List<Section>();
            this.idCount = idCount;
        }

        /// <summary>
        /// Adds new section to content
        /// </summary>
        /// <param name="title"></param>
        public void AddSection(string title, bool isOpen)
        {
            sections.Add(new Section(idCount, title, isOpen));
            idCount++;
        }

        public void AddSection(Section section)
        {
            sections.Add(section);
        }

        /// <summary>
        /// Removes section from content
        /// </summary>
        /// <param name="id"></param>
        public void RemoveSection(int id)
        {
            sections.Remove(GetSectionById(id));
        }

        public void RemoveSection(Section section)
        {
            sections.Remove(section);
        }

        /// <summary>
        /// Adds new topic to section
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="title"></param>
        public void AddTopic(int sectionId, string title, bool isOpen)
        {
            GetSectionById(sectionId).AddTopic(idCount, title, isOpen);
            idCount++;
        }

        public void AddTopic(Section section, string title, bool isOpen)
        {
            section.AddTopic(idCount, title, isOpen);
            idCount++;
        }

        /// <summary>
        /// Removes topic from section
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="topicId"></param>
        public void RemoveTopic(int sectionId, int topicId)
        {
            GetSectionById(sectionId).RemoveTopic(topicId);
        }

        public void RemoveTopic(Section section, Topic topic)
        {
            section.RemoveTopic(topic);
        }

        /// <summary>
        /// Transfers topic from one section to another
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="sourceId"></param>
        /// <param name="destId"></param>
        public void TransferTopic(int topicId, int sourceId, int destId)
        {
            GetSectionById(destId).AddTopic(GetSectionById(sourceId).GetTopicById(topicId));
            GetSectionById(sourceId).RemoveTopic(topicId);
        }

        /// <summary>
        /// Transfers topic from one section to another
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="sourceId"></param>
        /// <param name="destId"></param>
        public void TransferTopic(Topic topic, Section source, Section dest) 
        {
            dest.AddTopic(topic);
            source.RemoveTopic(topic);
        }

        public void AddTheory(Topic topic, string text, bool isOpen)
        {
            topic.AddTheory(idCount, text, isOpen);
            idCount++;
        }

        public void AddChallenge(Topic topic, string text, bool isOpen, Challenge.Type type, List<string> answers)
        {
            topic.AddChallenge(idCount, text, isOpen, type, answers);
            idCount++;
        }

        public void AddEntry(Topic topic, Theory theory)
        {
            topic.AddEntry(theory);
        }

        public void RemoveEntry(Topic topic, Entry entry)
        {
            topic.RemoveEntry(entry);
        }

        public void TransferEntry(Topic source, Topic dest, Entry entry)
        {
            dest.AddEntry(entry);
            source.RemoveEntry(entry);
        }

        /// <summary>
        /// Returns section object specified by id
        /// If section with said id does not exist returns null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Section GetSectionById(int id)
        {
            foreach(Section section in sections)
            {
                if(section.GetId() == id)
                {
                    return section;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns list of sections
        /// </summary>
        /// <returns></returns>
        public List<Section> GetSections()
        {
            return sections;
        }

        public int getIdCount()
        {
            return idCount;
        }

        public void MoveSection(bool upwards, Section section)
        {
            int sectionIndex = sections.IndexOf(section);
            if (upwards)
            {
                sectionIndex--;
                if(sectionIndex < 0)
                {
                    return;
                }
            }
            else
            {
                sectionIndex++;
                if(sectionIndex >= sections.Count)
                {
                    return;
                }
            }
            sections.Remove(section);
            sections.Insert(sectionIndex, section);
        }                

        public void MoveTopic(bool upwards, Topic topic, Section section)
        {
            List<Topic> topics = section.GetTopics();
            int topicIndex = topics.IndexOf(topic);
            if (upwards)
            {
                topicIndex--;
                if (topicIndex < 0)
                {
                    return;
                }
            }
            else
            {
                topicIndex++;
                if (topicIndex >= topics.Count)
                {
                    return;
                }
            }
            topics.Remove(topic);
            topics.Insert(topicIndex, topic);
        }

        public void MoveEntry(bool upwards, Entry entry, Topic topic)
        {
            List<Entry> entries = topic.GetEntries();
            int entryIndex = entries.IndexOf(entry);
            if (upwards)
            {
                entryIndex--;
                if (entryIndex < 0)
                {
                    return;
                }
            }
            else
            {
                entryIndex++;
                if (entryIndex >= entries.Count)
                {
                    return;
                }
            }
            entries.Remove(entry);
            entries.Insert(entryIndex, entry);
        }
    }
}
