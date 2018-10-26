namespace SuperJSON
{
    partial class SelectTextureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTextureForm));
            this.TextureSettingsComboBox = new System.Windows.Forms.ComboBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.AddTextureSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextureSettingsComboBox
            // 
            this.TextureSettingsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextureSettingsComboBox.FormattingEnabled = true;
            this.TextureSettingsComboBox.Location = new System.Drawing.Point(235, 10);
            this.TextureSettingsComboBox.Name = "TextureSettingsComboBox";
            this.TextureSettingsComboBox.Size = new System.Drawing.Size(115, 21);
            this.TextureSettingsComboBox.TabIndex = 0;
            this.TextureSettingsComboBox.SelectedIndexChanged += new System.EventHandler(this.TextureSettingsComboBox_SelectedIndexChanged);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(13, 13);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(211, 13);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "Select the Texture Setting you want to use:";
            // 
            // AddTextureSettingsButton
            // 
            this.AddTextureSettingsButton.Location = new System.Drawing.Point(16, 37);
            this.AddTextureSettingsButton.Name = "AddTextureSettingsButton";
            this.AddTextureSettingsButton.Size = new System.Drawing.Size(334, 36);
            this.AddTextureSettingsButton.TabIndex = 2;
            this.AddTextureSettingsButton.Text = "Add __________ to project";
            this.AddTextureSettingsButton.UseVisualStyleBackColor = true;
            this.AddTextureSettingsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectTextureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 85);
            this.Controls.Add(this.AddTextureSettingsButton);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.TextureSettingsComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectTextureForm";
            this.Text = "SuperJSON - Settings Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TextureSettingsComboBox;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button AddTextureSettingsButton;
    }
}