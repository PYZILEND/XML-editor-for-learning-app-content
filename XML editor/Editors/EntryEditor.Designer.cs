namespace XMLEditor.Editors
{
    partial class EntryEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.theoryButton = new System.Windows.Forms.RadioButton();
            this.practiceButton = new System.Windows.Forms.RadioButton();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.answersBox = new System.Windows.Forms.RichTextBox();
            this.answersLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.topicBox = new System.Windows.Forms.ComboBox();
            this.topicLabel = new System.Windows.Forms.Label();
            this.isOpenCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // theoryButton
            // 
            this.theoryButton.AutoSize = true;
            this.theoryButton.Checked = true;
            this.theoryButton.Location = new System.Drawing.Point(12, 12);
            this.theoryButton.Name = "theoryButton";
            this.theoryButton.Size = new System.Drawing.Size(62, 17);
            this.theoryButton.TabIndex = 0;
            this.theoryButton.TabStop = true;
            this.theoryButton.Text = "Теория";
            this.theoryButton.UseVisualStyleBackColor = true;
            this.theoryButton.CheckedChanged += new System.EventHandler(this.theoryButton_CheckedChanged);
            // 
            // practiceButton
            // 
            this.practiceButton.AutoSize = true;
            this.practiceButton.Location = new System.Drawing.Point(12, 35);
            this.practiceButton.Name = "practiceButton";
            this.practiceButton.Size = new System.Drawing.Size(74, 17);
            this.practiceButton.TabIndex = 1;
            this.practiceButton.Text = "Практика";
            this.practiceButton.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 89);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(507, 161);
            this.textBox.TabIndex = 2;
            this.textBox.Text = "";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(15, 533);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(123, 23);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Принять";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(144, 533);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(123, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // typeBox
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Вопрос",
            "Вопрос с вариантами",
            "Вставить пропуски",
            "Восстановить порядок"});
            this.typeBox.Location = new System.Drawing.Point(528, 285);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(121, 21);
            this.typeBox.TabIndex = 5;
            this.typeBox.Visible = false;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(525, 269);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(76, 13);
            this.typeLabel.TabIndex = 6;
            this.typeLabel.Text = "Тип практики";
            this.typeLabel.Visible = false;
            // 
            // answersBox
            // 
            this.answersBox.Location = new System.Drawing.Point(12, 269);
            this.answersBox.Name = "answersBox";
            this.answersBox.Size = new System.Drawing.Size(507, 258);
            this.answersBox.TabIndex = 9;
            this.answersBox.Text = "";
            this.answersBox.Visible = false;
            // 
            // answersLabel
            // 
            this.answersLabel.AutoSize = true;
            this.answersLabel.Location = new System.Drawing.Point(9, 253);
            this.answersLabel.Name = "answersLabel";
            this.answersLabel.Size = new System.Drawing.Size(37, 13);
            this.answersLabel.TabIndex = 10;
            this.answersLabel.Text = "Ответ";
            this.answersLabel.Visible = false;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(12, 73);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(37, 13);
            this.textLabel.TabIndex = 11;
            this.textLabel.Text = "Текст";
            // 
            // topicBox
            // 
            this.topicBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.topicBox.FormattingEnabled = true;
            this.topicBox.Location = new System.Drawing.Point(528, 89);
            this.topicBox.Name = "topicBox";
            this.topicBox.Size = new System.Drawing.Size(121, 21);
            this.topicBox.TabIndex = 12;
            // 
            // topicLabel
            // 
            this.topicLabel.AutoSize = true;
            this.topicLabel.Location = new System.Drawing.Point(525, 73);
            this.topicLabel.Name = "topicLabel";
            this.topicLabel.Size = new System.Drawing.Size(34, 13);
            this.topicLabel.TabIndex = 13;
            this.topicLabel.Text = "Тема";
            // 
            // isOpenCheckbox
            // 
            this.isOpenCheckbox.AutoSize = true;
            this.isOpenCheckbox.Location = new System.Drawing.Point(114, 13);
            this.isOpenCheckbox.Name = "isOpenCheckbox";
            this.isOpenCheckbox.Size = new System.Drawing.Size(132, 17);
            this.isOpenCheckbox.TabIndex = 14;
            this.isOpenCheckbox.Text = "Открыта изначально";
            this.isOpenCheckbox.UseVisualStyleBackColor = true;
            // 
            // EntryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 564);
            this.Controls.Add(this.isOpenCheckbox);
            this.Controls.Add(this.topicLabel);
            this.Controls.Add(this.topicBox);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.answersLabel);
            this.Controls.Add(this.answersBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.practiceButton);
            this.Controls.Add(this.theoryButton);
            this.Name = "EntryEditor";
            this.Text = "EntryEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton theoryButton;
        private System.Windows.Forms.RadioButton practiceButton;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.RichTextBox answersBox;
        private System.Windows.Forms.Label answersLabel;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.ComboBox topicBox;
        private System.Windows.Forms.Label topicLabel;
        private System.Windows.Forms.CheckBox isOpenCheckbox;
    }
}