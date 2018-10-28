using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuickType;

namespace SuperJSON
{
    public partial class SelectHeaderForm : Form
    {
        public SelectHeaderForm(MainForm m, List<TextureHeader> fullist)
        {
            InitializeComponent();
            CenterToScreen();
            TextureSettingsComboBox.Items.Add("New Texture");
            TextureSettingsComboBox.SelectedIndex = 0;
            foreach (TextureHeader txt in fullist)
            {
                TextureSettingsComboBox.Items.Add(txt.Name);
            }
            main = m;
        }

        MainForm main;

        private void TextureSettingsComboBox_SelectedIndexChanged(object sender, EventArgs e) => AddTextureSettingsButton.Text = "Use " + TextureSettingsComboBox.SelectedItem.ToString() + " for this texture";

        private void AddTextureSettingsButton_Click(object sender, EventArgs e)
        {
            main.makenew = TextureSettingsComboBox.SelectedItem.ToString() == "New Texture" ? true : false;
            if (!main.makenew)
            {
                main.selectedtexheader = TextureSettingsComboBox.SelectedIndex-1;
            }
            main.returned = true;
            Close();
            Dispose();
        }
    }
}
