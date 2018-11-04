namespace SuperJSON
{
    partial class TextureEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureEditForm));
            this.TexNameLabel = new System.Windows.Forms.Label();
            this.TexNameTextBox = new System.Windows.Forms.TextBox();
            this.TexFormLabel = new System.Windows.Forms.Label();
            this.TexFormatComboBox = new System.Windows.Forms.ComboBox();
            this.WrapSComboBox = new System.Windows.Forms.ComboBox();
            this.WrapSLabel = new System.Windows.Forms.Label();
            this.WrapTComboBox = new System.Windows.Forms.ComboBox();
            this.WrapTLabel = new System.Windows.Forms.Label();
            this.MagComboBox = new System.Windows.Forms.ComboBox();
            this.MagLabel = new System.Windows.Forms.Label();
            this.MinComboBox = new System.Windows.Forms.ComboBox();
            this.MinLabel = new System.Windows.Forms.Label();
            this.AlphaLabel = new System.Windows.Forms.Label();
            this.AlphaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LODMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LODMINLabel = new System.Windows.Forms.Label();
            this.LODMagNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LODMAGLabel = new System.Windows.Forms.Label();
            this.LOGBiasNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LODBiasLabel = new System.Windows.Forms.Label();
            this.SwitchLeftButton = new System.Windows.Forms.Button();
            this.SwitchRightButton = new System.Windows.Forms.Button();
            this.OpenTextureButton = new System.Windows.Forms.Button();
            this.AttachPaletteCheckBox = new System.Windows.Forms.CheckBox();
            this.OpenTexHeaderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LODMinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LODMagNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOGBiasNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TexNameLabel
            // 
            this.TexNameLabel.AutoSize = true;
            this.TexNameLabel.Location = new System.Drawing.Point(11, 9);
            this.TexNameLabel.Name = "TexNameLabel";
            this.TexNameLabel.Size = new System.Drawing.Size(77, 13);
            this.TexNameLabel.TabIndex = 2;
            this.TexNameLabel.Text = "Texture Name:";
            // 
            // TexNameTextBox
            // 
            this.TexNameTextBox.Location = new System.Drawing.Point(98, 6);
            this.TexNameTextBox.Name = "TexNameTextBox";
            this.TexNameTextBox.Size = new System.Drawing.Size(110, 20);
            this.TexNameTextBox.TabIndex = 3;
            this.TexNameTextBox.TextChanged += new System.EventHandler(this.TexNameTextBox_TextChanged);
            // 
            // TexFormLabel
            // 
            this.TexFormLabel.AutoSize = true;
            this.TexFormLabel.Location = new System.Drawing.Point(11, 35);
            this.TexFormLabel.Name = "TexFormLabel";
            this.TexFormLabel.Size = new System.Drawing.Size(81, 13);
            this.TexFormLabel.TabIndex = 25;
            this.TexFormLabel.Text = "Texture Format:";
            // 
            // TexFormatComboBox
            // 
            this.TexFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TexFormatComboBox.FormattingEnabled = true;
            this.TexFormatComboBox.Location = new System.Drawing.Point(98, 32);
            this.TexFormatComboBox.Name = "TexFormatComboBox";
            this.TexFormatComboBox.Size = new System.Drawing.Size(110, 21);
            this.TexFormatComboBox.TabIndex = 26;
            this.TexFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.TexFormatComboBox_SelectedIndexChanged);
            this.TexFormatComboBox.MouseHover += new System.EventHandler(this.TexFormatComboBox_MouseHover);
            // 
            // WrapSComboBox
            // 
            this.WrapSComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WrapSComboBox.FormattingEnabled = true;
            this.WrapSComboBox.Location = new System.Drawing.Point(98, 59);
            this.WrapSComboBox.Name = "WrapSComboBox";
            this.WrapSComboBox.Size = new System.Drawing.Size(110, 21);
            this.WrapSComboBox.TabIndex = 28;
            this.WrapSComboBox.MouseHover += new System.EventHandler(this.WrapSComboBox_MouseHover);
            // 
            // WrapSLabel
            // 
            this.WrapSLabel.AutoSize = true;
            this.WrapSLabel.Location = new System.Drawing.Point(11, 62);
            this.WrapSLabel.Name = "WrapSLabel";
            this.WrapSLabel.Size = new System.Drawing.Size(86, 13);
            this.WrapSLabel.TabIndex = 27;
            this.WrapSLabel.Text = "Horizontal Wrap:";
            // 
            // WrapTComboBox
            // 
            this.WrapTComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WrapTComboBox.FormattingEnabled = true;
            this.WrapTComboBox.Location = new System.Drawing.Point(98, 86);
            this.WrapTComboBox.Name = "WrapTComboBox";
            this.WrapTComboBox.Size = new System.Drawing.Size(110, 21);
            this.WrapTComboBox.TabIndex = 30;
            this.WrapTComboBox.MouseHover += new System.EventHandler(this.WrapTComboBox_MouseHover);
            // 
            // WrapTLabel
            // 
            this.WrapTLabel.AutoSize = true;
            this.WrapTLabel.Location = new System.Drawing.Point(11, 89);
            this.WrapTLabel.Name = "WrapTLabel";
            this.WrapTLabel.Size = new System.Drawing.Size(74, 13);
            this.WrapTLabel.TabIndex = 29;
            this.WrapTLabel.Text = "Vertical Wrap:";
            // 
            // MagComboBox
            // 
            this.MagComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MagComboBox.FormattingEnabled = true;
            this.MagComboBox.Location = new System.Drawing.Point(98, 140);
            this.MagComboBox.Name = "MagComboBox";
            this.MagComboBox.Size = new System.Drawing.Size(110, 21);
            this.MagComboBox.TabIndex = 34;
            // 
            // MagLabel
            // 
            this.MagLabel.AutoSize = true;
            this.MagLabel.Location = new System.Drawing.Point(11, 143);
            this.MagLabel.Name = "MagLabel";
            this.MagLabel.Size = new System.Drawing.Size(56, 13);
            this.MagLabel.TabIndex = 33;
            this.MagLabel.Text = "Mag Filter:";
            // 
            // MinComboBox
            // 
            this.MinComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinComboBox.FormattingEnabled = true;
            this.MinComboBox.Location = new System.Drawing.Point(98, 113);
            this.MinComboBox.Name = "MinComboBox";
            this.MinComboBox.Size = new System.Drawing.Size(110, 21);
            this.MinComboBox.TabIndex = 32;
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(11, 116);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(52, 13);
            this.MinLabel.TabIndex = 31;
            this.MinLabel.Text = "Min Filter:";
            // 
            // AlphaLabel
            // 
            this.AlphaLabel.AutoSize = true;
            this.AlphaLabel.Location = new System.Drawing.Point(214, 116);
            this.AlphaLabel.Name = "AlphaLabel";
            this.AlphaLabel.Size = new System.Drawing.Size(73, 13);
            this.AlphaLabel.TabIndex = 35;
            this.AlphaLabel.Text = "Alpha Setting:";
            // 
            // AlphaNumericUpDown
            // 
            this.AlphaNumericUpDown.Location = new System.Drawing.Point(300, 113);
            this.AlphaNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.AlphaNumericUpDown.Name = "AlphaNumericUpDown";
            this.AlphaNumericUpDown.Size = new System.Drawing.Size(112, 20);
            this.AlphaNumericUpDown.TabIndex = 36;
            // 
            // LODMinNumericUpDown
            // 
            this.LODMinNumericUpDown.DecimalPlaces = 1;
            this.LODMinNumericUpDown.Location = new System.Drawing.Point(300, 33);
            this.LODMinNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LODMinNumericUpDown.Name = "LODMinNumericUpDown";
            this.LODMinNumericUpDown.Size = new System.Drawing.Size(112, 20);
            this.LODMinNumericUpDown.TabIndex = 48;
            // 
            // LODMINLabel
            // 
            this.LODMINLabel.AutoSize = true;
            this.LODMINLabel.Location = new System.Drawing.Point(214, 35);
            this.LODMINLabel.Name = "LODMINLabel";
            this.LODMINLabel.Size = new System.Drawing.Size(52, 13);
            this.LODMINLabel.TabIndex = 47;
            this.LODMINLabel.Text = "LOD Min:";
            // 
            // LODMagNumericUpDown
            // 
            this.LODMagNumericUpDown.DecimalPlaces = 1;
            this.LODMagNumericUpDown.Location = new System.Drawing.Point(300, 60);
            this.LODMagNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LODMagNumericUpDown.Name = "LODMagNumericUpDown";
            this.LODMagNumericUpDown.Size = new System.Drawing.Size(112, 20);
            this.LODMagNumericUpDown.TabIndex = 46;
            // 
            // LODMAGLabel
            // 
            this.LODMAGLabel.AutoSize = true;
            this.LODMAGLabel.Location = new System.Drawing.Point(214, 62);
            this.LODMAGLabel.Name = "LODMAGLabel";
            this.LODMAGLabel.Size = new System.Drawing.Size(55, 13);
            this.LODMAGLabel.TabIndex = 45;
            this.LODMAGLabel.Text = "LOD Max:";
            // 
            // LOGBiasNumericUpDown
            // 
            this.LOGBiasNumericUpDown.DecimalPlaces = 1;
            this.LOGBiasNumericUpDown.Location = new System.Drawing.Point(300, 87);
            this.LOGBiasNumericUpDown.Maximum = new decimal(new int[] {
            39,
            0,
            0,
            65536});
            this.LOGBiasNumericUpDown.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147418112});
            this.LOGBiasNumericUpDown.Name = "LOGBiasNumericUpDown";
            this.LOGBiasNumericUpDown.Size = new System.Drawing.Size(112, 20);
            this.LOGBiasNumericUpDown.TabIndex = 44;
            // 
            // LODBiasLabel
            // 
            this.LODBiasLabel.AutoSize = true;
            this.LODBiasLabel.Location = new System.Drawing.Point(214, 89);
            this.LODBiasLabel.Name = "LODBiasLabel";
            this.LODBiasLabel.Size = new System.Drawing.Size(55, 13);
            this.LODBiasLabel.TabIndex = 43;
            this.LODBiasLabel.Text = "LOD Bias:";
            // 
            // SwitchLeftButton
            // 
            this.SwitchLeftButton.BackgroundImage = global::SuperJSON.Properties.Resources.ArrowLeft;
            this.SwitchLeftButton.Location = new System.Drawing.Point(374, 7);
            this.SwitchLeftButton.Name = "SwitchLeftButton";
            this.SwitchLeftButton.Size = new System.Drawing.Size(16, 16);
            this.SwitchLeftButton.TabIndex = 50;
            this.SwitchLeftButton.UseVisualStyleBackColor = true;
            this.SwitchLeftButton.Click += new System.EventHandler(this.SwitchLeftButton_Click);
            // 
            // SwitchRightButton
            // 
            this.SwitchRightButton.BackgroundImage = global::SuperJSON.Properties.Resources.ArrowRight;
            this.SwitchRightButton.Location = new System.Drawing.Point(396, 7);
            this.SwitchRightButton.Name = "SwitchRightButton";
            this.SwitchRightButton.Size = new System.Drawing.Size(16, 16);
            this.SwitchRightButton.TabIndex = 49;
            this.SwitchRightButton.UseVisualStyleBackColor = true;
            this.SwitchRightButton.Click += new System.EventHandler(this.SwitchRightButton_Click);
            // 
            // OpenTextureButton
            // 
            this.OpenTextureButton.BackgroundImage = global::SuperJSON.Properties.Resources.Add;
            this.OpenTextureButton.Location = new System.Drawing.Point(214, 7);
            this.OpenTextureButton.Name = "OpenTextureButton";
            this.OpenTextureButton.Size = new System.Drawing.Size(16, 16);
            this.OpenTextureButton.TabIndex = 24;
            this.OpenTextureButton.UseVisualStyleBackColor = true;
            this.OpenTextureButton.Click += new System.EventHandler(this.OpenTextureButton_Click);
            this.OpenTextureButton.MouseHover += new System.EventHandler(this.OpenTextureButton_MouseHover);
            // 
            // AttachPaletteCheckBox
            // 
            this.AttachPaletteCheckBox.AutoSize = true;
            this.AttachPaletteCheckBox.Location = new System.Drawing.Point(217, 142);
            this.AttachPaletteCheckBox.Name = "AttachPaletteCheckBox";
            this.AttachPaletteCheckBox.Size = new System.Drawing.Size(93, 17);
            this.AttachPaletteCheckBox.TabIndex = 51;
            this.AttachPaletteCheckBox.Text = "Attach Palette";
            this.AttachPaletteCheckBox.UseVisualStyleBackColor = true;
            // 
            // OpenTexHeaderButton
            // 
            this.OpenTexHeaderButton.Location = new System.Drawing.Point(316, 138);
            this.OpenTexHeaderButton.Name = "OpenTexHeaderButton";
            this.OpenTexHeaderButton.Size = new System.Drawing.Size(96, 23);
            this.OpenTexHeaderButton.TabIndex = 52;
            this.OpenTexHeaderButton.Text = "Open JSON";
            this.OpenTexHeaderButton.UseVisualStyleBackColor = true;
            this.OpenTexHeaderButton.Click += new System.EventHandler(this.OpenTexHeaderButton_Click);
            // 
            // TextureEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 170);
            this.Controls.Add(this.OpenTexHeaderButton);
            this.Controls.Add(this.AttachPaletteCheckBox);
            this.Controls.Add(this.SwitchLeftButton);
            this.Controls.Add(this.SwitchRightButton);
            this.Controls.Add(this.LODMinNumericUpDown);
            this.Controls.Add(this.LODMINLabel);
            this.Controls.Add(this.LODMagNumericUpDown);
            this.Controls.Add(this.LODMAGLabel);
            this.Controls.Add(this.LOGBiasNumericUpDown);
            this.Controls.Add(this.LODBiasLabel);
            this.Controls.Add(this.AlphaNumericUpDown);
            this.Controls.Add(this.AlphaLabel);
            this.Controls.Add(this.MagComboBox);
            this.Controls.Add(this.MagLabel);
            this.Controls.Add(this.MinComboBox);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.WrapTComboBox);
            this.Controls.Add(this.WrapTLabel);
            this.Controls.Add(this.WrapSComboBox);
            this.Controls.Add(this.WrapSLabel);
            this.Controls.Add(this.TexFormatComboBox);
            this.Controls.Add(this.TexFormLabel);
            this.Controls.Add(this.OpenTextureButton);
            this.Controls.Add(this.TexNameTextBox);
            this.Controls.Add(this.TexNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TextureEditForm";
            this.Text = "SuperJSON - Texture Settings";
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LODMinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LODMagNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOGBiasNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TexNameLabel;
        private System.Windows.Forms.TextBox TexNameTextBox;
        private System.Windows.Forms.Button OpenTextureButton;
        private System.Windows.Forms.Label TexFormLabel;
        private System.Windows.Forms.ComboBox TexFormatComboBox;
        private System.Windows.Forms.ComboBox WrapSComboBox;
        private System.Windows.Forms.Label WrapSLabel;
        private System.Windows.Forms.ComboBox WrapTComboBox;
        private System.Windows.Forms.Label WrapTLabel;
        private System.Windows.Forms.ComboBox MagComboBox;
        private System.Windows.Forms.Label MagLabel;
        private System.Windows.Forms.ComboBox MinComboBox;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label AlphaLabel;
        private System.Windows.Forms.NumericUpDown AlphaNumericUpDown;
        private System.Windows.Forms.NumericUpDown LODMinNumericUpDown;
        private System.Windows.Forms.Label LODMINLabel;
        private System.Windows.Forms.NumericUpDown LODMagNumericUpDown;
        private System.Windows.Forms.Label LODMAGLabel;
        private System.Windows.Forms.NumericUpDown LOGBiasNumericUpDown;
        private System.Windows.Forms.Label LODBiasLabel;
        private System.Windows.Forms.Button SwitchRightButton;
        private System.Windows.Forms.Button SwitchLeftButton;
        private System.Windows.Forms.CheckBox AttachPaletteCheckBox;
        private System.Windows.Forms.Button OpenTexHeaderButton;
    }
}