using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using QuickType;

namespace SuperJSON
{
    public partial class TextureEditForm : Form
    {
        public TextureEditForm(MainForm Mainform, List<Material> materiallist, List<TextureHeader> texhead, int selectedmaterial, int selectedtexture, string name)
        {
            InitializeComponent();
            CenterToScreen();
            this.FormClosing += TextureEditForm_FormClosing;
            MainWindow = Mainform;
            MaterialList = materiallist;
            TextureList = texhead;
            SelectedMaterial = selectedmaterial;
            SelectedTexture = selectedtexture;

            var v = 0;
            foreach (TextureHeader t in TextureList)
            {
                if (name == t.Name)
                {
                    SelectedTexture = v;
                }
                v++;
            }
            //---------------------------------------------------------------------------------------------------------------------------------------
            TexFormatComboBox.DataSource = Enum.GetValues(typeof(TextureFormat));
            WrapSComboBox.DataSource = Enum.GetValues(typeof(TextureWrap));
            WrapTComboBox.DataSource = Enum.GetValues(typeof(TextureWrap));
            MinComboBox.DataSource = Enum.GetValues(typeof(TextureMinFilter));
            MagComboBox.DataSource = Enum.GetValues(typeof(TextureMagFilter));
            //---------------------------------------------------------------------------------------------------------------------------------------
            LoadTextureSettings();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        ToolTip TextureToolTip = new ToolTip();
        MainForm MainWindow;
        List<Material> MaterialList;
        public List<TextureHeader> TextureList;
        List<TextureHeader> AddingTextureList;
        int SelectedMaterial;
        int SelectedTexture;

        public void SaveTextureHeader()
        {
            TextureList[SelectedTexture].Name = TexNameTextBox.Text;
            TextureList[SelectedTexture].AlphaSetting = (int)AlphaNumericUpDown.Value;
            TextureList[SelectedTexture].AttachPalette = Convert.ToInt32(AttachPaletteCheckBox.Checked);
            TextureList[SelectedTexture].Format = TexFormatComboBox.SelectedItem.ToString();
            TextureList[SelectedTexture].WrapS = WrapSComboBox.SelectedItem.ToString();
            TextureList[SelectedTexture].WrapT = WrapTComboBox.SelectedItem.ToString();
            TextureList[SelectedTexture].MinFilter = MinComboBox.SelectedItem.ToString();
            TextureList[SelectedTexture].MagFilter = MagComboBox.SelectedItem.ToString();
            TextureList[SelectedTexture].MinLod = (int)LODMinNumericUpDown.Value;
            TextureList[SelectedTexture].MaxLod = (int)LODMagNumericUpDown.Value;
            TextureList[SelectedTexture].LodBias = (int)LODMinNumericUpDown.Value;
        }

        public void RecalculateImageSize()
        {
            //I plan to have something here in the future
        }

        public void LoadTextureSettings()
        {
            TexNameTextBox.Text = TextureList[SelectedTexture].Name;
            //---------------------------------------------------------------------------------------------------------------------------------------
            TextureFormat txtfm;
            TextureWrap txtwr;
            TextureMinFilter txtmin;
            TextureMagFilter txtmag;
            //------------------------------------------------------------
            try
            {
                if (TextureList[SelectedTexture] == null)
                {
                    SelectedTexture = 0;
                }
            }
            catch (Exception)
            {
                SelectedTexture = 0;
            }
            Enum.TryParse<TextureFormat>(TextureList[SelectedTexture].Format, out txtfm);
            TexFormatComboBox.SelectedItem = txtfm;
            Enum.TryParse<TextureWrap>(TextureList[SelectedTexture].WrapS, out txtwr);
            WrapSComboBox.SelectedItem = txtwr;
            Enum.TryParse<TextureWrap>(TextureList[SelectedTexture].WrapT, out txtwr);
            WrapTComboBox.SelectedItem = txtwr;
            Enum.TryParse<TextureMinFilter>(TextureList[SelectedTexture].MinFilter, out txtmin);
            MinComboBox.SelectedItem = txtmin;
            Enum.TryParse<TextureMagFilter>(TextureList[SelectedTexture].MagFilter, out txtmag);
            MagComboBox.SelectedItem = txtmag;

            AlphaNumericUpDown.Value = TextureList[SelectedTexture].AlphaSetting;
            LODMinNumericUpDown.Value = TextureList[SelectedTexture].MinLod;
            LODMagNumericUpDown.Value = TextureList[SelectedTexture].MaxLod;
            AttachPaletteCheckBox.Checked = TextureList[SelectedTexture].AttachPalette == 1;
        }


        private void TexEditCloseButton_Click(object sender, EventArgs e)
        {
            MainWindow.Show();
            Close();
            Dispose();
        }

        private void TextureEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            //---------------------------------------------------------------------------------------------------------------------------------------
            #region Saving

            #endregion
            //---------------------------------------------------------------------------------------------------------------------------------------
            MainWindow.materials = MaterialList;
            MainWindow.Show();
            MainWindow.ReloadImages();
        }

