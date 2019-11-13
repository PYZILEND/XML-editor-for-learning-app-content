using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor.Content
{
    public class Section
    {
        /// <summary>
        /// List of topics
        /// </summary>
        List<Topic> topics;
        /// <summary>
        /// Section's title
        /// </summary>
        string title;
        /// <summary>
        /// Section's id
        /// </summary>
        int id;

        public Section(int id, string title)
        {
            topics = new List<Topic>();
            this.id = id;
            this.title = title;
        }

        /// <summary>
        /// Returns section's title
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return title;
        }

        /// <summary>
        /// Sets section's title
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// Returns section's id
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// Adds topic to section
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        public void AddTopic(int id, string title)
        {
            topics.Add(new Topic(id, title));
        }

        /// <summary>
        /// Adds topic to section
        /// </summary>
        /// <param name="topic"></param>
        public void AddTopic(Topic topic)
        {
            topics.Add(topic);
        }

        /// <summary>
        /// Remoes topic from section
        /// </summary>
        /// <param name="id"></param>
        public void RemoveTopic(int id)
        {
            topics.Remove(GetTopicById(id));
        }

        /// <summary>
        /// Removes topic from section
        /// </summary>
        /// <param name="topic"></param>
        public void RemoveTopic(Topic topic)
        {
            topics.Remove(topic);
        }

        /// <summary>
        /// Returns list of topics
        /// </summary>
        /// <returns></returns>
        public List<Topic> GetTopics()
        {
            return topics;
        }

        /// <summary>
        /// Returns topic specified by it's id
        /// Returns null if topic does not exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Topic GetTopicById(int id)
        {
            foreach(Topic topic in topics)
            {
                if (topic.GetId() == id)
                {
                    return topic;
                }
            }
            return null;
        }
    }
}
