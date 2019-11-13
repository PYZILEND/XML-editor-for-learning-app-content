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
    public partial class SectionEditor : Form
    {
        /// <summary>
        /// Stores id of section under editing
        /// </summary>
        private Content.Section section;
        /// <summary>
        /// Reference to editor form
        /// </summary>
        private Editor editor;

        /// <summary>
        /// Constructor for new section creation
        /// </summary>
        /// <param name="editor"></param>
        public SectionEditor(Editor editor)
        {
            InitializeComponent();
            this.editor = editor;
        }

        /// <summary>
        /// Constructor for section editing
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="id"></param>
        public SectionEditor(Editor editor, Content.Section section)
        {
            InitializeComponent();
            this.editor = editor;
            this.section = section;

            titleBox.Text = section.GetTitle();
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
            if (section != null)
            {
                section.SetTitle(titleBox.Text);
            }
            else
            {
                editor.content.AddSection(titleBox.Text);                
            }
            editor.RefreshGrid();
            Dispose();
        }
    }
}