        private void TexNameTextBox_TextChanged(object sender, EventArgs e)
        {
            TexNameTextBox.Text = TexNameTextBox.Text.Replace(' ', '_');
            TextureList[SelectedTexture].Name = TexNameTextBox.Text;
        }

        private void OpenTextureButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Portable Network Graphic (*.png)|*.png";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            //PNG boiz
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                TexNameTextBox.Text = new FileInfo(ofd.FileName).Name;
                if (!File.Exists(MainWindow.FilePath + "\\" + TexNameTextBox.Text))
                {
                    File.Copy(ofd.FileName, MainWindow.FilePath + "\\" + TexNameTextBox.Text, false);
                }
                TexNameTextBox.Text = TexNameTextBox.Text.Remove(TexNameTextBox.Text.Length - 4);
            }
        }

        private void OpenTextureButton_MouseHover(object sender, EventArgs e) => TextureToolTip.SetToolTip(OpenTextureButton, "Select Texture");

        private void TexFormatComboBox_SelectedIndexChanged(object sender, EventArgs e) => RecalculateImageSize();

        private void TexFormatComboBox_MouseHover(object sender, EventArgs e) {
            switch (TexFormatComboBox.SelectedItem.ToString())
            {
                case "I4":
                    TextureToolTip.SetToolTip(TexFormatComboBox, "Greyscale");
                    break;
                case "I8":
                    TextureToolTip.SetToolTip(TexFormatComboBox, "Wide Greyscale");
                    break;
                case "IA4":
                    TextureToolTip.SetToolTip(TexFormatComboBox, "Greyscale + Alpha");
                    break;
                case "IA8":
                    TextureToolTip.SetToolTip(TexFormatComboBox, "Wide Greyscale + Aplha");
                    break;
                case "RGB565":
                    TextureToolTip.SetToolTip(TexFormatComboBox, "Colour");
                    break;
                case "RGB5A3":
                    TextureToolTip.SetToolTip(TexFormatComboBox, "Colour + Alpha");
                    break;
                case "RGBA32":
                    TextureToolTip.SetToolTip(TexFormatComboBox, "Wide Colour + Alpha");
                    break;
                case "CMPR":
                    TextureToolTip.SetToolTip(TexFormatComboBox, "Compressed");
                    break;
                default:
                    break;
            }
        }

        private void WrapSComboBox_MouseHover(object sender, EventArgs e)
        {
            switch (WrapSComboBox.SelectedItem.ToString())
            {
                case "ClampToEdge":
                    TextureToolTip.SetToolTip(WrapSComboBox, "Texture won't repeat");
                    break;
                case "Repeat":
                    TextureToolTip.SetToolTip(WrapSComboBox, "Texture will repeat");
                    break;
                case "MirroredRepeat":
                    TextureToolTip.SetToolTip(WrapSComboBox, "Texture will repeat after inverting");
                    break;
                default:
                    break;
            }
        }

        private void WrapTComboBox_MouseHover(object sender, EventArgs e)
        {
            switch (WrapTComboBox.SelectedItem.ToString())
            {
                case "ClampToEdge":
                    TextureToolTip.SetToolTip(WrapTComboBox, "Texture won't repeat");
                    break;
                case "Repeat":
                    TextureToolTip.SetToolTip(WrapTComboBox, "Texture will repeat");
                    break;
                case "MirroredRepeat":
                    TextureToolTip.SetToolTip(WrapTComboBox, "Texture will repeat after inverting");
                    break;
                default:
                    break;
            }
        }

        private void SwitchRightButton_Click(object sender, EventArgs e)
        {
            SelectedTexture++;
            if (SelectedTexture > TextureList.Count - 1)
            {
                SelectedTexture = 0;
            }
            LoadTextureSettings();
        }

        private void SwitchLeftButton_Click(object sender, EventArgs e)
        {
            SelectedTexture--;
            if (SelectedTexture < 0)
            {
                SelectedTexture = TextureList.Count - 1;
            }
            LoadTextureSettings();
        }

        private void OpenTexHeaderButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "SuperBMD Texture settings (*.json)|*.json";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            //JSON again boiz
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                using (StreamReader r = new StreamReader(File.OpenRead(ofd.FileName)))
                {
                    string json = r.ReadToEnd();
                    AddingTextureList = JsonConvert.DeserializeObject<List<TextureHeader>>(json);
                    foreach (TextureHeader th in AddingTextureList)
                    {
                        if (th.Format == null)
                        {
                            MessageBox.Show("This is not a Texure Header JSON!","No U");
                            return;
                        }
                    }
                    new SelectTextureForm(this, TextureList, AddingTextureList, SelectedTexture).ShowDialog();
                    LoadTextureSettings();
                }
            }
        }
    }
}
