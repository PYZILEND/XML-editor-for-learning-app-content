using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLEditor
{
    public partial class TopicEditor : Form
    {
        /// <summary>
        /// Stores id of topic
        /// </summary>
        private Content.Topic topic;
        /// <summary>
        /// Stores topic's section id
        /// </summary>
        private Content.Section section;
        /// <summary>
        /// Stores index of topic's section in combobox
        /// </summary>
        private int sectionIndex;

        /// <summary>
        /// Reference to editor
        /// </summary>
        private Editor editor;

        /// <summary>
        /// Constructor for creating new topic mode
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="sectionId"></param>
        public TopicEditor(Editor editor, Content.Section section)
        {
            InitializeComponent();
            this.editor = editor;
            this.section = section;
            sectionBox.Visible = false;
            sectionLabel.Visible = false;
        }

        /// <summary>
        /// Constructor for editing topic mode
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="sectionId"></param>
        /// <param name="id"></param>
        public TopicEditor(Editor editor, Content.Section section, Content.Topic topic)
        {
            InitializeComponent();
            this.editor = editor;
            this.topic = topic;
            this.section = section;

            titleBox.Text = topic.GetTitle();
            isOpenCheckbox.Checked = topic.IsOpen();

            int i = 0;
            foreach (Content.Section item in editor.content.GetSections())
            {
                sectionBox.Items.Add(item.GetTitle());
                if (item.GetId() == section.GetId())
                {
                    sectionIndex = i;
                }
                i++;
            }
            sectionBox.SelectedIndex = sectionIndex;
        }

        /// <summary>
        /// Discards changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Apply changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applyButton_Click(object sender, EventArgs e)
        {
            if (topic != null)
            {
                topic.SetTitle(titleBox.Text);
                topic.SetOpen(isOpenCheckbox.Checked);
                if (sectionBox.SelectedIndex != sectionIndex)
                {
                    editor.content.TransferTopic(topic, section, editor.content.GetSections()[sectionBox.SelectedIndex]);
                }
            }
            else
            {
                editor.content.AddTopic(section, titleBox.Text, isOpenCheckbox.Checked);                
            }
            editor.RefreshGrid();
            Dispose();
        }
    }
}
