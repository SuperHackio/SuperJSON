using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuickType;

namespace SuperJSON
{
    public partial class SelectTextureForm : Form
    {
        public SelectTextureForm(TextureEditForm returnhere, List<TextureHeader> fullist, List<TextureHeader> options, int texturetoreplace)
        {
            InitializeComponent();
            CenterToScreen();
            replace = texturetoreplace;
            FormBefore = returnhere;
            TextureList = fullist;
            AddingTextureList = options;
            var autoselect = 0;
            var count = 0;
            foreach (TextureHeader txt in AddingTextureList)
            {
                TextureSettingsComboBox.Items.Add(txt.Name);
            }
            foreach (var item in TextureSettingsComboBox.Items)
            {
                if (item.ToString() == TextureList[replace].Name)
                {
                    autoselect = count;
                }
                count++;
            }
            TextureSettingsComboBox.SelectedIndex = autoselect;
        }

        int replace;
        TextureEditForm FormBefore;
        List<TextureHeader> AddingTextureList;
        List<TextureHeader> TextureList;

        private void TextureSettingsComboBox_SelectedIndexChanged(object sender, EventArgs e) => AddTextureSettingsButton.Text = "Add " + TextureSettingsComboBox.SelectedItem.ToString() + " to Project";

        private void button1_Click(object sender, EventArgs e)
        {
            TextureList[replace] = AddingTextureList[TextureSettingsComboBox.SelectedIndex];
            FormBefore.TextureList = this.TextureList;
            Close();
            Dispose();
        }
        
    }
}
