using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLEditor
{
    public static class XMLEditor
    {
        public static Content.Content LoadContent(string path)
        {

            XDocument doc = XDocument.Load(path);

            XElement content = doc.Element("content");

            XElement meta = content.Element("meta");
            XElement idCount = meta.Element("idCount");
            int _idCount = int.Parse(idCount.Value);

            Content.Content _content = new Content.Content(_idCount);

            foreach (XElement section in content.Elements("section"))
            {
                int _sectionId = int.Parse(section.Element("id").Value);
                string _sectionTitle = section.Element("title").Value;
                bool _sectionIsOpen = false;

                if (section.Element("isOpen") != null)
                {
                    _sectionIsOpen = bool.Parse(section.Element("isOpen").Value);
                }

                Content.Section _section = new Content.Section(_sectionId, _sectionTitle, _sectionIsOpen);

                foreach(XElement topic in section.Elements("topic"))
                {
                    int _topicId = int.Parse(topic.Element("id").Value);
                    string _topicTitle = topic.Element("title").Value;
                    bool _topicIsOpen = false;

                    if(topic.Element("isOpen") != null)
                    {
                        _topicIsOpen = bool.Parse(topic.Element("isOpen").Value);
                    }

                    Content.Topic _topic = new Content.Topic(_topicId, _topicTitle, _topicIsOpen);

                    foreach (XElement entry in topic.Elements())
                    {
                        if(entry.Name == "theory" || entry.Name == "challenge")
                        {
                            int _entryId = int.Parse(entry.Element("id").Value);
                            string _entryText = entry.Element("text").Value;
                            bool _entryIsOpen = false;

                            if (entry.Element("isOpen") != null)
                            {
                                _entryIsOpen = bool.Parse(entry.Element("isOpen").Value);
                            }

                            if(entry.Name == "theory")
                            {
                                Content.Theory _theory = new Content.Theory(_entryId, _entryText, _entryIsOpen);

                                _topic.AddEntry(_theory);
                            }
                            else
                            {
                                Content.Challenge.Type _challengeType =
                                    (Content.Challenge.Type) Enum.Parse(typeof(Content.Challenge.Type), entry.Element("type").Value);

                                List<string> _answers = new List<string>();

                                foreach(XElement answer in entry.Element("answers").Elements())
                                {
                                    _answers.Add(answer.Value);
                                }

                                Content.Challenge _challenge = new Content.Challenge(_entryId, _entryText, _entryIsOpen, _challengeType, _answers);

                                _topic.AddEntry(_challenge);
                            }
                        }
                    }

                    _section.AddTopic(_topic);
                }

                _content.AddSection(_section);
            }

            return _content;
        }

        public static void SaveContent(string path, Content.Content _content)
        {
            XDocument doc = new XDocument();

            XElement content = new XElement("content");

            XElement meta = new XElement("meta");
            XElement idCount = new XElement("idCount", _content.getIdCount());
            meta.Add(idCount);
            content.Add(meta);

            foreach(Content.Section _section in _content.GetSections())
            {
                XElement section = new XElement("section");

                XElement sectionId = new XElement("id", _section.GetId());
                section.Add(sectionId);
                XElement sectionTitle = new XElement("title", _section.GetTitle());
                section.Add(sectionTitle);
                XElement sectionIsOpen = new XElement("isOpen", _section.IsOpen());
                section.Add(sectionIsOpen);

                foreach(Content.Topic _topic in _section.GetTopics())
                {
                    XElement topic = new XElement("topic");

                    XElement topicId = new XElement("id", _topic.GetId());
                    topic.Add(topicId);
                    XElement topicTitle = new XElement("title", _topic.GetTitle());
                    topic.Add(topicTitle);
                    XElement topicIsOpen = new XElement("isOpen", _topic.IsOpen());
                    topic.Add(topicIsOpen);

                    foreach(Content.Entry _entry in _topic.GetEntries())
                    {
                        XElement id = new XElement("id", _entry.GetId().ToString());                        
                        XElement text = new XElement("text", _entry.GetText());
                        XElement isOpen = new XElement("isOpen", _entry.IsOpen());

                        if (_entry is Content.Theory)
                        {
                            XElement theory = new XElement("theory");                            

                            theory.Add(id);
                            theory.Add(text);
                            theory.Add(isOpen);

                            topic.Add(theory);
                        }
                        else
                        {
                            XElement challenge = new XElement("challenge");

                            XElement type = new XElement("type", (_entry as Content.Challenge).GetChallengeType().ToString());
                            XElement answers = new XElement("answers");

                            foreach(string str in (_entry as Content.Challenge).GetAnswers())
                            {
                                XElement answer = new XElement("answer", str);
                                answers.Add(answer);
                            }

                            challenge.Add(id);
                            challenge.Add(text);
                            challenge.Add(isOpen);
                            challenge.Add(type);
                            challenge.Add(answers);

                            topic.Add(challenge);
                        }
                    }

                    section.Add(topic);
                }

                content.Add(section);
            }

            doc.Add(content);

            doc.Save(path);
        }
    }
}
