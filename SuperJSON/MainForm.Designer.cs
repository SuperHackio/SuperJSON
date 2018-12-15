namespace SuperJSON
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OpenButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MatNameTextBox = new System.Windows.Forms.TextBox();
            this.InfoLabel1 = new System.Windows.Forms.Label();
            this.MatListBox = new System.Windows.Forms.ListBox();
            this.CullLabel = new System.Windows.Forms.Label();
            this.CullComboBox = new System.Windows.Forms.ComboBox();
            this.SaveProgressBar = new System.Windows.Forms.ProgressBar();
            this.SaveTimer = new System.Windows.Forms.Timer(this.components);
            this.SaveCooldownTimer = new System.Windows.Forms.Timer(this.components);
            this.TexListLabel = new System.Windows.Forms.Label();
            this.DitherCheckBox = new System.Windows.Forms.CheckBox();
            this.MatColComboBox = new System.Windows.Forms.ComboBox();
            this.MatColButton = new System.Windows.Forms.Button();
            this.AmbColButton = new System.Windows.Forms.Button();
            this.AmbColComboBox = new System.Windows.Forms.ComboBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.KONSTColButton = new System.Windows.Forms.Button();
            this.KONSTColComboBox = new System.Windows.Forms.ComboBox();
            this.KONSTColLabel = new System.Windows.Forms.Label();
            this.TEVANumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.KONSTNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MatColGroupBox = new System.Windows.Forms.GroupBox();
            this.MatColTextBox = new System.Windows.Forms.TextBox();
            this.AddMatColButton = new System.Windows.Forms.Button();
            this.RemoveMatColButton = new System.Windows.Forms.Button();
            this.AmbColGroupBox = new System.Windows.Forms.GroupBox();
            this.AmbColTextBox = new System.Windows.Forms.TextBox();
            this.AddAmbColButton = new System.Windows.Forms.Button();
            this.RemoveAmbColButton = new System.Windows.Forms.Button();
            this.TEVColGroupBox = new System.Windows.Forms.GroupBox();
            this.TevColLabel = new System.Windows.Forms.Label();
            this.TEVIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TEVRNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TEVGNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TEVBNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.KONSTColTextBox = new System.Windows.Forms.TextBox();
            this.KONSTColGroupBox = new System.Windows.Forms.GroupBox();
            this.Tex8PictureBox = new System.Windows.Forms.PictureBox();
            this.Tex7PictureBox = new System.Windows.Forms.PictureBox();
            this.Tex6PictureBox = new System.Windows.Forms.PictureBox();
            this.Tex5PictureBox = new System.Windows.Forms.PictureBox();
            this.Tex4PictureBox = new System.Windows.Forms.PictureBox();
            this.Tex3PictureBox = new System.Windows.Forms.PictureBox();
            this.Tex2PictureBox = new System.Windows.Forms.PictureBox();
            this.Tex1PictureBox = new System.Windows.Forms.PictureBox();
            this.RemoveMatButton = new System.Windows.Forms.Button();
            this.AddMatButton = new System.Windows.Forms.Button();
            this.IndirectSettingsButton = new System.Windows.Forms.Button();
            this.TEVStagesButton = new System.Windows.Forms.Button();
            this.SwapSettingsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TEVANumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KONSTNumericUpDown)).BeginInit();
            this.MatColGroupBox.SuspendLayout();
            this.AmbColGroupBox.SuspendLayout();
            this.TEVColGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEVIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEVRNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEVGNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEVBNumericUpDown)).BeginInit();
            this.KONSTColGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tex8PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex7PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex6PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex5PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex4PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex3PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex1PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(17, 16);
            this.OpenButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(100, 28);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(127, 16);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 28);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MatNameTextBox
            // 
            this.MatNameTextBox.Enabled = false;
            this.MatNameTextBox.Location = new System.Drawing.Point(16, 390);
            this.MatNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MatNameTextBox.Name = "MatNameTextBox";
            this.MatNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MatNameTextBox.Size = new System.Drawing.Size(159, 22);
            this.MatNameTextBox.TabIndex = 2;
            this.MatNameTextBox.TextChanged += new System.EventHandler(this.MatNameTextBox_TextChanged);
            // 
            // InfoLabel1
            // 
            this.InfoLabel1.AutoSize = true;
            this.InfoLabel1.Location = new System.Drawing.Point(16, 58);
            this.InfoLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InfoLabel1.Name = "InfoLabel1";
            this.InfoLabel1.Size = new System.Drawing.Size(65, 17);
            this.InfoLabel1.TabIndex = 6;
            this.InfoLabel1.Text = "Materials";
            // 
            // MatListBox
            // 
            this.MatListBox.Enabled = false;
            this.MatListBox.FormattingEnabled = true;
            this.MatListBox.ItemHeight = 16;
            this.MatListBox.Location = new System.Drawing.Point(17, 78);
            this.MatListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MatListBox.Name = "MatListBox";
            this.MatListBox.Size = new System.Drawing.Size(159, 308);
            this.MatListBox.TabIndex = 8;
            this.MatListBox.SelectedIndexChanged += new System.EventHandler(this.MatListBox_SelectedIndexChanged);
            // 
            // CullLabel
            // 
            this.CullLabel.AutoSize = true;
            this.CullLabel.Location = new System.Drawing.Point(185, 78);
            this.CullLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CullLabel.Name = "CullLabel";
            this.CullLabel.Size = new System.Drawing.Size(74, 17);
            this.CullLabel.TabIndex = 9;
            this.CullLabel.Text = "Cull Mode:";
            // 
            // CullComboBox
            // 
            this.CullComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CullComboBox.Enabled = false;
            this.CullComboBox.FormattingEnabled = true;
            this.CullComboBox.Items.AddRange(new object[] {
            "None",
            "Front",
            "Back",
            "All"});
            this.CullComboBox.Location = new System.Drawing.Point(269, 74);
            this.CullComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CullComboBox.Name = "CullComboBox";
            this.CullComboBox.Size = new System.Drawing.Size(79, 24);
            this.CullComboBox.TabIndex = 10;
            this.CullComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SaveProgressBar
            // 
            this.SaveProgressBar.Location = new System.Drawing.Point(16, 422);
            this.SaveProgressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveProgressBar.Name = "SaveProgressBar";
            this.SaveProgressBar.Size = new System.Drawing.Size(677, 28);
            this.SaveProgressBar.Step = 1;
            this.SaveProgressBar.TabIndex = 11;
            // 
            // SaveTimer
            // 
            this.SaveTimer.Interval = 10;
            this.SaveTimer.Tick += new System.EventHandler(this.SaveTimer_Tick);
            // 
            // SaveCooldownTimer
            // 
            this.SaveCooldownTimer.Tick += new System.EventHandler(this.SaveCooldownTimer_Tick);
            // 
            // TexListLabel
            // 
            this.TexListLabel.AutoSize = true;
            this.TexListLabel.Location = new System.Drawing.Point(512, 58);
            this.TexListLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TexListLabel.Name = "TexListLabel";
            this.TexListLabel.Size = new System.Drawing.Size(63, 17);
            this.TexListLabel.TabIndex = 13;
            this.TexListLabel.Text = "Textures";
            // 
            // DitherCheckBox
            // 
            this.DitherCheckBox.AutoSize = true;
            this.DitherCheckBox.Enabled = false;
            this.DitherCheckBox.Location = new System.Drawing.Point(357, 76);
            this.DitherCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DitherCheckBox.Name = "DitherCheckBox";
            this.DitherCheckBox.Size = new System.Drawing.Size(68, 21);
            this.DitherCheckBox.TabIndex = 19;
            this.DitherCheckBox.Text = "Dither";
            this.DitherCheckBox.UseVisualStyleBackColor = true;
            // 
            // MatColComboBox
            // 
            this.MatColComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MatColComboBox.Enabled = false;
            this.MatColComboBox.FormattingEnabled = true;
            this.MatColComboBox.Location = new System.Drawing.Point(8, 23);
            this.MatColComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MatColComboBox.Name = "MatColComboBox";
            this.MatColComboBox.Size = new System.Drawing.Size(85, 24);
            this.MatColComboBox.TabIndex = 21;
            this.MatColComboBox.SelectedIndexChanged += new System.EventHandler(this.MatColComboBox_SelectedIndexChanged);
            // 
            // MatColButton
            // 
            this.MatColButton.Enabled = false;
            this.MatColButton.Location = new System.Drawing.Point(103, 23);
            this.MatColButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MatColButton.Name = "MatColButton";
            this.MatColButton.Size = new System.Drawing.Size(28, 26);
            this.MatColButton.TabIndex = 22;
            this.MatColButton.UseVisualStyleBackColor = true;
            this.MatColButton.Click += new System.EventHandler(this.MatColButton_Click);
            // 
            // AmbColButton
            // 
            this.AmbColButton.Enabled = false;
            this.AmbColButton.Location = new System.Drawing.Point(103, 23);
            this.AmbColButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AmbColButton.Name = "AmbColButton";
            this.AmbColButton.Size = new System.Drawing.Size(28, 26);
            this.AmbColButton.TabIndex = 27;
            this.AmbColButton.UseVisualStyleBackColor = true;
            this.AmbColButton.Click += new System.EventHandler(this.AmbColButton_Click);
            // 
            // AmbColComboBox
            // 
            this.AmbColComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AmbColComboBox.Enabled = false;
            this.AmbColComboBox.FormattingEnabled = true;
            this.AmbColComboBox.Location = new System.Drawing.Point(8, 23);
            this.AmbColComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AmbColComboBox.Name = "AmbColComboBox";
            this.AmbColComboBox.Size = new System.Drawing.Size(85, 24);
            this.AmbColComboBox.TabIndex = 26;
            this.AmbColComboBox.SelectedIndexChanged += new System.EventHandler(this.AmbColComboBox_SelectedIndexChanged);
            // 
            // ExportButton
            // 
            this.ExportButton.Enabled = false;
            this.ExportButton.Location = new System.Drawing.Point(235, 15);
            this.ExportButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(100, 28);
            this.ExportButton.TabIndex = 31;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // KONSTColButton
            // 
            this.KONSTColButton.Enabled = false;
            this.KONSTColButton.Location = new System.Drawing.Point(103, 23);
            this.KONSTColButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KONSTColButton.Name = "KONSTColButton";
            this.KONSTColButton.Size = new System.Drawing.Size(28, 26);
            this.KONSTColButton.TabIndex = 45;
            this.KONSTColButton.UseVisualStyleBackColor = true;
            this.KONSTColButton.Click += new System.EventHandler(this.KONSTColButton_Click);
            // 
            // KONSTColComboBox
            // 
            this.KONSTColComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KONSTColComboBox.Enabled = false;
            this.KONSTColComboBox.FormattingEnabled = true;
            this.KONSTColComboBox.Items.AddRange(new object[] {
            "Colour 0",
            "Colour 1",
            "Colour 2",
            "Colour 3"});
            this.KONSTColComboBox.Location = new System.Drawing.Point(8, 23);
            this.KONSTColComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KONSTColComboBox.Name = "KONSTColComboBox";
            this.KONSTColComboBox.Size = new System.Drawing.Size(85, 24);
            this.KONSTColComboBox.TabIndex = 44;
            this.KONSTColComboBox.SelectedIndexChanged += new System.EventHandler(this.KONSTColComboBox_SelectedIndexChanged);
            // 
            // KONSTColLabel
            // 
            this.KONSTColLabel.AutoSize = true;
            this.KONSTColLabel.Location = new System.Drawing.Point(185, 382);
            this.KONSTColLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.KONSTColLabel.Name = "KONSTColLabel";
            this.KONSTColLabel.Size = new System.Drawing.Size(12, 17);
            this.KONSTColLabel.TabIndex = 43;
            this.KONSTColLabel.Text = ":";
            // 
            // TEVANumericUpDown
            // 
            this.TEVANumericUpDown.Enabled = false;
            this.TEVANumericUpDown.Location = new System.Drawing.Point(239, 39);
            this.TEVANumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TEVANumericUpDown.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.TEVANumericUpDown.Minimum = new decimal(new int[] {
            10240,
            0,
            0,
            -2147418112});
            this.TEVANumericUpDown.Name = "TEVANumericUpDown";
            this.TEVANumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.TEVANumericUpDown.TabIndex = 46;
            this.TEVANumericUpDown.Value = new decimal(new int[] {
            203,
            0,
            0,
            0});
            this.TEVANumericUpDown.ValueChanged += new System.EventHandler(this.TEVANumericUpDown_ValueChanged);
            // 
            // KONSTNumericUpDown
            // 
            this.KONSTNumericUpDown.Enabled = false;
            this.KONSTNumericUpDown.Location = new System.Drawing.Point(139, 25);
            this.KONSTNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KONSTNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.KONSTNumericUpDown.Name = "KONSTNumericUpDown";
            this.KONSTNumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.KONSTNumericUpDown.TabIndex = 47;
            this.KONSTNumericUpDown.ValueChanged += new System.EventHandler(this.KONSTNumericUpDown_ValueChanged);
            // 
            // MatColGroupBox
            // 
            this.MatColGroupBox.Controls.Add(this.MatColTextBox);
            this.MatColGroupBox.Controls.Add(this.MatColComboBox);
            this.MatColGroupBox.Controls.Add(this.MatColButton);
            this.MatColGroupBox.Controls.Add(this.AddMatColButton);
            this.MatColGroupBox.Controls.Add(this.RemoveMatColButton);
            this.MatColGroupBox.Location = new System.Drawing.Point(189, 107);
            this.MatColGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MatColGroupBox.Name = "MatColGroupBox";
            this.MatColGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MatColGroupBox.Size = new System.Drawing.Size(299, 63);
            this.MatColGroupBox.TabIndex = 48;
            this.MatColGroupBox.TabStop = false;
            this.MatColGroupBox.Text = "Material Colours";
            // 
            // MatColTextBox
            // 
            this.MatColTextBox.Enabled = false;
            this.MatColTextBox.Location = new System.Drawing.Point(197, 23);
            this.MatColTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MatColTextBox.MaxLength = 8;
            this.MatColTextBox.Name = "MatColTextBox";
            this.MatColTextBox.Size = new System.Drawing.Size(92, 22);
            this.MatColTextBox.TabIndex = 25;
            this.MatColTextBox.Text = "RRGGBBAA";
            this.MatColTextBox.TextChanged += new System.EventHandler(this.MatColTextBox_TextChanged);
            // 
            // AddMatColButton
            // 
            this.AddMatColButton.BackgroundImage = global::SuperJSON.Properties.Resources.Add;
            this.AddMatColButton.Enabled = false;
            this.AddMatColButton.Location = new System.Drawing.Point(139, 26);
            this.AddMatColButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddMatColButton.Name = "AddMatColButton";
            this.AddMatColButton.Size = new System.Drawing.Size(21, 20);
            this.AddMatColButton.TabIndex = 23;
            this.AddMatColButton.UseVisualStyleBackColor = true;
            this.AddMatColButton.Click += new System.EventHandler(this.AddMatColButton_Click);
            // 
            // RemoveMatColButton
            // 
            this.RemoveMatColButton.BackgroundImage = global::SuperJSON.Properties.Resources.Remove;
            this.RemoveMatColButton.Enabled = false;
            this.RemoveMatColButton.Location = new System.Drawing.Point(168, 26);
            this.RemoveMatColButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RemoveMatColButton.Name = "RemoveMatColButton";
            this.RemoveMatColButton.Size = new System.Drawing.Size(21, 20);
            this.RemoveMatColButton.TabIndex = 24;
            this.RemoveMatColButton.UseVisualStyleBackColor = true;
            this.RemoveMatColButton.Click += new System.EventHandler(this.RemoveMatColButton_Click);
            // 
            // AmbColGroupBox
            // 
            this.AmbColGroupBox.Controls.Add(this.AmbColTextBox);
            this.AmbColGroupBox.Controls.Add(this.AmbColComboBox);
            this.AmbColGroupBox.Controls.Add(this.AmbColButton);
            this.AmbColGroupBox.Controls.Add(this.AddAmbColButton);
            this.AmbColGroupBox.Controls.Add(this.RemoveAmbColButton);
            this.AmbColGroupBox.Location = new System.Drawing.Point(189, 177);
            this.AmbColGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AmbColGroupBox.Name = "AmbColGroupBox";
            this.AmbColGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AmbColGroupBox.Size = new System.Drawing.Size(299, 65);
            this.AmbColGroupBox.TabIndex = 49;
            this.AmbColGroupBox.TabStop = false;
            this.AmbColGroupBox.Text = "Ambient Colours";
            // 
            // AmbColTextBox
            // 
            this.AmbColTextBox.Enabled = false;
            this.AmbColTextBox.Location = new System.Drawing.Point(197, 23);
            this.AmbColTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AmbColTextBox.MaxLength = 8;
            this.AmbColTextBox.Name = "AmbColTextBox";
            this.AmbColTextBox.Size = new System.Drawing.Size(92, 22);
            this.AmbColTextBox.TabIndex = 26;
            this.AmbColTextBox.Text = "RRGGBBAA";
            this.AmbColTextBox.TextChanged += new System.EventHandler(this.AmbColTextBox_TextChanged);
            // 
            // AddAmbColButton
            // 
            this.AddAmbColButton.BackgroundImage = global::SuperJSON.Properties.Resources.Add;
            this.AddAmbColButton.Enabled = false;
            this.AddAmbColButton.Location = new System.Drawing.Point(139, 26);
            this.AddAmbColButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddAmbColButton.Name = "AddAmbColButton";
            this.AddAmbColButton.Size = new System.Drawing.Size(21, 20);
            this.AddAmbColButton.TabIndex = 28;
            this.AddAmbColButton.UseVisualStyleBackColor = true;
            this.AddAmbColButton.Click += new System.EventHandler(this.AddAmbColButton_Click);
            // 
            // RemoveAmbColButton
            // 
            this.RemoveAmbColButton.BackgroundImage = global::SuperJSON.Properties.Resources.Remove;
            this.RemoveAmbColButton.Enabled = false;
            this.RemoveAmbColButton.Location = new System.Drawing.Point(168, 26);
            this.RemoveAmbColButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RemoveAmbColButton.Name = "RemoveAmbColButton";
            this.RemoveAmbColButton.Size = new System.Drawing.Size(21, 20);
            this.RemoveAmbColButton.TabIndex = 29;
            this.RemoveAmbColButton.UseVisualStyleBackColor = true;
            this.RemoveAmbColButton.Click += new System.EventHandler(this.RemoveAmbColButton_Click);
            // 
            // TEVColGroupBox
            // 
            this.TEVColGroupBox.Controls.Add(this.TevColLabel);
            this.TEVColGroupBox.Controls.Add(this.TEVIDNumericUpDown);
            this.TEVColGroupBox.Controls.Add(this.TEVRNumericUpDown);
            this.TEVColGroupBox.Controls.Add(this.TEVGNumericUpDown);
            this.TEVColGroupBox.Controls.Add(this.TEVBNumericUpDown);
            this.TEVColGroupBox.Controls.Add(this.TEVANumericUpDown);
            this.TEVColGroupBox.Location = new System.Drawing.Point(189, 250);
            this.TEVColGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TEVColGroupBox.Name = "TEVColGroupBox";
            this.TEVColGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TEVColGroupBox.Size = new System.Drawing.Size(299, 79);
            this.TEVColGroupBox.TabIndex = 50;
            this.TEVColGroupBox.TabStop = false;
            this.TEVColGroupBox.Text = "TEV Colours";
            // 
            // TevColLabel
            // 
            this.TevColLabel.AutoSize = true;
            this.TevColLabel.Location = new System.Drawing.Point(8, 20);
            this.TevColLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TevColLabel.Name = "TevColLabel";
            this.TevColLabel.Size = new System.Drawing.Size(272, 17);
            this.TevColLabel.TabIndex = 51;
            this.TevColLabel.Text = "  ID      RED       GREEN    BLUE    ALPHA";
            // 
            // TEVIDNumericUpDown
            // 
            this.TEVIDNumericUpDown.Enabled = false;
            this.TEVIDNumericUpDown.Location = new System.Drawing.Point(7, 39);
            this.TEVIDNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TEVIDNumericUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.TEVIDNumericUpDown.Name = "TEVIDNumericUpDown";
            this.TEVIDNumericUpDown.Size = new System.Drawing.Size(37, 22);
            this.TEVIDNumericUpDown.TabIndex = 50;
            this.TEVIDNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.TEVIDNumericUpDown.ValueChanged += new System.EventHandler(this.TEVIDNumericUpDown_ValueChanged);
            // 
            // TEVRNumericUpDown
            // 
            this.TEVRNumericUpDown.Enabled = false;
            this.TEVRNumericUpDown.Location = new System.Drawing.Point(52, 39);
            this.TEVRNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TEVRNumericUpDown.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.TEVRNumericUpDown.Minimum = new decimal(new int[] {
            10240,
            0,
            0,
            -2147418112});
            this.TEVRNumericUpDown.Name = "TEVRNumericUpDown";
            this.TEVRNumericUpDown.Size = new System.Drawing.Size(55, 22);
            this.TEVRNumericUpDown.TabIndex = 49;
            this.TEVRNumericUpDown.Value = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.TEVRNumericUpDown.ValueChanged += new System.EventHandler(this.TEVRNumericUpDown_ValueChanged);
            // 
            // TEVGNumericUpDown
            // 
            this.TEVGNumericUpDown.Enabled = false;
            this.TEVGNumericUpDown.Location = new System.Drawing.Point(115, 39);
            this.TEVGNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TEVGNumericUpDown.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.TEVGNumericUpDown.Minimum = new decimal(new int[] {
            10240,
            0,
            0,
            -2147418112});
            this.TEVGNumericUpDown.Name = "TEVGNumericUpDown";
            this.TEVGNumericUpDown.Size = new System.Drawing.Size(55, 22);
            this.TEVGNumericUpDown.TabIndex = 48;
            this.TEVGNumericUpDown.Value = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.TEVGNumericUpDown.ValueChanged += new System.EventHandler(this.TEVGNumericUpDown_ValueChanged);
            // 
            // TEVBNumericUpDown
            // 
            this.TEVBNumericUpDown.Enabled = false;
            this.TEVBNumericUpDown.Location = new System.Drawing.Point(177, 39);
            this.TEVBNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TEVBNumericUpDown.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.TEVBNumericUpDown.Minimum = new decimal(new int[] {
            10240,
            0,
            0,
            -2147418112});
            this.TEVBNumericUpDown.Name = "TEVBNumericUpDown";
            this.TEVBNumericUpDown.Size = new System.Drawing.Size(53, 22);
            this.TEVBNumericUpDown.TabIndex = 47;
            this.TEVBNumericUpDown.Value = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.TEVBNumericUpDown.ValueChanged += new System.EventHandler(this.TEVBNumericUpDown_ValueChanged);
            // 
            // KONSTColTextBox
            // 
            this.KONSTColTextBox.Enabled = false;
            this.KONSTColTextBox.Location = new System.Drawing.Point(197, 25);
            this.KONSTColTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KONSTColTextBox.MaxLength = 8;
            this.KONSTColTextBox.Name = "KONSTColTextBox";
            this.KONSTColTextBox.Size = new System.Drawing.Size(92, 22);
            this.KONSTColTextBox.TabIndex = 47;
            this.KONSTColTextBox.Text = "RRGGBBAA";
            this.KONSTColTextBox.TextChanged += new System.EventHandler(this.KONSTColTextBox_TextChanged);
            // 
            // KONSTColGroupBox
            // 
            this.KONSTColGroupBox.Controls.Add(this.KONSTColTextBox);
            this.KONSTColGroupBox.Controls.Add(this.KONSTColComboBox);
            this.KONSTColGroupBox.Controls.Add(this.KONSTNumericUpDown);
            this.KONSTColGroupBox.Controls.Add(this.KONSTColButton);
            this.KONSTColGroupBox.Location = new System.Drawing.Point(189, 336);
            this.KONSTColGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KONSTColGroupBox.Name = "KONSTColGroupBox";
            this.KONSTColGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KONSTColGroupBox.Size = new System.Drawing.Size(299, 66);
            this.KONSTColGroupBox.TabIndex = 51;
            this.KONSTColGroupBox.TabStop = false;
            this.KONSTColGroupBox.Text = "KONST Colours";
            // 
            // Tex8PictureBox
            // 
            this.Tex8PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tex8PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tex8PictureBox.Enabled = false;
            this.Tex8PictureBox.Location = new System.Drawing.Point(609, 336);
            this.Tex8PictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tex8PictureBox.Name = "Tex8PictureBox";
            this.Tex8PictureBox.Size = new System.Drawing.Size(84, 78);
            this.Tex8PictureBox.TabIndex = 39;
            this.Tex8PictureBox.TabStop = false;
            this.Tex8PictureBox.Click += new System.EventHandler(this.Tex8PictureBox_Click);
            this.Tex8PictureBox.MouseHover += new System.EventHandler(this.Tex8PictureBox_MouseHover);
            // 
            // Tex7PictureBox
            // 
            this.Tex7PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tex7PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tex7PictureBox.Enabled = false;
            this.Tex7PictureBox.Location = new System.Drawing.Point(516, 336);
            this.Tex7PictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tex7PictureBox.Name = "Tex7PictureBox";
            this.Tex7PictureBox.Size = new System.Drawing.Size(84, 78);
            this.Tex7PictureBox.TabIndex = 38;
            this.Tex7PictureBox.TabStop = false;
            this.Tex7PictureBox.Click += new System.EventHandler(this.Tex7PictureBox_Click);
            this.Tex7PictureBox.MouseHover += new System.EventHandler(this.Tex7PictureBox_MouseHover);
            // 
            // Tex6PictureBox
            // 
            this.Tex6PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tex6PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tex6PictureBox.Enabled = false;
            this.Tex6PictureBox.Location = new System.Drawing.Point(609, 250);
            this.Tex6PictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tex6PictureBox.Name = "Tex6PictureBox";
            this.Tex6PictureBox.Size = new System.Drawing.Size(84, 78);
            this.Tex6PictureBox.TabIndex = 37;
            this.Tex6PictureBox.TabStop = false;
            this.Tex6PictureBox.Click += new System.EventHandler(this.Tex6PictureBox_Click);
            this.Tex6PictureBox.MouseHover += new System.EventHandler(this.Tex6PictureBox_MouseHover);
            // 
            // Tex5PictureBox
            // 
            this.Tex5PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tex5PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tex5PictureBox.Enabled = false;
            this.Tex5PictureBox.Location = new System.Drawing.Point(516, 250);
            this.Tex5PictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tex5PictureBox.Name = "Tex5PictureBox";
            this.Tex5PictureBox.Size = new System.Drawing.Size(84, 78);
            this.Tex5PictureBox.TabIndex = 36;
            this.Tex5PictureBox.TabStop = false;
            this.Tex5PictureBox.Click += new System.EventHandler(this.Tex5PictureBox_Click);
            this.Tex5PictureBox.MouseHover += new System.EventHandler(this.Tex5PictureBox_MouseHover);
            // 
            // Tex4PictureBox
            // 
            this.Tex4PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tex4PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tex4PictureBox.Enabled = false;
            this.Tex4PictureBox.Location = new System.Drawing.Point(609, 164);
            this.Tex4PictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tex4PictureBox.Name = "Tex4PictureBox";
            this.Tex4PictureBox.Size = new System.Drawing.Size(84, 78);
            this.Tex4PictureBox.TabIndex = 35;
            this.Tex4PictureBox.TabStop = false;
            this.Tex4PictureBox.Click += new System.EventHandler(this.Tex4PictureBox_Click);
            this.Tex4PictureBox.MouseHover += new System.EventHandler(this.Tex4PictureBox_MouseHover);
            // 
            // Tex3PictureBox
            // 
            this.Tex3PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tex3PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tex3PictureBox.Enabled = false;
            this.Tex3PictureBox.Location = new System.Drawing.Point(516, 164);
            this.Tex3PictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tex3PictureBox.Name = "Tex3PictureBox";
            this.Tex3PictureBox.Size = new System.Drawing.Size(84, 78);
            this.Tex3PictureBox.TabIndex = 34;
            this.Tex3PictureBox.TabStop = false;
            this.Tex3PictureBox.Click += new System.EventHandler(this.Tex3PictureBox_Click);
            this.Tex3PictureBox.MouseHover += new System.EventHandler(this.Tex3PictureBox_MouseHover);
            // 
            // Tex2PictureBox
            // 
            this.Tex2PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tex2PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tex2PictureBox.Enabled = false;
            this.Tex2PictureBox.Location = new System.Drawing.Point(609, 78);
            this.Tex2PictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tex2PictureBox.Name = "Tex2PictureBox";
            this.Tex2PictureBox.Size = new System.Drawing.Size(84, 78);
            this.Tex2PictureBox.TabIndex = 33;
            this.Tex2PictureBox.TabStop = false;
            this.Tex2PictureBox.Click += new System.EventHandler(this.Tex2PictureBox_Click);
            this.Tex2PictureBox.MouseHover += new System.EventHandler(this.Tex2PictureBox_MouseHover);
            // 
            // Tex1PictureBox
            // 
            this.Tex1PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tex1PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tex1PictureBox.Enabled = false;
            this.Tex1PictureBox.Location = new System.Drawing.Point(516, 78);
            this.Tex1PictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tex1PictureBox.Name = "Tex1PictureBox";
            this.Tex1PictureBox.Size = new System.Drawing.Size(84, 78);
            this.Tex1PictureBox.TabIndex = 32;
            this.Tex1PictureBox.TabStop = false;
            this.Tex1PictureBox.Click += new System.EventHandler(this.Tex1PictureBox_Click);
            this.Tex1PictureBox.MouseHover += new System.EventHandler(this.Tex1PictureBox_MouseHover);
            // 
            // RemoveMatButton
            // 
            this.RemoveMatButton.BackgroundImage = global::SuperJSON.Properties.Resources.Remove;
            this.RemoveMatButton.Enabled = false;
            this.RemoveMatButton.Location = new System.Drawing.Point(119, 55);
            this.RemoveMatButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RemoveMatButton.Name = "RemoveMatButton";
            this.RemoveMatButton.Size = new System.Drawing.Size(21, 20);
            this.RemoveMatButton.TabIndex = 17;
            this.RemoveMatButton.UseVisualStyleBackColor = true;
            this.RemoveMatButton.Click += new System.EventHandler(this.RemoveMatButton_Click);
            // 
            // AddMatButton
            // 
            this.AddMatButton.BackgroundImage = global::SuperJSON.Properties.Resources.Add;
            this.AddMatButton.Enabled = false;
            this.AddMatButton.Location = new System.Drawing.Point(89, 55);
            this.AddMatButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddMatButton.Name = "AddMatButton";
            this.AddMatButton.Size = new System.Drawing.Size(21, 20);
            this.AddMatButton.TabIndex = 16;
            this.AddMatButton.UseVisualStyleBackColor = true;
            this.AddMatButton.Click += new System.EventHandler(this.AddMatButton_Click);
            // 
            // IndirectSettingsButton
            // 
            this.IndirectSettingsButton.Enabled = false;
            this.IndirectSettingsButton.Location = new System.Drawing.Point(609, 15);
            this.IndirectSettingsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IndirectSettingsButton.Name = "IndirectSettingsButton";
            this.IndirectSettingsButton.Size = new System.Drawing.Size(85, 28);
            this.IndirectSettingsButton.TabIndex = 52;
            this.IndirectSettingsButton.Text = "Indirect";
            this.IndirectSettingsButton.UseVisualStyleBackColor = true;
            this.IndirectSettingsButton.Click += new System.EventHandler(this.IndirectSettingsButton_Click);
            // 
            // TEVStagesButton
            // 
            this.TEVStagesButton.Enabled = false;
            this.TEVStagesButton.Location = new System.Drawing.Point(516, 15);
            this.TEVStagesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TEVStagesButton.Name = "TEVStagesButton";
            this.TEVStagesButton.Size = new System.Drawing.Size(85, 28);
            this.TEVStagesButton.TabIndex = 53;
            this.TEVStagesButton.Text = "TEV";
            this.TEVStagesButton.UseVisualStyleBackColor = true;
            this.TEVStagesButton.Click += new System.EventHandler(this.TEVStagesButton_Click);
            // 
            // SwapSettingsButton
            // 
            this.SwapSettingsButton.Enabled = false;
            this.SwapSettingsButton.Location = new System.Drawing.Point(433, 71);
            this.SwapSettingsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SwapSettingsButton.Name = "SwapSettingsButton";
            this.SwapSettingsButton.Size = new System.Drawing.Size(71, 28);
            this.SwapSettingsButton.TabIndex = 54;
            this.SwapSettingsButton.Text = "Swap";
            this.SwapSettingsButton.UseVisualStyleBackColor = true;
            this.SwapSettingsButton.Click += new System.EventHandler(this.SwapSettingsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 459);
            this.Controls.Add(this.SwapSettingsButton);
            this.Controls.Add(this.TEVStagesButton);
            this.Controls.Add(this.IndirectSettingsButton);
            this.Controls.Add(this.KONSTColGroupBox);
            this.Controls.Add(this.KONSTColLabel);
            this.Controls.Add(this.Tex8PictureBox);
            this.Controls.Add(this.Tex7PictureBox);
            this.Controls.Add(this.Tex6PictureBox);
            this.Controls.Add(this.Tex5PictureBox);
            this.Controls.Add(this.Tex4PictureBox);
            this.Controls.Add(this.Tex3PictureBox);
            this.Controls.Add(this.Tex2PictureBox);
            this.Controls.Add(this.Tex1PictureBox);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.DitherCheckBox);
            this.Controls.Add(this.RemoveMatButton);
            this.Controls.Add(this.AddMatButton);
            this.Controls.Add(this.TexListLabel);
            this.Controls.Add(this.SaveProgressBar);
            this.Controls.Add(this.CullComboBox);
            this.Controls.Add(this.CullLabel);
            this.Controls.Add(this.MatListBox);
            this.Controls.Add(this.InfoLabel1);
            this.Controls.Add(this.MatNameTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.MatColGroupBox);
            this.Controls.Add(this.AmbColGroupBox);
            this.Controls.Add(this.TEVColGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SuperJSON";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TEVANumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KONSTNumericUpDown)).EndInit();
            this.MatColGroupBox.ResumeLayout(false);
            this.MatColGroupBox.PerformLayout();
            this.AmbColGroupBox.ResumeLayout(false);
            this.AmbColGroupBox.PerformLayout();
            this.TEVColGroupBox.ResumeLayout(false);
            this.TEVColGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEVIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEVRNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEVGNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEVBNumericUpDown)).EndInit();
            this.KONSTColGroupBox.ResumeLayout(false);
            this.KONSTColGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tex8PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex7PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex6PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex5PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex4PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex3PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tex1PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox MatNameTextBox;
        private System.Windows.Forms.Label InfoLabel1;
        private System.Windows.Forms.ListBox MatListBox;
        private System.Windows.Forms.Label CullLabel;
        private System.Windows.Forms.ComboBox CullComboBox;
        private System.Windows.Forms.ProgressBar SaveProgressBar;
        private System.Windows.Forms.Timer SaveTimer;
        private System.Windows.Forms.Timer SaveCooldownTimer;
        private System.Windows.Forms.Label TexListLabel;
        private System.Windows.Forms.Button AddMatButton;
        private System.Windows.Forms.Button RemoveMatButton;
        private System.Windows.Forms.CheckBox DitherCheckBox;
        private System.Windows.Forms.ComboBox MatColComboBox;
        private System.Windows.Forms.Button MatColButton;
        private System.Windows.Forms.Button RemoveMatColButton;
        private System.Windows.Forms.Button AddMatColButton;
        private System.Windows.Forms.Button RemoveAmbColButton;
        private System.Windows.Forms.Button AddAmbColButton;
        private System.Windows.Forms.Button AmbColButton;
        private System.Windows.Forms.ComboBox AmbColComboBox;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.PictureBox Tex1PictureBox;
        private System.Windows.Forms.PictureBox Tex2PictureBox;
        private System.Windows.Forms.PictureBox Tex4PictureBox;
        private System.Windows.Forms.PictureBox Tex3PictureBox;
        private System.Windows.Forms.PictureBox Tex6PictureBox;
        private System.Windows.Forms.PictureBox Tex5PictureBox;
        private System.Windows.Forms.PictureBox Tex8PictureBox;
        private System.Windows.Forms.PictureBox Tex7PictureBox;
        private System.Windows.Forms.Button KONSTColButton;
        private System.Windows.Forms.ComboBox KONSTColComboBox;
        private System.Windows.Forms.Label KONSTColLabel;
        private System.Windows.Forms.NumericUpDown TEVANumericUpDown;
        private System.Windows.Forms.NumericUpDown KONSTNumericUpDown;
        private System.Windows.Forms.GroupBox MatColGroupBox;
        private System.Windows.Forms.TextBox MatColTextBox;
        private System.Windows.Forms.GroupBox AmbColGroupBox;
        private System.Windows.Forms.TextBox AmbColTextBox;
        private System.Windows.Forms.GroupBox TEVColGroupBox;
        private System.Windows.Forms.TextBox KONSTColTextBox;
        private System.Windows.Forms.GroupBox KONSTColGroupBox;
        private System.Windows.Forms.Button IndirectSettingsButton;
        private System.Windows.Forms.Button TEVStagesButton;
        private System.Windows.Forms.Button SwapSettingsButton;
        private System.Windows.Forms.NumericUpDown TEVIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown TEVRNumericUpDown;
        private System.Windows.Forms.NumericUpDown TEVGNumericUpDown;
        private System.Windows.Forms.NumericUpDown TEVBNumericUpDown;
        private System.Windows.Forms.Label TevColLabel;
    }
}

