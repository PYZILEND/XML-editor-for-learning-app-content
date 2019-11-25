namespace XMLEditor
{
    partial class TopicEditor
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
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.sectionBox = new System.Windows.Forms.ComboBox();
            this.sectionLabel = new System.Windows.Forms.Label();
            this.isOpenCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(54, 149);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Принять";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(175, 149);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(36, 37);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(100, 20);
            this.titleBox.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(33, 21);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(87, 13);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Название темы";
            // 
            // sectionBox
            // 
            this.sectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionBox.FormattingEnabled = true;
            this.sectionBox.Location = new System.Drawing.Point(172, 36);
            this.sectionBox.Name = "sectionBox";
            this.sectionBox.Size = new System.Drawing.Size(121, 21);
            this.sectionBox.TabIndex = 4;
            // 
            // sectionLabel
            // 
            this.sectionLabel.AutoSize = true;
            this.sectionLabel.Location = new System.Drawing.Point(172, 20);
            this.sectionLabel.Name = "sectionLabel";
            this.sectionLabel.Size = new System.Drawing.Size(44, 13);
            this.sectionLabel.TabIndex = 5;
            this.sectionLabel.Text = "Раздел";
            // 
            // isOpenCheckbox
            // 
            this.isOpenCheckbox.AutoSize = true;
            this.isOpenCheckbox.Location = new System.Drawing.Point(39, 89);
            this.isOpenCheckbox.Name = "isOpenCheckbox";
            this.isOpenCheckbox.Size = new System.Drawing.Size(132, 17);
            this.isOpenCheckbox.TabIndex = 6;
            this.isOpenCheckbox.Text = "Открыта изначально";
            this.isOpenCheckbox.UseVisualStyleBackColor = true;
            // 
            // TopicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 210);
            this.Controls.Add(this.isOpenCheckbox);
            this.Controls.Add(this.sectionLabel);
            this.Controls.Add(this.sectionBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Name = "TopicEditor";
            this.Text = "Редактр тем";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox sectionBox;
        private System.Windows.Forms.Label sectionLabel;
        private System.Windows.Forms.CheckBox isOpenCheckbox;
    }
}