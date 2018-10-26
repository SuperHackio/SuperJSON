using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using QuickType;

namespace SuperJSON
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CenterToScreen();
            MatListBox.Items.Add("No JSON loaded");
            pictureboxs = new PictureBox[8] { Tex1PictureBox, Tex2PictureBox, Tex3PictureBox, Tex4PictureBox, Tex5PictureBox, Tex6PictureBox, Tex7PictureBox, Tex8PictureBox };
        }

        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        ColorDialog clrDialog = new ColorDialog();
        ToolTip mouseToolTip = new ToolTip();

        FileStream fs;
        FileInfo fInfo;
        FileInfo sInfo;
        Bitmap TexDisplay = Properties.Resources.NoTexture;
        Bitmap resized;
        Rectangle TexDrawRect = new Rectangle(7, 19, 107, 64);

        public List<TextureHeader> texheader = new List<TextureHeader>();
        public List<Material> materials;
        List<Material> addingmaterials;

        PictureBox[] pictureboxs;

        public int selectedmaterial = 0;
        public int selectedtexture = 0;
        public int cooldown = 0;
        public bool working = false;
        public bool error = false;
        public bool opening = false;
        public string FilePath;


        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            SaveTimer.Start();
            ofd.Filter = "SuperBMD Material settings (*.json)|*.json";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            //JSON only from here on out
            working = true;
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                fInfo = new FileInfo(ofd.FileName);
                FilePath = fInfo.DirectoryName;
                opening = true;
                selectedmaterial = 0;
                MatListBox.SelectedIndex = 0;
                MatListBox.Items.Clear();
                opening = false;
                LoadJson(false);
                MatListBox.Items.Clear();

                foreach (var material in materials)
                {
                    SaveProgressBar.Increment(new Random().Next(1, 5));
                    MatListBox.Items.Add(material.Name);
                    if (MatListBox.Items.Count >= 19)
                    {
                        MessageBox.Show("The maximum amount of Materials is 19.", "Error");
                        AddMatButton.Enabled = false;
                        break;
                    }
                }
                working = false;
                SetAppStatus(true);
                try
                {

                    MatListBox.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    materials = null;
                    MatListBox.Items.Clear();
                    MatListBox.Items.Add("No JSON loaded");
                    MessageBox.Show("This is not a Material JSON!","No U");
                    SetAppStatus(false);
                    OpenButton.Enabled = true;
                    return;
                }
                AddMatButton.Enabled = materials.Count < 19 ? true : false;
                RemoveMatButton.Enabled = materials.Count > 1 ? true : false;
                //---------------------------------------------------------------------------------------------------------------------------------------
                var current = 0;
                bool contains = false;
                texheader.Clear();
                if (File.Exists(fInfo.DirectoryName + "\\" + fInfo.Name.Remove(fInfo.Name.Length - 5) + "_tex.json"))
                {
                    try
                    {
                        using (StreamReader r = new StreamReader(File.OpenRead(fInfo.DirectoryName + "\\" + fInfo.Name.Remove(fInfo.Name.Length - 5) + "_tex.json")))
                        {
                            string json = r.ReadToEnd();
                            texheader = JsonConvert.DeserializeObject<List<TextureHeader>>(json);
                            r.Close();
                        }
                        foreach (TextureHeader th in texheader)
                        {
                            if (th.Format == null)
                            {
                                throw new Exception();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        error = true;
                        MessageBox.Show("The Texture Header could not be read!", "Malformed JSON");
                        texheader.Clear();
                        SetBaseTexHead(current, contains);
                        error = false;
                    }
                    
                }
                else if (File.Exists(fInfo.DirectoryName + "\\" + fInfo.Name.Remove(fInfo.Name.Length - 9) + "_texheader.json"))
                {
                    try
                    {
                        using (StreamReader r = new StreamReader(File.OpenRead(fInfo.DirectoryName + "\\" + fInfo.Name.Remove(fInfo.Name.Length - 9) + "_texheader.json")))
                        {
                            string json = r.ReadToEnd();
                            texheader = JsonConvert.DeserializeObject<List<TextureHeader>>(json);
                            r.Close();
                        }
                        foreach (TextureHeader th in texheader)
                        {
                            if (th.Format == null)
                            {
                                throw new Exception();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        error = true;
                        MessageBox.Show("The Texture Header could not be read!", "Malformed JSON");
                        texheader.Clear();
                        SetBaseTexHead(current, contains);
                        error = false;
                    }
                }
                else
                {
                    SetBaseTexHead(current, contains);
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveTimer.Start();
            sfd.Filter = "SuperBMD Material settings (*.json)|*.json";
            sfd.FilterIndex = 1;
            //I want a comment here idk why
            working = true;
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                sInfo = new FileInfo(sfd.FileName);
                working = false;
                //FileStream flstr = null;
                //flstr = new FileStream(sfd.FileName, FileMode.Create);
                string json = JsonConvert.SerializeObject(materials, Formatting.Indented);
                File.WriteAllText(sfd.FileName, json);
                json = JsonConvert.SerializeObject(texheader, Formatting.Indented);
                File.WriteAllText(sInfo.DirectoryName+"\\"+sInfo.Name.Remove(sInfo.Name.Length-5) +"_tex.json", json);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            SetAppStatus(false);
            working = true;
            error = false;
            SaveTimer.Start();
            MatListBox.SelectedIndex = 0;

            sfd.Filter = "SuperBMD Material settings (*.json)|*.json";
            sfd.FilterIndex = 1;
            //I want a comment here idk why
            var jsonpath = "";
            var textpath = "";
            working = true;
            sfd.FileName = "";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                jsonpath = sfd.FileName;
                sInfo = new FileInfo(sfd.FileName);
                working = false;
                string json = JsonConvert.SerializeObject(materials, Formatting.Indented);
                File.WriteAllText(sfd.FileName, json);
                json = JsonConvert.SerializeObject(texheader, Formatting.Indented);
                textpath = sInfo.DirectoryName + "\\" + sInfo.Name.Remove(sInfo.Name.Length - 5) + "_tex.json";
                File.WriteAllText(textpath, json);
            }
            else
            {
                working = false;
                error = true;
                MessageBox.Show("Filepath not selected!", "Warning!");
                SetAppStatus(true);
                return;
            }

            #region Texture Scanning
            for (int j = 0; j < MatListBox.Items.Count - 1; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    try
                    {
                        fs = new FileStream(sInfo.DirectoryName + "\\" + materials[j].Textures[i] + ".png", FileMode.Open, FileAccess.Read);
                        fs.Close();
                        SaveProgressBar.Increment(5);
                    }
                    catch (FileNotFoundException)
                    {
                        if (materials[j].Textures[i] != null)
                        {
                            error = true;
                            MessageBox.Show(materials[j].Textures[i] + ".png Does not exist!", "Warning!");
                            SetAppStatus(true);
                            return;
                        }

                    }
                }
                MatListBox.SelectedIndex++;

            }
            #endregion

            var SuperBMDpath = "";
            ofd.Filter = "SuperBMD (SuperBMD.exe)|*SuperBMD.exe";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            working = true;
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                working = false;
                SuperBMDpath = ofd.FileName;
            }
            else
            {
                working = false;
                error = true;
                MessageBox.Show("SuperBMD not selected!", "Warning!");
                SetAppStatus(true);
                return;
            }

            #region Check SuperBMD Version
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("\"" + SuperBMDpath + "\"" + " --version 1.3.6");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            var result = cmd.StandardOutput.ReadToEnd();
            if (!result.Contains("VERSION: True"))
            {
                working = false;
                error = true;
                MessageBox.Show("You need SuperBMD Version 1.3.6 or higher to export with SuperJSON","Wrong Version alert!");
                SetAppStatus(true);
                return;
            }
            #endregion

            var Modelpath = "";
            ofd.Filter = "AutoDesk Filmbox (.fbx)|*.fbx";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            working = true;
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                working = false;
                Modelpath = ofd.FileName;
            }
            else
            {
                working = false;
                error = true;
                MessageBox.Show("Model not selected!", "Warning!");
                SetAppStatus(true);
                return;
            }
            working = false;
            MatListBox.SelectedIndex = 0;
            cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("\"" + SuperBMDpath + "\"" + " " + "\"" + Modelpath + "\"" + " --mat " + "\"" + jsonpath + "\"" + " --tex " + "\"" + textpath + "\"");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            MessageBox.Show(cmd.StandardOutput.ReadToEnd());
            //END
            SetAppStatus(true);
            ReloadImages();
        }


        private void SetBaseTexHead(int current, bool contains)
        {
            foreach (Material mat in materials)
            {
                foreach (string texname in materials[current].Textures)
                {
                    if (texheader != null)
                    {
                        contains = texheader.Any(p => p.Name == texname);
                    }
                    if (texname != null && !contains)
                    {
                        texheader.Add(new TextureHeader { AttachPalette = 0, Name = texname, Format = TextureFormat.CMPR.ToString(), AlphaSetting = 0, WrapS = TextureWrap.ClampToEdge.ToString(), WrapT = TextureWrap.ClampToEdge.ToString(), MinFilter = TextureMinFilter.Linear.ToString(), MagFilter = TextureMagFilter.Linear.ToString(), MinLod = 0, MaxLod = 0 });
                    }
                }
                current++;
            }
        }

        public void LoadJson(bool add)
        {
            using (StreamReader r = new StreamReader(File.OpenRead(ofd.FileName)))
            {
                string json = r.ReadToEnd();
                if (add)
                {
                    addingmaterials = JsonConvert.DeserializeObject<List<Material>>(json);
                    foreach (Material mat in addingmaterials)
                    {
                        if (mat.NbtScale == null)
                        {
                            MessageBox.Show("This is not a Material JSON!", "No U");
                            addingmaterials.Clear();
                            return;
                        }
                    }
                    materials.AddRange(addingmaterials);
                    if (materials.Count > 19)
                    {
                        for (int i = materials.Count; i < 19; i--)
                        {
                            materials.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    materials = JsonConvert.DeserializeObject<List<Material>>(json);
                }
                r.Close();
            }
        }

        /// <summary>
        /// Enable/Disable all the buttons
        /// </summary>
        /// <param name="trigger">Enable (true) or Disable (false) all the operands</param>
        public void SetAppStatus(bool trigger)
        {
            OpenButton.Enabled = trigger;
            SaveButton.Enabled = trigger;
            ExportButton.Enabled = trigger;
            MatListBox.Enabled = trigger;
            MatNameTextBox.Enabled = trigger;
            DitherCheckBox.Enabled = trigger;
            CullComboBox.Enabled = trigger;
            MatColComboBox.Enabled = trigger;
            MatColButton.Enabled = trigger;
            MatColTextBox.Enabled = trigger;
            AmbColComboBox.Enabled = trigger;
            AmbColButton.Enabled = trigger;
            AmbColTextBox.Enabled = trigger;
            TEVColComboBox.Enabled = trigger;
            TEVColButton.Enabled = trigger;
            TEVNumericUpDown.Enabled = trigger;
            TEVColTextBox.Enabled = trigger;
            KONSTColComboBox.Enabled = trigger;
            KONSTColButton.Enabled = trigger;
            KONSTNumericUpDown.Enabled = trigger;
            KONSTColTextBox.Enabled = trigger;
            TEVStagesButton.Enabled = trigger;
            IndirectSettingsButton.Enabled = trigger;
            foreach (var picturebox in pictureboxs)
            {
                picturebox.Enabled = trigger;
            }
            if (trigger)
            {
                SaveProgressBar.Value = 0;
                AddMatButton.Enabled = materials.Count < 19 ? true : false;
                RemoveMatButton.Enabled = materials.Count > 1 ? true : false;
            }
            else
            {
                AddMatButton.Enabled = false;
                RemoveMatButton.Enabled = false;
            }
            SaveTimer.Start();
            error = false;
            working = false;
        }

        /// <summary>
        /// Shrink an image
        /// </summary>
        /// <param name="original">Image to shrink</param>
        /// <returns>Shrunken image</returns>
        public Bitmap ResizeImage(Bitmap original)
        {
            return resized = new Bitmap(original, new Size(64, 64));
        }

        /// <summary>
        /// Reloads the Texture PictureBoxes
        /// </summary>
        /// <param name="quick">Skip shifting the textures</param>
        public void ReloadImages(bool quick = false)
        {
            var loadtextint = 0;
            var lastint = -1;
            var startfrom = 0;
            foreach (var picturebox in pictureboxs)
            {
                TexDisplay = Properties.Resources.NoTexture; //No Texture
                try
                {
                    fs = new FileStream(FilePath + "\\" + materials[selectedmaterial].Textures[loadtextint] + ".png", FileMode.Open, FileAccess.Read);
                    TexDisplay = (Bitmap)Image.FromStream(fs);
                    fs.Close();
                    TexDisplay = ResizeImage(TexDisplay); // Shrink it
                }
                catch (FileNotFoundException)
                {
                    TexDisplay = materials[selectedmaterial].Textures[loadtextint] == null ? Properties.Resources.NoTexture : Properties.Resources.MissingTexture; //Missing Texture
                }
                picturebox.Image = TexDisplay;
                if (materials[selectedmaterial].Textures[loadtextint] == null)
                {
                    if (lastint == -1)
                    {
                        lastint = loadtextint;
                    }
                    picturebox.Enabled = false;
                }
                loadtextint++;
            }

            if (lastint != -1)
            {
                pictureboxs[lastint].Enabled = true;
            }

            if ((lastint != 0 && lastint != 8) && (pictureboxs[lastint - 1].Enabled == true && pictureboxs[lastint + 1].Enabled == true))
            {
                quick = false;
                startfrom = lastint;
            }
            if (!quick)
            {
                if (lastint == 0)
                {
                    pictureboxs[0].Enabled = false;
                }

                if (pictureboxs[0].Enabled == false || startfrom != 0)
                {
                    for (int i = startfrom; i < 7; i++)
                    {
                        materials[selectedmaterial].Textures[i] = materials[selectedmaterial].Textures[i + 1];
                        materials[selectedmaterial].TexCoord1Gens[i] = materials[selectedmaterial].TexCoord1Gens[i + 1];
                        materials[selectedmaterial].TevOrders[i] = materials[selectedmaterial].TevOrders[i + 1];
                        materials[selectedmaterial].TexMatrix1[i] = materials[selectedmaterial].TexMatrix1[i + 1];
                        materials[selectedmaterial].TevStages[i] = materials[selectedmaterial].TevStages[i + 1];
                        materials[selectedmaterial].SwapModes[i] = materials[selectedmaterial].SwapModes[i + 1];
                    }
                    materials[selectedmaterial].Textures[7] = null;
                    pictureboxs[0].Enabled = true;
                    ReloadImages(true);
                }
            }

            materials[selectedmaterial].NumTevStagesCount = lastint;
            materials[selectedmaterial].NumTexGensCount = lastint;
        }



        private void MatListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (opening)
            {
                return;
            }

            if (MatListBox.SelectedIndex != selectedmaterial)//Push the new stuff if it hasn't been already pushed.
            {
                MatListBox.Items[selectedmaterial] = materials[selectedmaterial].Name;
                materials[selectedmaterial].Dither = DitherCheckBox.Checked;

                if (MatListBox.SelectedIndex < 0)
                {
                    MatListBox.SelectedIndex = 0;
                }
                selectedmaterial = MatListBox.SelectedIndex;

            }
            MatNameTextBox.Text = materials[selectedmaterial].Name;
            //----------------------------------------------------------------
            if (ExportButton.Enabled)
            {
                ReloadImages();
            }
            //----------------------------------------------------------------
            MatColComboBox.Items.Clear();
            var MatColCount = 0;
            AddMatColButton.Enabled = false;
            foreach (var MatCol in materials[selectedmaterial].MaterialColors)
            {
                if (MatCol != null)
                {
                    MatColComboBox.Items.Add("Colour " + MatColCount);

                    MatColCount++;
                }
            }
            AddMatColButton.Enabled = MatColCount != 2 ? true : false;
            MatColComboBox.SelectedIndex = 0;
            //----------------------------------------------------------------
            AmbColComboBox.Items.Clear();
            var AmbColCount = 0;
            AddAmbColButton.Enabled = false;
            foreach (var AmbCol in materials[selectedmaterial].AmbientColors)
            {
                if (AmbCol != null)
                {
                    AmbColComboBox.Items.Add("Colour " + AmbColCount);

                    AmbColCount++;
                }
            }
            AddAmbColButton.Enabled = AmbColCount != 2 ? true : false;
            AmbColComboBox.SelectedIndex = 0;
            //----------------------------------------------------------------
            switch (materials[selectedmaterial].CullMode)
            {
                case "None":
                    CullComboBox.SelectedIndex = 0;
                    break;
                case "Front":
                    CullComboBox.SelectedIndex = 1;
                    break;
                case "Back":
                    CullComboBox.SelectedIndex = 2;
                    break;
                case "All":
                    CullComboBox.SelectedIndex = 3;
                    break;
                default:
                    break;
            }
            //----------------------------------------------------------------
            DitherCheckBox.Checked = materials[selectedmaterial].Dither;
            //----------------------------------------------------------------
            TEVColComboBox.Items.Clear();
            var TEVselect = 0;
            foreach (var TevColour in materials[selectedmaterial].TevColors)
            {
                if (TevColour != null)
                {
                    TEVColComboBox.Items.Add("Colour " + TEVselect);
                }
                TEVselect++;
            }
            TEVColComboBox.SelectedIndex = 0;
            //----------------------------------------------------------------
            KONSTColComboBox.SelectedIndex = 1;
            KONSTColComboBox.SelectedIndex = 0;
            //----------------------------------------------------------------
            IndirectSettingsButton.Enabled = materials[selectedmaterial].IndTexEntry != null ? true : false;
            //----------------------------------------------------------------
            //End loading
        }

        private void MatNameTextBox_TextChanged(object sender, EventArgs e)
        {
            MatNameTextBox.Text = MatNameTextBox.Text.Replace(' ', '_');
            materials[selectedmaterial].Name = MatNameTextBox.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => materials[selectedmaterial].CullMode = CullComboBox.Text;

        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            if (!working && !error)
            {
                SaveProgressBar.Increment(new Random().Next(1, 5));
                ModifyProgressBarColor.SetState(SaveProgressBar, 1);
            }
            else
            {
                if (error)
                {
                    ModifyProgressBarColor.SetState(SaveProgressBar, 2);
                    //    SaveProgressBar.Increment(10);
                }
                else
                {
                    ModifyProgressBarColor.SetState(SaveProgressBar, 3);
                }
            }
            if (SaveProgressBar.Value >= 100)
            {
                cooldown = 5;
                SaveTimer.Stop();
                SaveCooldownTimer.Start();
            }
        }

        private void SaveCooldownTimer_Tick(object sender, EventArgs e)
        {
            cooldown--;
            if (cooldown <= 0)
            {
                SaveCooldownTimer.Stop();
                SaveProgressBar.Value = 0;
            }
        }

        private void AddMatButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "SuperBMD Material settings (*.json)|*.json";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            //JSON only from here on out
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                LoadJson(true);
                foreach (var material in addingmaterials)
                {
                    MatListBox.Items.Add(material.Name);
                    if (MatListBox.Items.Count >= 19)
                    {
                        MessageBox.Show("The maximum amount of Materials is 19.", "Error");
                        AddMatButton.Enabled = false;
                        break;
                    }
                }
                RemoveMatButton.Enabled = true;
            }
        }

        private void RemoveMatButton_Click(object sender, EventArgs e)
        {
            MatListBox.Enabled = false;
            SaveTimer.Start();
            var check = 0;
            foreach (var item in materials[selectedmaterial].Textures)
            {
                if (item != null)
                {
                    DeleteTexture(check);
                }
                check++;
            }
            materials.RemoveAt(selectedmaterial);
            if (selectedmaterial != 0)
            {
                selectedmaterial -= 1;
                MatListBox.Items.RemoveAt(selectedmaterial + 1);
            }
            else
            {
                MatListBox.Items.RemoveAt(selectedmaterial);
            }
            if (materials.Count == 1)
            {
                RemoveMatButton.Enabled = false;
            }
            AddMatButton.Enabled = true;
            MatListBox.Enabled = true;
        }

        public int test(bool testfor, bool testtwo)
        {
            return testfor ? testtwo ? 1 : 0 : 0;
        } //--------------------------------------------

        #region Colour Related stuff

        private void MatColComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].A * 255), (int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].B * 255));
            //MessageBox.Show(MatColComboBox.SelectedIndex.ToString());
            RemoveMatColButton.Enabled = MatColComboBox.SelectedIndex > 0 ? true : false;
            AddMatColButton.Enabled = MatColComboBox.Items.Count == 1 ? true : false;
            MatColTextBox.Text = MatColButton.BackColor.R.ToString("X2") + MatColButton.BackColor.G.ToString("X2") + MatColButton.BackColor.B.ToString("X2") + MatColButton.BackColor.A.ToString("X2");
        }

        private void MatColButton_Click(object sender, EventArgs e)
        {
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                //save the colour that the user chose
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].R = (double)clrDialog.Color.R / 255;
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].G = (double)clrDialog.Color.G / 255;
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].B = (double)clrDialog.Color.B / 255;
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].A = (double)clrDialog.Color.A / 255;
                // MessageBox.Show(("Red: "+clrDialog.Color.R).ToString()+" || "+ ((double)clrDialog.Color.R/255).ToString());
                // MessageBox.Show(("Green: " + clrDialog.Color.G).ToString() + " || " + ((double)clrDialog.Color.G / 255).ToString());
                //MessageBox.Show(("Blue: " + clrDialog.Color.B).ToString() + " || " + ((double)clrDialog.Color.B / 255).ToString());
                MatColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].A * 255), (int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].B * 255));
                MatColTextBox.Text = MatColButton.BackColor.R.ToString("X2") + MatColButton.BackColor.G.ToString("X2") + MatColButton.BackColor.B.ToString("X2") + MatColButton.BackColor.A.ToString("X2");
            }
        }

        private void AddMatColButton_Click(object sender, EventArgs e)
        {
            materials[selectedmaterial].MaterialColors[1] = new AmbientColor();
            materials[selectedmaterial].MaterialColors[1].A = 1.0;
            materials[selectedmaterial].MaterialColors[1].R = 1.0;
            materials[selectedmaterial].MaterialColors[1].G = 1.0;
            materials[selectedmaterial].MaterialColors[1].B = 1.0;
            MatColComboBox.Items.Add("Colour 1");
            AddMatColButton.Enabled = false;
        }

        private void RemoveMatColButton_Click(object sender, EventArgs e)
        {
            materials[selectedmaterial].MaterialColors[1] = null;
            MatColComboBox.Items.RemoveAt(1);
            MatColComboBox.SelectedIndex = 0;
        }

        private void AmbColComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AmbColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].A * 255), (int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].B * 255));

            RemoveAmbColButton.Enabled = AmbColComboBox.SelectedIndex > 0 ? true : false;
            AddAmbColButton.Enabled = AmbColComboBox.Items.Count == 1 ? true : false;
            AmbColTextBox.Text = AmbColButton.BackColor.R.ToString("X2") + AmbColButton.BackColor.G.ToString("X2") + AmbColButton.BackColor.B.ToString("X2") + AmbColButton.BackColor.A.ToString("X2");

        }

        private void AmbColButton_Click(object sender, EventArgs e)
        {
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                //save the colour that the user chose
                materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].R = (double)clrDialog.Color.R / 255;
                materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].G = (double)clrDialog.Color.G / 255;
                materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].B = (double)clrDialog.Color.B / 255;
                materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].A = (double)clrDialog.Color.A / 255;
                AmbColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].A * 255), (int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].B * 255));
                AmbColTextBox.Text = AmbColButton.BackColor.R.ToString("X2") + AmbColButton.BackColor.G.ToString("X2") + AmbColButton.BackColor.B.ToString("X2") + AmbColButton.BackColor.A.ToString("X2");
            }
        }

        private void AddAmbColButton_Click(object sender, EventArgs e)
        {
            materials[selectedmaterial].AmbientColors[1] = new AmbientColor();
            materials[selectedmaterial].AmbientColors[1].A = 1.0;
            materials[selectedmaterial].AmbientColors[1].R = 1.0;
            materials[selectedmaterial].AmbientColors[1].G = 1.0;
            materials[selectedmaterial].AmbientColors[1].B = 1.0;
            AmbColComboBox.Items.Add("Colour 1");
            AddAmbColButton.Enabled = false;
        }

        private void RemoveAmbColButton_Click(object sender, EventArgs e)
        {
            materials[selectedmaterial].AmbientColors[1] = null;
            AmbColComboBox.Items.RemoveAt(1);
            AmbColComboBox.SelectedIndex = 0;
        }

        private void TEVColComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TEVColButton.BackColor = Color.FromArgb((int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].B * 255));
                TEVNumericUpDown.Value = (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].A * 255);
                if (TEVNumericUpDown.Value > 255)
                {
                    TEVColTextBox.Text = TEVColButton.BackColor.R.ToString("X2") + TEVColButton.BackColor.G.ToString("X2") + TEVColButton.BackColor.B.ToString("X2");
                }
                else
                {
                    TEVColTextBox.Text = TEVColButton.BackColor.R.ToString("X2") + TEVColButton.BackColor.G.ToString("X2") + TEVColButton.BackColor.B.ToString("X2") + TEVColButton.BackColor.A.ToString("X2");
                }

                TEVNumericUpDown.Enabled = true;
                TEVColButton.Enabled = true;
                TEVColTextBox.Enabled = true;
            }
            catch (Exception)
            {
                TEVNumericUpDown.Value = 0;
                TEVNumericUpDown.Enabled = false;
                TEVColButton.Enabled = false;
                TEVColTextBox.Enabled = false;
            }


        }

        private void TEVColButton_Click(object sender, EventArgs e)
        {
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                //save the colour that the user chose
                materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].R = (short)(clrDialog.Color.R / 255);
                materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].G = (short)(clrDialog.Color.G / 255);
                materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].B = (short)(clrDialog.Color.B / 255);
                TEVColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].B * 255));
                TEVColTextBox.Text = TEVColButton.BackColor.R.ToString("X2") + TEVColButton.BackColor.G.ToString("X2") + TEVColButton.BackColor.B.ToString("X2");


            }
        }

        private void TEVNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].A = (double)TEVNumericUpDown.Value / 255;
            TEVColTextBox.Text = TEVColButton.BackColor.R.ToString("X2") + TEVColButton.BackColor.G.ToString("X2") + TEVColButton.BackColor.B.ToString("X2");
        }

        private void KONSTColComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KONSTColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].A * 255), (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].B * 255));
            KONSTNumericUpDown.Value = (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].A * 255);

            KONSTColTextBox.Text = KONSTColButton.BackColor.R.ToString("X2") + KONSTColButton.BackColor.G.ToString("X2") + KONSTColButton.BackColor.B.ToString("X2") + KONSTColButton.BackColor.A.ToString("X2");
        }

        private void KONSTColButton_Click(object sender, EventArgs e)
        {
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                //save the colour that the user chose
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].R = (double)clrDialog.Color.R / 255;
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].G = (double)clrDialog.Color.G / 255;
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].B = (double)clrDialog.Color.B / 255;
                KONSTColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].A * 255), (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].B * 255));
                KONSTColTextBox.Text = KONSTColButton.BackColor.R.ToString("X2") + KONSTColButton.BackColor.G.ToString("X2") + KONSTColButton.BackColor.B.ToString("X2") + KONSTColButton.BackColor.A.ToString("X2");
            }
        }

        private void KONSTNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].A = (double)(KONSTNumericUpDown.Value / 255);
            KONSTColTextBox.Text = KONSTColButton.BackColor.R.ToString("X2") + KONSTColButton.BackColor.G.ToString("X2") + KONSTColButton.BackColor.B.ToString("X2") + KONSTColButton.BackColor.A.ToString("X2");
        }

        private void MatColTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].R = (double)Convert.ToInt16(MatColTextBox.Text.Substring(0, 2), 16) / 255;
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].G = (double)Convert.ToInt16(MatColTextBox.Text.Substring(2, 2), 16) / 255;
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].B = (double)Convert.ToInt16(MatColTextBox.Text.Substring(4, 2), 16) / 255;
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].A = (double)Convert.ToInt16(MatColTextBox.Text.Substring(6, 2), 16) / 255;

                MatColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].A * 255), (int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].B * 255));
                MatColTextBox.Text = MatColButton.BackColor.R.ToString("X2") + MatColButton.BackColor.G.ToString("X2") + MatColButton.BackColor.B.ToString("X2") + MatColButton.BackColor.A.ToString("X2");
                MatColTextBox.BackColor = default(Color);
            }
            catch (Exception)
            {
                MatColTextBox.BackColor = Color.Red;
            }
        }

        private void AmbColTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].R = (double)Convert.ToInt16(AmbColTextBox.Text.Substring(0, 2), 16) / 255;
                materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].G = (double)Convert.ToInt16(AmbColTextBox.Text.Substring(2, 2), 16) / 255;
                materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].B = (double)Convert.ToInt16(AmbColTextBox.Text.Substring(4, 2), 16) / 255;
                materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].A = (double)Convert.ToInt16(AmbColTextBox.Text.Substring(6, 2), 16) / 255;
                AmbColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].A * 255), (int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].AmbientColors[AmbColComboBox.SelectedIndex].B * 255));
                AmbColTextBox.Text = AmbColButton.BackColor.R.ToString("X2") + AmbColButton.BackColor.G.ToString("X2") + AmbColButton.BackColor.B.ToString("X2") + AmbColButton.BackColor.A.ToString("X2");
                AmbColTextBox.BackColor = default(Color);
            }
            catch (Exception)
            {
                AmbColTextBox.BackColor = Color.Red;
            }
        }

        private void TEVColTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].R = (double)Convert.ToInt16(TEVColTextBox.Text.Substring(0, 2), 16) / 255;
                materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].G = (double)Convert.ToInt16(TEVColTextBox.Text.Substring(2, 2), 16) / 255;
                materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].B = (double)Convert.ToInt16(TEVColTextBox.Text.Substring(4, 2), 16) / 255;

                TEVColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].B * 255));
                //TEVColTextBox.Text = TEVColButton.BackColor.R.ToString("X2") + TEVColButton.BackColor.G.ToString("X2") + TEVColButton.BackColor.B.ToString("X2");
                if (TEVColTextBox.Text.Length > 6)
                {
                    materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].A = (double)Convert.ToInt16(TEVColTextBox.Text.Substring(6, 2), 16) / 255;
                    if (materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].A < 1.0f && materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].A > 0.0f)
                    {
                        TEVColButton.BackColor = System.Drawing.Color.FromArgb((int)materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].A * 255, (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].TevColors[TEVColComboBox.SelectedIndex].B * 255));

                    }
                }
                TEVColTextBox.BackColor = default(Color);
                TEVNumericUpDown.Value = Convert.ToInt16(TEVColTextBox.Text.Substring(6, 2), 16);
            }
            catch (Exception)
            {
                if (TEVColTextBox.Text.Length == 6)
                {
                    TEVColTextBox.BackColor = default(Color);
                }
                else
                {
                    TEVColTextBox.BackColor = Color.Red;
                }
            }

        }

        private void KONSTColTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].R = (double)Convert.ToInt16(KONSTColTextBox.Text.Substring(0, 2), 16) / 255;
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].G = (double)Convert.ToInt16(KONSTColTextBox.Text.Substring(2, 2), 16) / 255;
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].B = (double)Convert.ToInt16(KONSTColTextBox.Text.Substring(4, 2), 16) / 255;
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].A = (double)Convert.ToInt16(KONSTColTextBox.Text.Substring(6, 2), 16) / 255;
                KONSTColButton.BackColor = System.Drawing.Color.FromArgb((int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].A * 255), (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].R * 255), (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].G * 255), (int)(materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].B * 255));
                KONSTColTextBox.Text = KONSTColButton.BackColor.R.ToString("X2") + KONSTColButton.BackColor.G.ToString("X2") + KONSTColButton.BackColor.B.ToString("X2") + KONSTColButton.BackColor.A.ToString("X2");
                KONSTColTextBox.BackColor = default(Color);
                KONSTNumericUpDown.Value = KONSTColButton.BackColor.A;
            }
            catch (Exception)
            {
                KONSTColTextBox.BackColor = Color.Red;
            }
        }

        #endregion

        #region Picturebutton Clicks & Hovers
        private void Tex1PictureBox_Click(object sender, EventArgs e)
        {
            switch (((MouseEventArgs)e).Button)
            {

                case MouseButtons.Left:
                    LoadTexEditor(0);
                    break;

                case MouseButtons.Right:
                    DeleteTexture(0);
                    ReloadImages();
                    break;
            }
        }

        private void Tex2PictureBox_Click(object sender, EventArgs e)
        {
            switch (((MouseEventArgs)e).Button)
            {

                case MouseButtons.Left:
                    LoadTexEditor(1);
                    break;

                case MouseButtons.Right:
                    DeleteTexture(1);
                    ReloadImages();
                    break;
            }
        }

        private void Tex3PictureBox_Click(object sender, EventArgs e)
        {
            switch (((MouseEventArgs)e).Button)
            {

                case MouseButtons.Left:
                    LoadTexEditor(2);
                    break;

                case MouseButtons.Right:
                    DeleteTexture(2);
                    ReloadImages();
                    break;
            }
        }

        private void Tex4PictureBox_Click(object sender, EventArgs e)
        {
            switch (((MouseEventArgs)e).Button)
            {

                case MouseButtons.Left:
                    LoadTexEditor(3);
                    break;

                case MouseButtons.Right:
                    DeleteTexture(3);
                    ReloadImages();
                    break;
            }
        }

        private void Tex5PictureBox_Click(object sender, EventArgs e)
        {
            switch (((MouseEventArgs)e).Button)
            {

                case MouseButtons.Left:
                    LoadTexEditor(4);
                    break;

                case MouseButtons.Right:
                    DeleteTexture(4);
                    ReloadImages();
                    break;
            }
        }

        private void Tex6PictureBox_Click(object sender, EventArgs e)
        {
            switch (((MouseEventArgs)e).Button)
            {

                case MouseButtons.Left:
                    LoadTexEditor(5);
                    break;

                case MouseButtons.Right:
                    DeleteTexture(5);
                    ReloadImages();
                    break;
            }
        }

        private void Tex7PictureBox_Click(object sender, EventArgs e)
        {
            switch (((MouseEventArgs)e).Button)
            {

                case MouseButtons.Left:
                    LoadTexEditor(6);
                    break;

                case MouseButtons.Right:
                    DeleteTexture(6);
                    ReloadImages();
                    break;
            }
        }

        private void Tex8PictureBox_Click(object sender, EventArgs e)
        {
            switch (((MouseEventArgs)e).Button)
            {

                case MouseButtons.Left:
                    LoadTexEditor(7);
                    break;

                case MouseButtons.Right:
                    DeleteTexture(7);
                    ReloadImages();
                    break;
            }
        }

        private void Tex1PictureBox_MouseHover(object sender, EventArgs e)
        {
            if (materials[selectedmaterial].Textures[0] != null)
            {
                mouseToolTip.SetToolTip(Tex1PictureBox, "Right click to delete");
            }
            else
            {
                mouseToolTip.SetToolTip(Tex1PictureBox, "Click to add");
            }
        }

        private void Tex2PictureBox_MouseHover(object sender, EventArgs e)
        {
            if (materials[selectedmaterial].Textures[1] != null)
            {
                mouseToolTip.SetToolTip(Tex2PictureBox, "Right click to delete");
            }
            else
            {
                mouseToolTip.SetToolTip(Tex2PictureBox, "Click to add");
            }
        }

        private void Tex3PictureBox_MouseHover(object sender, EventArgs e)
        {
            if (materials[selectedmaterial].Textures[2] != null)
            {
                mouseToolTip.SetToolTip(Tex3PictureBox, "Right click to delete");
            }
            else
            {
                mouseToolTip.SetToolTip(Tex3PictureBox, "Click to add");
            }
        }

        private void Tex4PictureBox_MouseHover(object sender, EventArgs e)
        {
            if (materials[selectedmaterial].Textures[3] != null)
            {
                mouseToolTip.SetToolTip(Tex4PictureBox, "Right click to delete");
            }
            else
            {
                mouseToolTip.SetToolTip(Tex4PictureBox, "Click to add");
            }
        }

        private void Tex5PictureBox_MouseHover(object sender, EventArgs e)
        {
            if (materials[selectedmaterial].Textures[4] != null)
            {
                mouseToolTip.SetToolTip(Tex5PictureBox, "Right click to delete");
            }
            else
            {
                mouseToolTip.SetToolTip(Tex5PictureBox, "Click to add");
            }
        }

        private void Tex6PictureBox_MouseHover(object sender, EventArgs e)
        {
            if (materials[selectedmaterial].Textures[5] != null)
            {
                mouseToolTip.SetToolTip(Tex6PictureBox, "Right click to delete");
            }
            else
            {
                mouseToolTip.SetToolTip(Tex6PictureBox, "Click to add");
            }
        }

        private void Tex7PictureBox_MouseHover(object sender, EventArgs e)
        {
            if (materials[selectedmaterial].Textures[6] != null)
            {
                mouseToolTip.SetToolTip(Tex7PictureBox, "Right click to delete");
            }
            else
            {
                mouseToolTip.SetToolTip(Tex7PictureBox, "Click to add");
            }
        }

        private void Tex8PictureBox_MouseHover(object sender, EventArgs e)
        {
            if (materials[selectedmaterial].Textures[7] != null)
            {
                mouseToolTip.SetToolTip(Tex8PictureBox, "Right click to delete");
            }
            else
            {
                mouseToolTip.SetToolTip(Tex8PictureBox, "Click to add");
            }
        }

        #endregion

        private void DeleteTexture(int ButtonID)
        {
            DeleteCheck(ButtonID);

            materials[selectedmaterial].TexCoord1Gens[ButtonID] = null;
            materials[selectedmaterial].TevOrders[ButtonID] = null;
            materials[selectedmaterial].TexMatrix1[ButtonID] = null;
            materials[selectedmaterial].TevStages[ButtonID] = null;
            materials[selectedmaterial].SwapModes[ButtonID] = null;
        }

        private void DeleteCheck(int ButtonID)
        {
            TextureHeader delet = null;
            foreach (TextureHeader texhed in texheader)
            {
                for (int i = 0; i < materials[selectedmaterial].Textures.Length; i++)
                {
                    if (texhed.Name == materials[selectedmaterial].Textures[ButtonID])
                    {
                        materials[selectedmaterial].Textures[ButtonID] = null;
                        foreach (Material m in materials)
                        {
                            for (int j = 0; j < m.Textures.Length; j++)
                            {
                                if (texhed.Name == m.Textures[j])
                                {
                                    return;
                                }
                            }
                        }
                        delet = texhed;
                    }
                }

            }
            texheader.Remove(delet);
        }

        private void LoadTexEditor(int buttonID)
        {
            if (materials[selectedmaterial].Textures[buttonID] == null)
            {
                if (materials[selectedmaterial].Textures[buttonID] == null)
                {
                    materials[selectedmaterial].TexCoord1Gens[buttonID] = Presets.Presets.BaseTexCoor1Gen;
                    materials[selectedmaterial].TevOrders[buttonID] = Presets.Presets.BaseTevOrder;
                    materials[selectedmaterial].TexMatrix1[buttonID] = Presets.Presets.BaseTexMatrix;
                    materials[selectedmaterial].SwapModes[buttonID] = Presets.Presets.BaseSwapMode;
                    if (buttonID == 0)
                    {
                        materials[selectedmaterial].TevStages[buttonID] = Presets.Presets.BaseFirstTevStage;
                    }
                    else
                    {
                        materials[selectedmaterial].TevStages[buttonID] = Presets.Presets.BaseTevStage;
                    }
                    texheader.Add(new TextureHeader { AttachPalette = 0, Name = "New_Texture", Format = TextureFormat.CMPR.ToString(), AlphaSetting = 0, WrapS = TextureWrap.ClampToEdge.ToString(), WrapT = TextureWrap.ClampToEdge.ToString(), MinFilter = TextureMinFilter.Linear.ToString(), MagFilter = TextureMagFilter.Linear.ToString(), MinLod = 0, MaxLod = 0 });
                }
                materials[selectedmaterial].Textures[buttonID] = "New_Texture";
            }
            TextureEditForm TexEditForm = new TextureEditForm(this, materials, texheader, selectedmaterial, buttonID, materials[selectedmaterial].Textures[buttonID]);
            TexEditForm.Show();
            Hide();
        }


        #region Keyboard Shortcuts
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
                OpenButton_Click(OpenButton, EventArgs.Empty);
            if (materials != null)
            {
                if (e.Control && e.KeyCode == Keys.S)
                    SaveButton_Click(SaveButton, EventArgs.Empty);
                if (e.Control && e.KeyCode == Keys.E)
                    ExportButton_Click(ExportButton, EventArgs.Empty);
                if (e.Control && e.KeyCode == Keys.T)
                    TEVStagesButton_Click(ExportButton, EventArgs.Empty);
                if (e.Control && e.KeyCode == Keys.I)
                    IndirectSettingsButton_Click(ExportButton, EventArgs.Empty);
                if (e.Control && e.KeyCode == Keys.U)
                    LoadTexEditor(0);
            }
        }
        #endregion

        private void IndirectSettingsButton_Click(object sender, EventArgs e)
        {
            IndirectForm IndForm = new IndirectForm(this, materials, selectedmaterial);
            IndForm.Show();
            Hide();
        }

        private void TEVStagesButton_Click(object sender, EventArgs e)
        {
            TEVStageForm TevForm = new TEVStageForm(this, materials, selectedmaterial);
            TevForm.Show();
            Hide();
        }
    }

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        /// <summary>
        /// Changes a ProgressBar's colour.
        /// </summary>
        /// <param name="pBar">The ProgressBar</param>
        /// <param name="state"> 1 = normal (green); 2 = error (red); 3 = warning (yellow)</param>
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
