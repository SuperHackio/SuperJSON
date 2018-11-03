namespace SuperJSON
{
    partial class SwapTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwapTableForm));
            this.SwapModeLabel = new System.Windows.Forms.Label();
            this.SwapModeComboBox = new System.Windows.Forms.ComboBox();
            this.SwapModeGroupBox = new System.Windows.Forms.GroupBox();
            this.TexIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RasIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TexLabel = new System.Windows.Forms.Label();
            this.RasLabel = new System.Windows.Forms.Label();
            this.SwapTableGroupBox = new System.Windows.Forms.GroupBox();
            this.ASwapLabel = new System.Windows.Forms.Label();
            this.ASwapComboBox = new System.Windows.Forms.ComboBox();
            this.BSwapComboBox = new System.Windows.Forms.ComboBox();
            this.GSwapComboBox = new System.Windows.Forms.ComboBox();
            this.RSwapComboBox = new System.Windows.Forms.ComboBox();
            this.BSwapLabel = new System.Windows.Forms.Label();
            this.GSwapLabel = new System.Windows.Forms.Label();
            this.RSwapLabel = new System.Windows.Forms.Label();
            this.PreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.SwapTableComboBox = new System.Windows.Forms.ComboBox();
            this.SwapTableLabel = new System.Windows.Forms.Label();
            this.SwapModeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TexIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RasIDNumericUpDown)).BeginInit();
            this.SwapTableGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SwapModeLabel
            // 
            this.SwapModeLabel.AutoSize = true;
            this.SwapModeLabel.Location = new System.Drawing.Point(9, 13);
            this.SwapModeLabel.Name = "SwapModeLabel";
            this.SwapModeLabel.Size = new System.Drawing.Size(67, 13);
            this.SwapModeLabel.TabIndex = 0;
            this.SwapModeLabel.Text = "Swap Mode:";
            // 
            // SwapModeComboBox
            // 
            this.SwapModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SwapModeComboBox.FormattingEnabled = true;
            this.SwapModeComboBox.Location = new System.Drawing.Point(82, 10);
            this.SwapModeComboBox.Name = "SwapModeComboBox";
            this.SwapModeComboBox.Size = new System.Drawing.Size(134, 21);
            this.SwapModeComboBox.TabIndex = 1;
            this.SwapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SwapModeComboBox_SelectedIndexChanged);
            // 
            // SwapModeGroupBox
            // 
            this.SwapModeGroupBox.Controls.Add(this.TexIDNumericUpDown);
            this.SwapModeGroupBox.Controls.Add(this.RasIDNumericUpDown);
            this.SwapModeGroupBox.Controls.Add(this.TexLabel);
            this.SwapModeGroupBox.Controls.Add(this.RasLabel);
            this.SwapModeGroupBox.Location = new System.Drawing.Point(12, 74);
            this.SwapModeGroupBox.Name = "SwapModeGroupBox";
            this.SwapModeGroupBox.Size = new System.Drawing.Size(204, 67);
            this.SwapModeGroupBox.TabIndex = 2;
            this.SwapModeGroupBox.TabStop = false;
            this.SwapModeGroupBox.Text = "Swap Mode";
            // 
            // TexIDNumericUpDown
            // 
            this.TexIDNumericUpDown.Location = new System.Drawing.Point(119, 40);
            this.TexIDNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.TexIDNumericUpDown.Name = "TexIDNumericUpDown";
            this.TexIDNumericUpDown.Size = new System.Drawing.Size(79, 20);
            this.TexIDNumericUpDown.TabIndex = 3;
            // 
            // RasIDNumericUpDown
            // 
            this.RasIDNumericUpDown.Location = new System.Drawing.Point(119, 14);
            this.RasIDNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.RasIDNumericUpDown.Name = "RasIDNumericUpDown";
            this.RasIDNumericUpDown.Size = new System.Drawing.Size(79, 20);
            this.RasIDNumericUpDown.TabIndex = 2;
            // 
            // TexLabel
            // 
            this.TexLabel.AutoSize = true;
            this.TexLabel.Location = new System.Drawing.Point(6, 42);
            this.TexLabel.Name = "TexLabel";
            this.TexLabel.Size = new System.Drawing.Size(106, 13);
            this.TexLabel.TabIndex = 1;
            this.TexLabel.Text = "Texture Swap Table:";
            // 
            // RasLabel
            // 
            this.RasLabel.AutoSize = true;
            this.RasLabel.Location = new System.Drawing.Point(6, 16);
            this.RasLabel.Name = "RasLabel";
            this.RasLabel.Size = new System.Drawing.Size(107, 13);
            this.RasLabel.TabIndex = 0;
            this.RasLabel.Text = "Rasture Swap Table:";
            // 
            // SwapTableGroupBox
            // 
            this.SwapTableGroupBox.Controls.Add(this.ASwapLabel);
            this.SwapTableGroupBox.Controls.Add(this.ASwapComboBox);
            this.SwapTableGroupBox.Controls.Add(this.BSwapComboBox);
            this.SwapTableGroupBox.Controls.Add(this.GSwapComboBox);
            this.SwapTableGroupBox.Controls.Add(this.RSwapComboBox);
            this.SwapTableGroupBox.Controls.Add(this.BSwapLabel);
            this.SwapTableGroupBox.Controls.Add(this.GSwapLabel);
            this.SwapTableGroupBox.Controls.Add(this.RSwapLabel);
            this.SwapTableGroupBox.Location = new System.Drawing.Point(222, 10);
            this.SwapTableGroupBox.Name = "SwapTableGroupBox";
            this.SwapTableGroupBox.Size = new System.Drawing.Size(178, 131);
            this.SwapTableGroupBox.TabIndex = 3;
            this.SwapTableGroupBox.TabStop = false;
            this.SwapTableGroupBox.Text = "Swap Table";
            // 
            // ASwapLabel
            // 
            this.ASwapLabel.AutoSize = true;
            this.ASwapLabel.Location = new System.Drawing.Point(6, 103);
            this.ASwapLabel.Name = "ASwapLabel";
            this.ASwapLabel.Size = new System.Drawing.Size(42, 13);
            this.ASwapLabel.TabIndex = 9;
            this.ASwapLabel.Text = "ALPHA";
            // 
            // ASwapComboBox
            // 
            this.ASwapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ASwapComboBox.FormattingEnabled = true;
            this.ASwapComboBox.Location = new System.Drawing.Point(71, 100);
            this.ASwapComboBox.Name = "ASwapComboBox";
            this.ASwapComboBox.Size = new System.Drawing.Size(101, 21);
            this.ASwapComboBox.TabIndex = 8;
            this.ASwapComboBox.SelectedIndexChanged += new System.EventHandler(this.ASwapComboBox_SelectedIndexChanged);
            // 
            // BSwapComboBox
            // 
            this.BSwapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BSwapComboBox.FormattingEnabled = true;
            this.BSwapComboBox.Location = new System.Drawing.Point(71, 73);
            this.BSwapComboBox.Name = "BSwapComboBox";
            this.BSwapComboBox.Size = new System.Drawing.Size(101, 21);
            this.BSwapComboBox.TabIndex = 7;
            this.BSwapComboBox.SelectedIndexChanged += new System.EventHandler(this.BSwapComboBox_SelectedIndexChanged);
            // 
            // GSwapComboBox
            // 
            this.GSwapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GSwapComboBox.FormattingEnabled = true;
            this.GSwapComboBox.Location = new System.Drawing.Point(71, 46);
            this.GSwapComboBox.Name = "GSwapComboBox";
            this.GSwapComboBox.Size = new System.Drawing.Size(101, 21);
            this.GSwapComboBox.TabIndex = 6;
            this.GSwapComboBox.SelectedIndexChanged += new System.EventHandler(this.GSwapComboBox_SelectedIndexChanged);
            // 
            // RSwapComboBox
            // 
            this.RSwapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RSwapComboBox.FormattingEnabled = true;
            this.RSwapComboBox.Location = new System.Drawing.Point(71, 19);
            this.RSwapComboBox.Name = "RSwapComboBox";
            this.RSwapComboBox.Size = new System.Drawing.Size(101, 21);
            this.RSwapComboBox.TabIndex = 5;
            this.RSwapComboBox.SelectedIndexChanged += new System.EventHandler(this.RSwapComboBox_SelectedIndexChanged);
            // 
            // BSwapLabel
            // 
            this.BSwapLabel.AutoSize = true;
            this.BSwapLabel.Location = new System.Drawing.Point(6, 76);
            this.BSwapLabel.Name = "BSwapLabel";
            this.BSwapLabel.Size = new System.Drawing.Size(38, 13);
            this.BSwapLabel.TabIndex = 2;
            this.BSwapLabel.Text = "BLUE:";
            // 
            // GSwapLabel
            // 
            this.GSwapLabel.AutoSize = true;
            this.GSwapLabel.Location = new System.Drawing.Point(6, 49);
            this.GSwapLabel.Name = "GSwapLabel";
            this.GSwapLabel.Size = new System.Drawing.Size(48, 13);
            this.GSwapLabel.TabIndex = 1;
            this.GSwapLabel.Text = "GREEN:";
            // 
            // RSwapLabel
            // 
            this.RSwapLabel.AutoSize = true;
            this.RSwapLabel.Location = new System.Drawing.Point(6, 22);
            this.RSwapLabel.Name = "RSwapLabel";
            this.RSwapLabel.Size = new System.Drawing.Size(33, 13);
            this.RSwapLabel.TabIndex = 0;
            this.RSwapLabel.Text = "RED:";
            // 
            // PreviewGroupBox
            // 
            this.PreviewGroupBox.Location = new System.Drawing.Point(12, 147);
            this.PreviewGroupBox.Name = "PreviewGroupBox";
            this.PreviewGroupBox.Size = new System.Drawing.Size(388, 167);
            this.PreviewGroupBox.TabIndex = 4;
            this.PreviewGroupBox.TabStop = false;
            this.PreviewGroupBox.Text = "Preview";
            // 
            // SwapTableComboBox
            // 
            this.SwapTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SwapTableComboBox.FormattingEnabled = true;
            this.SwapTableComboBox.Location = new System.Drawing.Point(82, 37);
            this.SwapTableComboBox.Name = "SwapTableComboBox";
            this.SwapTableComboBox.Size = new System.Drawing.Size(134, 21);
            this.SwapTableComboBox.TabIndex = 6;
            this.SwapTableComboBox.SelectedIndexChanged += new System.EventHandler(this.SwapTableComboBox_SelectedIndexChanged);
            // 
            // SwapTableLabel
            // 
            this.SwapTableLabel.AutoSize = true;
            this.SwapTableLabel.Location = new System.Drawing.Point(9, 40);
            this.SwapTableLabel.Name = "SwapTableLabel";
            this.SwapTableLabel.Size = new System.Drawing.Size(67, 13);
            this.SwapTableLabel.TabIndex = 5;
            this.SwapTableLabel.Text = "Swap Table:";
            // 
            // SwapTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 325);
            this.Controls.Add(this.SwapTableComboBox);
            this.Controls.Add(this.SwapTableLabel);
            this.Controls.Add(this.PreviewGroupBox);
            this.Controls.Add(this.SwapTableGroupBox);
            this.Controls.Add(this.SwapModeGroupBox);
            this.Controls.Add(this.SwapModeComboBox);
            this.Controls.Add(this.SwapModeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SwapTableForm";
            this.Text = "SuperJSON - Swap Table Manager";
            this.SwapModeGroupBox.ResumeLayout(false);
            this.SwapModeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TexIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RasIDNumericUpDown)).EndInit();
            this.SwapTableGroupBox.ResumeLayout(false);
            this.SwapTableGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SwapModeLabel;
        private System.Windows.Forms.ComboBox SwapModeComboBox;
        private System.Windows.Forms.GroupBox SwapModeGroupBox;
        private System.Windows.Forms.Label RasLabel;
        private System.Windows.Forms.NumericUpDown TexIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown RasIDNumericUpDown;
        private System.Windows.Forms.Label TexLabel;
        private System.Windows.Forms.GroupBox SwapTableGroupBox;
        private System.Windows.Forms.Label BSwapLabel;
        private System.Windows.Forms.Label GSwapLabel;
        private System.Windows.Forms.Label RSwapLabel;
        private System.Windows.Forms.GroupBox PreviewGroupBox;
        private System.Windows.Forms.Label ASwapLabel;
        private System.Windows.Forms.ComboBox ASwapComboBox;
        private System.Windows.Forms.ComboBox BSwapComboBox;
        private System.Windows.Forms.ComboBox GSwapComboBox;
        private System.Windows.Forms.ComboBox RSwapComboBox;
        private System.Windows.Forms.ComboBox SwapTableComboBox;
        private System.Windows.Forms.Label SwapTableLabel;
    }
}