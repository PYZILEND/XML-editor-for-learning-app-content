namespace XMLEditor
{
    partial class SectionEditor
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
            this.isOpenCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(21, 128);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Принять";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(152, 128);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(35, 39);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(173, 20);
            this.titleBox.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(32, 23);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(102, 13);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Название раздела";
            // 
            // isOpenCheckbox
            // 
            this.isOpenCheckbox.AutoSize = true;
            this.isOpenCheckbox.Location = new System.Drawing.Point(35, 85);
            this.isOpenCheckbox.Name = "isOpenCheckbox";
            this.isOpenCheckbox.Size = new System.Drawing.Size(126, 17);
            this.isOpenCheckbox.TabIndex = 4;
            this.isOpenCheckbox.Text = "Открыт изначально";
            this.isOpenCheckbox.UseVisualStyleBackColor = true;
            // 
            // SectionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 183);
            this.Controls.Add(this.isOpenCheckbox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Name = "SectionEditor";
            this.Text = "Редактирование раздела";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.CheckBox isOpenCheckbox;
    }
}