﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using QuickType;
using DiscordRichPresence;

namespace SuperJSON
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CenterToScreen();
            this.Text = "SuperJSON - "+ Application.ProductVersion;
            MatListBox.Items.Add("No JSON loaded");
            MatListBox.Items.Add("-------------------------");
            MatListBox.Items.Add("SuperJSON Made by:");
            MatListBox.Items.Add("- Super Hackio");
            MatListBox.Items.Add("With help from:");
            MatListBox.Items.Add("- Gamma");
            MatListBox.Items.Add("- Yoshi2");
            MatListBox.Items.Add("- Riidefi");
            MatListBox.Items.Add("- SY24");
            MatListBox.Items.Add("-------------------------");
            MatListBox.Items.Add("Found a bug?");
            MatListBox.Items.Add("Let me know:");
            MatListBox.Items.Add("> Github Issues Page");
            MatListBox.Items.Add("> Discord Servers");
            MatListBox.Items.Add("     -Super Hackio INC");
            MatListBox.Items.Add("     -The Sunshine Hut");
            pictureboxs = new PictureBox[8] { Tex1PictureBox, Tex2PictureBox, Tex3PictureBox, Tex4PictureBox, Tex5PictureBox, Tex6PictureBox, Tex7PictureBox, Tex8PictureBox };
        }
        DRPC RP = new DRPC();


        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        ColorDialog clrDialog = new ColorDialog();
        ToolTip mouseToolTip = new ToolTip();

        FileStream fs;
        FileInfo fInfo;
        FileInfo aInfo;
        FileInfo sInfo;
        Bitmap TexDisplay = Properties.Resources.NoTexture;
        Bitmap resized;
        Rectangle TexDrawRect = new Rectangle(7, 19, 107, 64);

        public List<TextureHeader> texheader = new List<TextureHeader>();
        public List<Material> materials;
        List<Material> addingmaterials;
        List<TextureHeader> addingtexheader = new List<TextureHeader>();

        PictureBox[] pictureboxs;

        public int selectedmaterial = 0;
        public int selectedtexture = 0;
        public int cooldown = 0;
        public int selectedtexheader = 0;
        public bool working = false;
        public bool error = false;
        public bool opening = false;
        public bool makenew = false;
        public bool returned = false;
        public string FilePath;


        private void MainForm_Load(object sender, EventArgs e)
        {
            RP.Initialize();
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
                error = false;
                fInfo = new FileInfo(ofd.FileName);
                FilePath = fInfo.DirectoryName;
                opening = true;
                selectedmaterial = 0;
                //MatListBox.SelectedIndex = 0;
                MatListBox.Items.Clear();
                opening = false;
                LoadMatJson(false);
                if (error)
                    return;
                MatListBox.Items.Clear();

                foreach (var material in materials)
                {
                    SaveProgressBar.Increment(new Random().Next(1, 5));
                    MatListBox.Items.Add(material.Name);
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
                RemoveMatButton.Enabled = materials.Count > 1 ? true : false;
                //---------------------------------------------------------------------------------------------------------------------------------------
                LoadTexJson();
                RP.Update(MessageB:"Editing Materials");
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
            working = false;
            #region Texture Scanning
            for (int j = 0; j < MatListBox.Items.Count - 1; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    try
                    {
                        fs = new FileStream(sInfo.DirectoryName + "\\" + materials[j].Textures[i].Name + ".png", FileMode.Open, FileAccess.Read);
                        fs.Close();
                        SaveProgressBar.Increment(5);
                    }
                    catch (FileNotFoundException)
                    {
                        if (materials[j].Textures[i].Name != null)
                        {
                            error = true;
                            MessageBox.Show(materials[j].Textures[i].Name + ".png Does not exist!", "Warning!");
                            SetAppStatus(true);
                            return;
                        }

                    }
                }
                MatListBox.SelectedIndex++;

            }
            #endregion
            
            working = true;
            RP.Update(MessageB:"Exporting Materials");
            new ExportForm(jsonpath,textpath).ShowDialog();
            MatListBox.SelectedIndex = 0;
            
            //END
            SetAppStatus(true);
            ReloadImages();
            RP.Update(MessageB: "Editing Materials");
        }


        private void SetBaseTexHead(int current, bool contains, bool add = false)
        {
            if (!add)
            {
                foreach (Material mat in materials)
                {
                    foreach (TextureInfo texname in materials[current].Textures)
                    {
                        if (texheader != null && texheader.Count != 0)
                        {
                            contains = texheader.Any(p => p.Name == texname.Name);
                        }
                        if (texname.Name != null && !contains)
                        {
                            texheader.Add(new TextureHeader { AttachPalette = 0, Name = texname.Name, Format = TextureFormat.CMPR.ToString(), AlphaSetting = 0, WrapS = TextureWrap.ClampToEdge.ToString(), WrapT = TextureWrap.ClampToEdge.ToString(), MinFilter = TextureMinFilter.Linear.ToString(), MagFilter = TextureMagFilter.Linear.ToString(), MinLod = 0, MaxLod = 0 });
                        }
                    }
                    current++;
                }
            }
            else
            {
                foreach (Material mat in addingmaterials)
                {
                    foreach (TextureInfo texname in addingmaterials[current].Textures)
                    {
                        if (addingtexheader != null)
                        {
                            contains = addingtexheader.Any(p => p.Name == texname.Name);
                        }
                        if (texname.Name != null && !contains)
                        {
                            addingtexheader.Add(new TextureHeader { AttachPalette = 0, Name = texname.Name, Format = TextureFormat.CMPR.ToString(), AlphaSetting = 0, WrapS = TextureWrap.ClampToEdge.ToString(), WrapT = TextureWrap.ClampToEdge.ToString(), MinFilter = TextureMinFilter.Linear.ToString(), MagFilter = TextureMagFilter.Linear.ToString(), MinLod = 0, MaxLod = 0 });
                        }
                    }
                    current++;
                }
            }
            
        }

        public void LoadMatJson(bool add)
        {
            try
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
                        foreach (Material mat in addingmaterials)
                        {
                            mat.Textures = new TextureInfo[8];

                            for (int i = 0; i < 8; i++)
                            {
                                mat.Textures[i] = new TextureInfo { Name = null, TextureHeaderID = -1 };
                                mat.Textures[i].Name = mat.TextureInfo[i];
                            }
                        }
                        materials.AddRange(addingmaterials);
                    }
                    else
                    {
                        materials = JsonConvert.DeserializeObject<List<Material>>(json);
                        foreach (Material mat in materials)
                        {
                            mat.Textures = new TextureInfo[8];

                            for (int i = 0; i < 8; i++)
                            {
                                mat.Textures[i] = new TextureInfo { Name = null, TextureHeaderID = -1 };
                                mat.Textures[i].Name = mat.TextureInfo[i];
                            }
                        }
                    }
                    r.Close();
                }
            }
            catch (Exception e)
            {
                error = true;
                throw e;
            }
        }

        public void LoadTexJson(bool add = false)
        {
            var current = 0;
            bool contains = false;
            if (!add)
            {
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

                #region Assign IDs to each texture
                var IDCount = 0;
                foreach (TextureHeader t in texheader)
                {
                    t.ID = IDCount;
                    IDCount++;
                }

                foreach (Material mat in materials)
                {
                    foreach (TextureInfo texinfo in mat.Textures)
                    {
                        foreach (TextureHeader texhead in texheader)
                        {
                            if (texhead.Name == texinfo.Name)
                            {
                                texinfo.TextureHeaderID = texhead.ID;
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                addingtexheader.Clear();
                if (File.Exists(fInfo.DirectoryName + "\\" + fInfo.Name.Remove(fInfo.Name.Length - 5) + "_tex.json"))
                {
                    try
                    {
                        using (StreamReader r = new StreamReader(File.OpenRead(fInfo.DirectoryName + "\\" + fInfo.Name.Remove(fInfo.Name.Length - 5) + "_tex.json")))
                        {
                            string json = r.ReadToEnd();
                            addingtexheader = JsonConvert.DeserializeObject<List<TextureHeader>>(json);
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
                        addingtexheader.Clear();
                        SetBaseTexHead(current, contains, true);
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
                            addingtexheader = JsonConvert.DeserializeObject<List<TextureHeader>>(json);
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
                        addingtexheader.Clear();
                        SetBaseTexHead(current, contains, true);
                        error = false;
                    }
                }
                else
                {
                    SetBaseTexHead(current, contains, true);
                }

                #region Assign IDs to each texture
                var IDCount = texheader.Count;
                foreach (TextureHeader t in addingtexheader)
                {
                    t.ID = IDCount;
                    IDCount++;
                }

                foreach (Material mat in materials)
                {
                    foreach (TextureInfo texinfo in mat.Textures)
                    {
                        foreach (TextureHeader texhead in addingtexheader)
                        {
                            if (texhead.Name == texinfo.Name)
                            {
                                texinfo.TextureHeaderID = texhead.ID;
                            }
                        }
                    }
                }
                #endregion
                texheader.AddRange(addingtexheader);
                #region Copy All Textures
                List<string> copyme = new List<string>();
                foreach (TextureHeader tex in addingtexheader)
                {
                    contains = copyme.Any(p => p == tex.Name);
                    if (tex.Name != null && !contains)
                    {
                        copyme.Add(tex.Name);
                    }

                }
                CopyImage(copyme, fInfo.DirectoryName);
                #endregion
            }

            RemovDuplicateTextures();
        }

        public void CopyImage(List<string> ImageNames, string OGFilePath)
        {
            foreach (string Name in ImageNames)
            {
                if (File.Exists(OGFilePath + "\\" + Name + ".png")&&!File.Exists(aInfo.DirectoryName+"\\" + Name + ".png"))
                {
                    try
                    {
                        File.Copy(OGFilePath + "\\" + Name + ".png", aInfo.DirectoryName + "\\" + Name + ".png", false);
                    }
                    catch (Exception)
                    {
                        throw new UnauthorizedAccessException("There was an error reading/writing " + Name + ".png");
                    }
                    
                }
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
            TEVIDNumericUpDown.Enabled = trigger;
            TEVRNumericUpDown.Enabled = trigger;
            TEVGNumericUpDown.Enabled = trigger;
            TEVBNumericUpDown.Enabled = trigger;
            TEVANumericUpDown.Enabled = trigger;
            KONSTColComboBox.Enabled = trigger;
            KONSTColButton.Enabled = trigger;
            KONSTNumericUpDown.Enabled = trigger;
            KONSTColTextBox.Enabled = trigger;
            TEVStagesButton.Enabled = trigger;
            IndirectSettingsButton.Enabled = trigger;
            SwapSettingsButton.Enabled = trigger;

            AddMatButton.Enabled = trigger;
            foreach (var picturebox in pictureboxs)
            {
                picturebox.Enabled = trigger;
            }
            if (trigger)
            {
                SaveProgressBar.Value = 0;
                RemoveMatButton.Enabled = materials.Count > 1 ? true : false;
            }
            else
            {
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
                    fs = new FileStream(FilePath + "\\" + materials[selectedmaterial].Textures[loadtextint].Name + ".png", FileMode.Open, FileAccess.Read);
                    TexDisplay = (Bitmap)Image.FromStream(fs);
                    fs.Close();
                    TexDisplay = ResizeImage(TexDisplay); // Shrink it
                }
                catch (FileNotFoundException)
                {
                    TexDisplay = materials[selectedmaterial].Textures[loadtextint].Name == null ? Properties.Resources.NoTexture : Properties.Resources.MissingTexture; //Missing Texture
                }
                picturebox.Image = TexDisplay;
                if (materials[selectedmaterial].Textures[loadtextint].Name == null)
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

            if (lastint == -1)
                return;

            if ((lastint != 0 && lastint != 7 && lastint != 8) && (pictureboxs[lastint - 1].Enabled == true && pictureboxs[lastint + 1].Enabled == true))
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
                        materials[selectedmaterial].TextureInfo[i] = materials[selectedmaterial].TextureInfo[i + 1];
                        materials[selectedmaterial].TexCoord1Gens[i] = materials[selectedmaterial].TexCoord1Gens[i + 1];
                        materials[selectedmaterial].TevOrders[i] = materials[selectedmaterial].TevOrders[i + 1];
                        materials[selectedmaterial].TexMatrix1[i] = materials[selectedmaterial].TexMatrix1[i + 1];
                        materials[selectedmaterial].TevStages[i] = materials[selectedmaterial].TevStages[i + 1];
                        materials[selectedmaterial].SwapModes[i] = materials[selectedmaterial].SwapModes[i + 1];
                    }
                    materials[selectedmaterial].Textures[7].Name = null;
                    materials[selectedmaterial].Textures[7].TextureHeaderID = -1;
                    materials[selectedmaterial].TextureInfo[7] = null;
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
            TEVIDNumericUpDown.Value = 1;
            TEVIDNumericUpDown.Value = 0;
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
                error = false;
                aInfo = fInfo;
                fInfo = new FileInfo(ofd.FileName);
                FilePath = fInfo.DirectoryName;
                LoadMatJson(true);
                if (error)
                    return;
                foreach (var material in addingmaterials)
                {
                    MatListBox.Items.Add(material.Name);
                }
                RemoveMatButton.Enabled = true;
                //---------------------------------------------------------------------------------------------------------------------------------------
                LoadTexJson(true);
                fInfo = aInfo;
                FilePath = fInfo.DirectoryName;
            }
        }

        private void RemoveMatButton_Click(object sender, EventArgs e)
        {
            MatListBox.Enabled = false;
            SaveTimer.Start();
            var check = 0;
            foreach (string tex in materials[selectedmaterial].TextureInfo)
            {
                if (tex != null)
                {
                    foreach (TextureInfo inf in materials[selectedmaterial].Textures)
                    {
                        for (int i = 0; i < texheader.Count; i++)
                        {
                            if (texheader[i] != null && (tex == inf.Name && inf.TextureHeaderID == texheader[i].ID))
                            {
                                DeleteTexture(check);
                                check++;
                            }
                        }
                    }
                }
                
            }
            for (int i = 0; i < texheader.Count; i++)
            {
                if (texheader[i] == null)
                {
                    texheader.RemoveAt(i);
                }
            }
            var newid = 0;
            foreach (var newt in texheader)
            {
                if (newt != null)
                {
                    newt.ID = newid;
                }
                newid++;
            }
            for (int i = 0; i < texheader.Count; i++)
            {
                if (texheader[i] == null)
                {
                    texheader.RemoveAt(i);
                }
            }
            materials.RemoveAt(selectedmaterial);
            #region Assign IDs to each texture
            var IDCount = 0;
            foreach (TextureHeader t in texheader)
            {
                t.ID = IDCount;
                IDCount++;
            }

            foreach (Material mat in materials)
            {
                foreach (TextureInfo texinfo in mat.Textures)
                {
                    foreach (TextureHeader texhead in texheader)
                    {
                        if (texhead.Name == texinfo.Name)
                        {
                            texinfo.TextureHeaderID = texhead.ID;
                        }
                    }
                }
            }
            #endregion
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
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].R = Math.Round((double)clrDialog.Color.R / 255, 7);
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].G = Math.Round((double)clrDialog.Color.G / 255, 7);
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].B = Math.Round((double)clrDialog.Color.B / 255, 7);
                materials[selectedmaterial].MaterialColors[MatColComboBox.SelectedIndex].A = Math.Round((double)clrDialog.Color.A / 255, 7);
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

        private void KONSTColTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].R = Math.Round((double)Convert.ToInt16(KONSTColTextBox.Text.Substring(0, 2), 16) / 255, 7);
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].G = Math.Round((double)Convert.ToInt16(KONSTColTextBox.Text.Substring(2, 2), 16) / 255, 7);
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].B = Math.Round((double)Convert.ToInt16(KONSTColTextBox.Text.Substring(4, 2), 16) / 255, 7);
                materials[selectedmaterial].KonstColors[KONSTColComboBox.SelectedIndex].A = Math.Round((double)Convert.ToInt16(KONSTColTextBox.Text.Substring(6, 2), 16) / 255, 7);
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

        //TEV
        private void TEVIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            opening = true;
            TEVRNumericUpDown.Value = ((decimal)materials[selectedmaterial].TevColors[(int)TEVIDNumericUpDown.Value].R) * 255;
            TEVGNumericUpDown.Value = ((decimal)materials[selectedmaterial].TevColors[(int)TEVIDNumericUpDown.Value].G) * 255;
            TEVBNumericUpDown.Value = ((decimal)materials[selectedmaterial].TevColors[(int)TEVIDNumericUpDown.Value].B) * 255;
            TEVANumericUpDown.Value = ((decimal)materials[selectedmaterial].TevColors[(int)TEVIDNumericUpDown.Value].A) * 255;
            opening = false;
        }

        private void TEVRNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(!opening)
            materials[selectedmaterial].TevColors[(int)TEVIDNumericUpDown.Value].R = ((double)TEVRNumericUpDown.Value / 255);
        }

        private void TEVGNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!opening)
                materials[selectedmaterial].TevColors[(int)TEVIDNumericUpDown.Value].G = ((double)TEVGNumericUpDown.Value / 255);
        }

        private void TEVBNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!opening)
                materials[selectedmaterial].TevColors[(int)TEVIDNumericUpDown.Value].B = ((double)TEVBNumericUpDown.Value / 255);
        }

        private void TEVANumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!opening)
                materials[selectedmaterial].TevColors[(int)TEVIDNumericUpDown.Value].A = ((double)TEVANumericUpDown.Value / 255);
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
            if (materials[selectedmaterial].Textures[0].Name != null)
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
            if (materials[selectedmaterial].Textures[1].Name != null)
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
            if (materials[selectedmaterial].Textures[2].Name != null)
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
            if (materials[selectedmaterial].Textures[3].Name != null)
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
            if (materials[selectedmaterial].Textures[4].Name != null)
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
            if (materials[selectedmaterial].Textures[5].Name != null)
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
            if (materials[selectedmaterial].Textures[6].Name != null)
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
            if (materials[selectedmaterial].Textures[7].Name != null)
            {
                mouseToolTip.SetToolTip(Tex8PictureBox, "Right click to delete");
            }
            else
            {
                mouseToolTip.SetToolTip(Tex8PictureBox, "Click to add");
            }
        }

        #endregion

        private bool CheckTexture()
        {
            new SelectHeaderForm(this,texheader).ShowDialog();
            return makenew;
        }

        private void RemovDuplicateTextures(int CheckFirst = 0)
        {
            for (int j = CheckFirst; j < texheader.Count; j++)
            {
                for (int i = texheader.Count-1; i > 0; i--)
                {
                    if ((texheader[j].Name == texheader[i].Name) && (texheader[j].ID != texheader[i].ID) && i != j)
                    {
                        texheader.RemoveAt(i);
                    }
                }
            }
            var newid = 0;
            foreach (var newt in texheader)
            {
                if (newt != null)
                {
                    newt.ID = newid;
                }
                newid++;
            }
        }

        private void DeleteTexture(int ButtonID)
        {
            DeleteCheck(ButtonID);

            materials[selectedmaterial].TexCoord1Gens[ButtonID] = null;
            materials[selectedmaterial].TevOrders[ButtonID] = null;
            materials[selectedmaterial].TexMatrix1[ButtonID] = null;
            materials[selectedmaterial].TevStages[ButtonID] = null;
            materials[selectedmaterial].SwapModes[ButtonID] = null;
            materials[selectedmaterial].SwapTables[ButtonID] = null;
        }

        private void DeleteCheck(int ButtonID)
        {
            int threatenedTexheader = materials[selectedmaterial].Textures[ButtonID].TextureHeaderID;

            materials[selectedmaterial].TextureInfo[ButtonID] = null;

            var count = -1;
            foreach (Material ma in materials)
            {
                foreach (TextureInfo ti in ma.Textures)
                {
                    if (ti.TextureHeaderID == threatenedTexheader)
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                if (threatenedTexheader > texheader.Count-1)
                {
                    threatenedTexheader = texheader.Count - 1;
                }
                texheader[threatenedTexheader] = null;
            }

            materials[selectedmaterial].Textures[ButtonID].Name = null;
            materials[selectedmaterial].Textures[ButtonID].TextureHeaderID = -1;

        }

        private void LoadTexEditor(int buttonID)
        {
            if (materials[selectedmaterial].Textures[buttonID].Name == null)
            {
                materials[selectedmaterial].TexCoord1Gens[buttonID] = materials[selectedmaterial].TexCoord1Gens[buttonID] ?? new TexCoord1Gen { Type = TexGenType.Matrix2x4.ToString(), Source = "Tex0", TexMatrixSource = TexMatrix.Identity.ToString() };
                materials[selectedmaterial].TevOrders[buttonID] = materials[selectedmaterial].TevOrders[buttonID] ?? new MaterialTevOrder { TexCoord = TexCoord.TexCoord0.ToString(), TexMap = TexMap.TexMap0.ToString(), ChannelId = "color0A0" };
                materials[selectedmaterial].TexMatrix1[buttonID] = materials[selectedmaterial].TexMatrix1[buttonID] ?? new TexMatrix1 { Projection = "Matrix2x4", Type = 0, EffectTranslation = new double[3] { 0.0, 0.0, 0.0 }, Scale = new double[2] { 0.0, 0.0 }, Rotation = 0.0, Translation = new double[2] { 0.0, 0.0 }, ProjectionMatrix = new double[4][] { new double[4] { 1.0, 0.0, 0.0, 0.0 }, new double[4] { 0.0, 1.0, 0.0, 0.0 }, new double[4] { 0.0, 0.0, 1.0, 0.0 }, new double[4] { 0.0, 0.0, 0.0, 1.0 } } };
                materials[selectedmaterial].SwapModes[buttonID] = materials[selectedmaterial].SwapModes[buttonID] ?? new SwapMode { RasSel = 0, TexSel = 0 };
                materials[selectedmaterial].SwapTables[buttonID] = materials[selectedmaterial].SwapTables[buttonID] ?? new SwapTable { R = 0, G = 1, B = 2, A = 3 };
                if (buttonID == 0)
                {
                    materials[selectedmaterial].TevStages[buttonID] = materials[selectedmaterial].TevStages[buttonID] ?? new MaterialTevStage { ColorInA = "Zero", ColorInB = "Zero", ColorInC = "Zero", ColorInD = "TexColor", ColorOp = "Add", ColorBias = "Zero", ColorScale = TevScale.Scale_1.ToString(), ColorClamp = true, ColorRegId = "TevPrev", AlphaInA = "TexAlpha", AlphaInB = "Zero", AlphaInC = "Zero", AlphaInD = "Zero", AlphaOp = "Add", AlphaBias = "Zero", AlphaScale = TevScale.Scale_1.ToString(), AlphaClamp = true, AlphaRegId = "TevPrev" };
                }
                else
                {
                    materials[selectedmaterial].TevStages[buttonID] = materials[selectedmaterial].TevStages[buttonID] ?? new MaterialTevStage { ColorInA = "Zero", ColorInB = "Texcolor", ColorInC = "ColorPrev", ColorInD = "Zero", ColorOp = "Add", ColorBias = "Zero", ColorScale = TevScale.Scale_1.ToString(), ColorClamp = true, ColorRegId = "TevPrev", AlphaInA = "TexAlpha", AlphaInB = "Zero", AlphaInC = "Zero", AlphaInD = "Zero", AlphaOp = "Add", AlphaBias = "Zero", AlphaScale = TevScale.Scale_1.ToString(), AlphaClamp = true, AlphaRegId = "TevPrev" };
                }

                if (CheckTexture())
                {
                    if (!returned)
                    {
                        return;
                    }
                    texheader.Add(new TextureHeader { AttachPalette = 0, Name = "New_Texture"+ texheader.Count, ID = texheader.Count, Format = TextureFormat.CMPR.ToString(), AlphaSetting = 0, WrapS = TextureWrap.ClampToEdge.ToString(), WrapT = TextureWrap.ClampToEdge.ToString(), MinFilter = TextureMinFilter.Linear.ToString(), MagFilter = TextureMagFilter.Linear.ToString(), MinLod = 0, MaxLod = 0 });

                    materials[selectedmaterial].Textures[buttonID].Name = "New_Texture"+ (texheader.Count-1);
                    materials[selectedmaterial].Textures[buttonID].TextureHeaderID = texheader.Count - 1;
                    makenew = false;

                    returned = false;
                }
                else
                {
                    if (!returned)
                    {
                        return;
                    }
                    materials[selectedmaterial].TextureInfo[buttonID] = texheader[selectedtexheader].Name;
                    materials[selectedmaterial].Textures[buttonID].Name = texheader[selectedtexheader].Name;
                    materials[selectedmaterial].Textures[buttonID].TextureHeaderID = texheader[selectedtexheader].ID;

                    returned = false;
                }

            }
            TextureEditForm TexEditForm = new TextureEditForm(this, materials, texheader, selectedmaterial, buttonID, materials[selectedmaterial].Textures[buttonID].Name);
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

        private void SwapSettingsButton_Click(object sender, EventArgs e)
        {
            SwapTableForm SwapForm = new SwapTableForm(this, selectedmaterial, materials);
            SwapForm.Show();
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
