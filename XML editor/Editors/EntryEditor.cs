using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLEditor.Editors
{
    public partial class EntryEditor : Form
    {
        private Editor editor;
        private Content.Section section;
        private Content.Topic topic;
        private Content.Entry entry;

        public EntryEditor(Editor editor, Content.Section section, Content.Topic topic)
        {
            InitializeComponent();
            this.editor = editor;
            this.section = section;
            this.topic = topic;
            typeBox.SelectedIndex = 0;
            displayControls();
        }

        public EntryEditor(Editor editor, Content.Section section, Content.Topic topic, Content.Entry entry)
        {
            InitializeComponent();
            this.editor = editor;
            this.section = section;
            this.topic = topic;
            this.entry = entry;

            textBox.Text = entry.GetText();

            if(entry is Content.Challenge)
            {
                typeBox.SelectedIndex = (int)(entry as Content.Challenge).GetChallengeType();
                foreach (string str in (entry as Content.Challenge).GetAnswers())
                {
                    answersBox.Text += str + "\n";
                }
                practiceButton.Checked = true;
            }

            int selection = 0;
            foreach(Content.Topic item in section.GetTopics())
            {
                topicBox.Items.Add(item.GetTitle());
                if(item == topic)
                {
                    selection = topicBox.Items.Count - 1;
                }
            }
            topicBox.SelectedIndex = selection;

            displayControls();
        }

        private void theoryButton_CheckedChanged(object sender, EventArgs e)
        {
            displayControls();               
        }

        private void displayControls()
        {
            if(entry != null)
            {
                topicBox.Visible = true;
                topicLabel.Visible = true;
            }
            else
            {
                topicBox.Visible = false;
                topicLabel.Visible = false;
            }

            if (theoryButton.Checked == true)
            {
                answersBox.Visible = false;
                answersLabel.Visible = false;
                typeBox.Visible = false;
                typeLabel.Visible = false;
            }
            else
            {
                answersBox.Visible = true;
                answersLabel.Visible = true;
                typeBox.Visible = true;
                typeLabel.Visible = true;
                switch (typeBox.SelectedIndex)
                {
                    case 0:
                        {
                            answersLabel.Text = "Ответ";
                            break;
                        }
                    case 1:
                        {
                            answersLabel.Text = "Варианты ответов (первый вариант - правильный ответ, каждый вариант на новой строке)";
                            break;
                        }
                    case 2:
                        {
                            answersLabel.Text = "Пропущенный текст в порядке пропуска, каждый элемент с новой строки, в тексте задания пропуск обозначать как %gap%";
                            break;
                        }
                    case 3:
                        {
                            answersLabel.Text = "Строки (в правильном порядке)";
                            break;
                        }
                    default: break;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if(entry != null)
            {
                entry.SetText(textBox.Text);
                if (practiceButton.Checked == true)
                {
                    (entry as Content.Challenge).SetChallengeType((Content.Challenge.Type)typeBox.SelectedIndex);
                    (entry as Content.Challenge).SetAnswers(new List<string>(answersBox.Text.Split('\n')));
                }
                if(section.GetTopics()[topicBox.SelectedIndex] != topic)
                {
                    editor.content.TransferEntry(topic, section.GetTopics()[topicBox.SelectedIndex], entry);
                }
            }
            else
            {
                if(theoryButton.Checked == true)
                {
                    editor.content.AddTheory(topic, textBox.Text);
                }
                else
                {
                    List<string> answers = new List<string>(answersBox.Text.Split('\n'));
                    editor.content.AddChallenge(topic, textBox.Text, (Content.Challenge.Type)typeBox.SelectedIndex, answers);
                }
            }
            editor.RefreshGrid();
            Dispose();
        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayControls();
        }
    }
}
