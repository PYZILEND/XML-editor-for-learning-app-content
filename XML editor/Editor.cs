using XMLEditor.Editors;
using System;
using System.Windows.Forms;

namespace XMLEditor
{
    public partial class Editor : Form
    {
        /// <summary>
        /// Level types
        /// </summary>
        enum Level { section, topic, entries };
        /// <summary>
        /// Current level of editing, section/topic/entries
        /// </summary>
        private Level currentLevel = Level.section;

        /// <summary>
        /// Selected section
        /// </summary>
        private Content.Section currentSection;
        /// <summary>
        /// Selected topic
        /// </summary>
        private Content.Topic currentTopic;
        
        /// <summary>
        /// Selected entry
        /// </summary>
        private Content.Entry currentEntry;

        /// <summary>
        /// Represents app content being edited
        /// </summary>
        public Content.Content content;

        private string filePath;

        public Editor()
        {
            InitializeComponent();
            content = new Content.Content();
            RefreshGrid();
        }

        /// <summary>
        /// Add new button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            if (currentLevel == Level.section)
            {
                SectionEditor editor = new SectionEditor(this);
                editor.ShowDialog();
            }
            else if (currentLevel == Level.topic)
            {
                TopicEditor editor = new TopicEditor(this, currentSection);
                editor.ShowDialog();
            }
            else
            {
                EntryEditor editor = new EntryEditor(this, currentSection, currentTopic);
                editor.ShowDialog();
            }
        }

