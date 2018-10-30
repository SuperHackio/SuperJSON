namespace SuperJSON
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.SuperBMDTextBox = new System.Windows.Forms.TextBox();
            this.FindSuperBMDButton = new System.Windows.Forms.Button();
            this.FindInButton = new System.Windows.Forms.Button();
            this.InModelTextBox = new System.Windows.Forms.TextBox();
            this.BDLCheckBox = new System.Windows.Forms.CheckBox();
            this.SuperBMDLabel = new System.Windows.Forms.Label();
            this.InModelLabel = new System.Windows.Forms.Label();
            this.OutModelLabel = new System.Windows.Forms.Label();
            this.FindOutButton = new System.Windows.Forms.Button();
            this.OutModelTextBox = new System.Windows.Forms.TextBox();
            this.FixntCheckBox = new System.Windows.Forms.CheckBox();
            this.TriStripComboBox = new System.Windows.Forms.ComboBox();
            this.TriStripLabel = new System.Windows.Forms.Label();
            this.NoTextureCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.RotateComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SuperBMDTextBox
            // 
            this.SuperBMDTextBox.Enabled = false;
            this.SuperBMDTextBox.Location = new System.Drawing.Point(86, 13);
            this.SuperBMDTextBox.Name = "SuperBMDTextBox";
            this.SuperBMDTextBox.Size = new System.Drawing.Size(142, 20);
            this.SuperBMDTextBox.TabIndex = 0;
            // 
            // FindSuperBMDButton
            // 
            this.FindSuperBMDButton.Location = new System.Drawing.Point(234, 12);
            this.FindSuperBMDButton.Name = "FindSuperBMDButton";
            this.FindSuperBMDButton.Size = new System.Drawing.Size(45, 20);
            this.FindSuperBMDButton.TabIndex = 1;
            this.FindSuperBMDButton.Text = "Open";
            this.FindSuperBMDButton.UseVisualStyleBackColor = true;
            this.FindSuperBMDButton.Click += new System.EventHandler(this.FindSuperBMDButton_Click);
            // 
            // FindInButton
            // 
            this.FindInButton.Enabled = false;
            this.FindInButton.Location = new System.Drawing.Point(234, 38);
            this.FindInButton.Name = "FindInButton";
            this.FindInButton.Size = new System.Drawing.Size(45, 20);
            this.FindInButton.TabIndex = 3;
            this.FindInButton.Text = "Open";
            this.FindInButton.UseVisualStyleBackColor = true;
            this.FindInButton.Click += new System.EventHandler(this.FindInButton_Click);
            // 
            // InModelTextBox
            // 
            this.InModelTextBox.Enabled = false;
            this.InModelTextBox.Location = new System.Drawing.Point(86, 39);
            this.InModelTextBox.Name = "InModelTextBox";
            this.InModelTextBox.Size = new System.Drawing.Size(142, 20);
            this.InModelTextBox.TabIndex = 2;
            this.InModelTextBox.TextChanged += new System.EventHandler(this.InModelTextBox_TextChanged);
            // 
            // BDLCheckBox
            // 
            this.BDLCheckBox.AutoSize = true;
            this.BDLCheckBox.Enabled = false;
            this.BDLCheckBox.Location = new System.Drawing.Point(285, 15);
            this.BDLCheckBox.Name = "BDLCheckBox";
            this.BDLCheckBox.Size = new System.Drawing.Size(80, 17);
            this.BDLCheckBox.TabIndex = 4;
            this.BDLCheckBox.Text = "BDL Export";
            this.BDLCheckBox.UseVisualStyleBackColor = true;
            this.BDLCheckBox.CheckedChanged += new System.EventHandler(this.BDLCheckBox_CheckedChanged);
            // 
            // SuperBMDLabel
            // 
            this.SuperBMDLabel.AutoSize = true;
            this.SuperBMDLabel.Location = new System.Drawing.Point(12, 16);
            this.SuperBMDLabel.Name = "SuperBMDLabel";
            this.SuperBMDLabel.Size = new System.Drawing.Size(62, 13);
            this.SuperBMDLabel.TabIndex = 6;
            this.SuperBMDLabel.Text = "SuperBMD:";
            // 
            // InModelLabel
            // 
            this.InModelLabel.AutoSize = true;
            this.InModelLabel.Location = new System.Drawing.Point(12, 42);
            this.InModelLabel.Name = "InModelLabel";
            this.InModelLabel.Size = new System.Drawing.Size(66, 13);
            this.InModelLabel.TabIndex = 7;
            this.InModelLabel.Text = "Input Model:";
            // 
            // OutModelLabel
            // 
            this.OutModelLabel.AutoSize = true;
            this.OutModelLabel.Location = new System.Drawing.Point(12, 68);
            this.OutModelLabel.Name = "OutModelLabel";
            this.OutModelLabel.Size = new System.Drawing.Size(74, 13);
            this.OutModelLabel.TabIndex = 10;
            this.OutModelLabel.Text = "Output Model:";
            // 
            // FindOutButton
            // 
            this.FindOutButton.Enabled = false;
            this.FindOutButton.Location = new System.Drawing.Point(234, 64);
            this.FindOutButton.Name = "FindOutButton";
            this.FindOutButton.Size = new System.Drawing.Size(45, 20);
            this.FindOutButton.TabIndex = 9;
            this.FindOutButton.Text = "Open";
            this.FindOutButton.UseVisualStyleBackColor = true;
            this.FindOutButton.Click += new System.EventHandler(this.FindOutButton_Click);
            // 
            // OutModelTextBox
            // 
            this.OutModelTextBox.Enabled = false;
            this.OutModelTextBox.Location = new System.Drawing.Point(86, 65);
            this.OutModelTextBox.Name = "OutModelTextBox";
            this.OutModelTextBox.Size = new System.Drawing.Size(142, 20);
            this.OutModelTextBox.TabIndex = 8;
            this.OutModelTextBox.TextChanged += new System.EventHandler(this.OutModelTextBox_TextChanged);
            // 
            // FixntCheckBox
            // 
            this.FixntCheckBox.AutoSize = true;
            this.FixntCheckBox.Enabled = false;
            this.FixntCheckBox.Location = new System.Drawing.Point(285, 67);
            this.FixntCheckBox.Name = "FixntCheckBox";
            this.FixntCheckBox.Size = new System.Drawing.Size(124, 17);
            this.FixntCheckBox.TabIndex = 11;
            this.FixntCheckBox.Text = "Recalculate Normals";
            this.FixntCheckBox.UseVisualStyleBackColor = true;
            this.FixntCheckBox.CheckedChanged += new System.EventHandler(this.FixntCheckBox_CheckedChanged);
            // 
            // TriStripComboBox
            // 
            this.TriStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TriStripComboBox.Enabled = false;
            this.TriStripComboBox.FormattingEnabled = true;
            this.TriStripComboBox.Location = new System.Drawing.Point(86, 91);
            this.TriStripComboBox.Name = "TriStripComboBox";
            this.TriStripComboBox.Size = new System.Drawing.Size(142, 21);
            this.TriStripComboBox.TabIndex = 12;
            this.TriStripComboBox.SelectedIndexChanged += new System.EventHandler(this.TriStripComboBox_SelectedIndexChanged);
            // 
            // TriStripLabel
            // 
            this.TriStripLabel.AutoSize = true;
            this.TriStripLabel.Location = new System.Drawing.Point(12, 94);
            this.TriStripLabel.Name = "TriStripLabel";
            this.TriStripLabel.Size = new System.Drawing.Size(61, 13);
            this.TriStripLabel.TabIndex = 13;
            this.TriStripLabel.Text = "Tristripping:";
            // 
            // NoTextureCheckBox
            // 
            this.NoTextureCheckBox.AutoSize = true;
            this.NoTextureCheckBox.Enabled = false;
            this.NoTextureCheckBox.Location = new System.Drawing.Point(234, 93);
            this.NoTextureCheckBox.Name = "NoTextureCheckBox";
            this.NoTextureCheckBox.Size = new System.Drawing.Size(170, 17);
            this.NoTextureCheckBox.TabIndex = 14;
            this.NoTextureCheckBox.Text = "Disable Texture Header usage";
            this.NoTextureCheckBox.UseVisualStyleBackColor = true;
            this.NoTextureCheckBox.CheckedChanged += new System.EventHandler(this.NoTextureCheckBox_CheckedChanged);
            // 
            // ExportButton
            // 
            this.ExportButton.Enabled = false;
            this.ExportButton.Location = new System.Drawing.Point(15, 118);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(384, 46);
            this.ExportButton.TabIndex = 15;
            this.ExportButton.Text = "Export to SuperBMD";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // RotateComboBox
            // 
            this.RotateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RotateComboBox.Enabled = false;
            this.RotateComboBox.FormattingEnabled = true;
            this.RotateComboBox.Items.AddRange(new object[] {
            "Z Axis up",
            "Y Axis Up"});
            this.RotateComboBox.Location = new System.Drawing.Point(285, 39);
            this.RotateComboBox.Name = "RotateComboBox";
            this.RotateComboBox.Size = new System.Drawing.Size(114, 21);
            this.RotateComboBox.TabIndex = 16;
            this.RotateComboBox.SelectedIndexChanged += new System.EventHandler(this.RotateComboBox_SelectedIndexChanged);
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 176);
            this.Controls.Add(this.RotateComboBox);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.NoTextureCheckBox);
            this.Controls.Add(this.TriStripLabel);
            this.Controls.Add(this.TriStripComboBox);
            this.Controls.Add(this.FixntCheckBox);
            this.Controls.Add(this.OutModelLabel);
            this.Controls.Add(this.FindOutButton);
            this.Controls.Add(this.OutModelTextBox);
            this.Controls.Add(this.InModelLabel);
            this.Controls.Add(this.SuperBMDLabel);
            this.Controls.Add(this.BDLCheckBox);
            this.Controls.Add(this.FindInButton);
            this.Controls.Add(this.InModelTextBox);
            this.Controls.Add(this.FindSuperBMDButton);
            this.Controls.Add(this.SuperBMDTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExportForm";
            this.Text = "SuperJSON - Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SuperBMDTextBox;
        private System.Windows.Forms.Button FindSuperBMDButton;
        private System.Windows.Forms.Button FindInButton;
        private System.Windows.Forms.TextBox InModelTextBox;
        private System.Windows.Forms.CheckBox BDLCheckBox;
        private System.Windows.Forms.Label SuperBMDLabel;
        private System.Windows.Forms.Label InModelLabel;
        private System.Windows.Forms.Label OutModelLabel;
        private System.Windows.Forms.Button FindOutButton;
        private System.Windows.Forms.TextBox OutModelTextBox;
        private System.Windows.Forms.CheckBox FixntCheckBox;
        private System.Windows.Forms.ComboBox TriStripComboBox;
        private System.Windows.Forms.Label TriStripLabel;
        private System.Windows.Forms.CheckBox NoTextureCheckBox;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.ComboBox RotateComboBox;
    }
}