        /// <summary>
        /// Edit children of selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                if (currentLevel == Level.section)
                {
                    currentLevel = Level.topic;
                    sectionLabel.Text = currentSection.GetTitle();
                }
                else if (currentLevel == Level.topic)
                {
                    currentLevel = Level.entries;
                    topicLabel.Text = currentTopic.GetTitle();
                    propertiesButton.Visible = false;
                }
                else
                {
                    EntryEditor editor = new EntryEditor(this, currentSection, currentTopic, currentEntry);
                    editor.ShowDialog();
                }
                RefreshGrid();
            }
        }

        /// <summary>
        /// Return to higher level editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upButton_Click(object sender, EventArgs e)
        {
            {
                if (currentLevel == Level.topic)
                {
                    currentLevel = Level.section;
                    sectionLabel.Text = "";
                }
                if (currentLevel == Level.entries)
                {
                    currentLevel = Level.topic;
                    topicLabel.Text = "";
                    propertiesButton.Visible = true;
                }
                RefreshGrid();
            }
        }

        /// <summary>
        /// Delete selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(dataGrid.Rows.Count > 0)
            {
                if(currentLevel == Level.section)
                {
                    content.RemoveSection(currentSection);
                }
                else if (currentLevel == Level.topic)
                {
                    content.RemoveTopic(currentSection, currentTopic);
                }
                else
                {
                    content.RemoveEntry(currentTopic, currentEntry);
                }
                RefreshGrid();
            }
        }

        /// <summary>
        /// Edit selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertiesButton_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                if (currentLevel == Level.section)
                {
                    SectionEditor editor = new SectionEditor(this, currentSection);
                    editor.ShowDialog();
                }
                else if (currentLevel == Level.topic)
                {
                    TopicEditor editor = new TopicEditor(this, currentSection, currentTopic);
                    editor.ShowDialog();
                }                
            }
        }


        /// <summary>
        /// Clears current content and creates new
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createMenuItem_Click(object sender, EventArgs e)
        {
            content = new Content.Content();
            currentSection = null;
            currentTopic = null;
            currentEntry = null;
            currentLevel = Level.section;
            RefreshGrid();
        }

        /// <summary>
        /// Opens existing content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;
            if (filePath != "")
            {
                content = XMLEditor.LoadContent(filePath);
                currentSection = null;
                currentTopic = null;
                currentEntry = null;
                currentLevel = Level.section;
                RefreshGrid();
            }
        }

        /// <summary>
        /// Saves currently opened content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath != "")
            {
                XMLEditor.SaveContent(filePath, content);
            }
        }

        /// <summary>
        /// Saves content to new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            if (filePath != "")
            {
                filePath = saveFileDialog.FileName;
                XMLEditor.SaveContent(filePath, content);
            }
        }

        /// <summary>
        /// Close app menu button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Refreshes data grid
        /// </summary>
        public void RefreshGrid()
        {
            if (currentLevel == Level.section)
            {
                SetupForSections();
                FillForSections();
            }
            else if (currentLevel == Level.topic)
            {
                SetupForTopics();
                FillForTopics();
            }
            else
            {
                SetupForEntries();
                FillForEntries();
            }
            ValidateSelection();
        }

        /// <summary>
        /// Fills grid with sections data
        /// </summary>
        public void FillForSections()
        {
            int i = 0;
            foreach(Content.Section section in content.GetSections())
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells[0].Value = section.GetId();
                dataGrid.Rows[i].Cells[1].Value = section.GetTitle();
                dataGrid.Rows[i].Cells[2].Value = section.IsOpen();
                i++;
            }
        }

        /// <summary>
        /// Fills grid with topics data
        /// </summary>
        public void FillForTopics()
        {
            int i = 0;
            foreach (Content.Topic topic in currentSection.GetTopics())
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells[0].Value = topic.GetId();
                dataGrid.Rows[i].Cells[1].Value = topic.GetTitle();
                dataGrid.Rows[i].Cells[2].Value = topic.IsOpen();
                i++;
            }
        }

        /// <summary>
        /// Fills grid with entries data
        /// </summary>
        public void FillForEntries()
        {          
            int i = 0;
            foreach (Content.Entry entry in currentTopic.GetEntries())
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells[0].Value = entry.GetId();

                if (entry is Content.Theory) 
                {
                    dataGrid.Rows[i].Cells[1].Value = "Теория";
                }
                else
                {
                    dataGrid.Rows[i].Cells[1].Value = "Практика";
                }
                
                dataGrid.Rows[i].Cells[2].Value = entry.GetText();
                dataGrid.Rows[i].Cells[3].Value = entry.IsOpen();
                i++;
            }
        }

        /// <summary>
        /// Sets up data grid for sections level editing
        /// </summary>
        private void SetupForSections()
        {
            dataGrid.Columns.Clear();
            dataGrid.Columns.Add("id", "ID");
            dataGrid.Columns.Add("title", "Название");
            dataGrid.Columns.Add("isOpen", "Открыта изначально");
        }

        /// <summary>
        /// Sets up data grid for topics level editing
        /// </summary>
        private void SetupForTopics()
        {
            dataGrid.Columns.Clear();
            dataGrid.Columns.Add("id", "ID");
            dataGrid.Columns.Add("title", "Название");
            dataGrid.Columns.Add("isOpen", "Открыта изначально");
        }

        /// <summary>
        /// Sets up data grid for entries level editing
        /// </summary>
        private void SetupForEntries()
        {
            dataGrid.Columns.Clear();
            dataGrid.Columns.Add("id", "ID");
            dataGrid.Columns.Add("type", "Тип");
            dataGrid.Columns.Add("text", "Текст");
            dataGrid.Columns.Add("isOpen", "Открыта изначально");
        }

        /// <summary>
        /// Validates selection on grid clicking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ValidateSelection();
        }

        /// <summary>
        /// Validates selected grid item
        /// </summary>
        private void ValidateSelection()
        {
            if (dataGrid.Rows.Count > 0 && dataGrid.CurrentRow.Cells[0].Value != null)
            {
                if (currentLevel == Level.section)
                {
                    currentSection = content.GetSectionById((int)dataGrid.CurrentRow.Cells[0].Value);
                }
                else if (currentLevel == Level.topic)
                {
                    currentTopic = currentSection.GetTopicById((int)dataGrid.CurrentRow.Cells[0].Value);
                }
                else
                {
                    currentEntry = currentTopic.GetEntryById((int)dataGrid.CurrentRow.Cells[0].Value);
                }
            }
        }    
    }
}
