using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using QuickType;

namespace SuperJSON
{
    public partial class TEVStageForm : Form
    {
        public TEVStageForm(MainForm Mainform, List<Material> materiallist, int selectedmaterial)
        {
            InitializeComponent();
            CenterToScreen();
            this.FormClosing += TEVStageForm_FormClosing;
            MainWindow = Mainform;
            MaterialList = materiallist;
            SelectedMaterial = selectedmaterial;
            //---------------------------------------------------------------------------------------------------------------------------------------
            #region Databinding
            ColInAComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.CombineColorInput));
            ColInBComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.CombineColorInput));
            ColInCComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.CombineColorInput));
            ColInDComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.CombineColorInput));
            ColOPComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.ColourOperator));
            ColBiasComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.TevBias));
            ColScaleComboBox.DataSource = Enum.GetValues(typeof(TevScale));
            ColRegIDComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.TevRegisterId));
            //------------------------------------------------------------------------------------------------------
            AlphaInAComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.CombineAlphaInput));
            AlphaInBComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.CombineAlphaInput));
            AlphaInCComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.CombineAlphaInput));
            AlphaInDComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.CombineAlphaInput));
            AlphaOPComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.AlphaOperator));
            AlphaBiasComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.TevBias));
            AlphaScaleComboBox.DataSource = Enum.GetValues(typeof(TevScale));
            AlphaRegIDComboBox.DataSource = Enum.GetValues(typeof(Presets.Presets.TevRegisterId));
            #endregion
            //---------------------------------------------------------------------------------------------------------------------------------------
            var count = 0;
            foreach (var TevStage in MaterialList[selectedmaterial].TevStages)
            {
                if (TevStage != null)
                {
                    TEVStageIDComboBox.Items.Add("TEV Stage "+count);
                }
                else
                {
                    TEVStageIDComboBox.Items.Add("TEV Stage " + count + " (Empty)");
                }
                count++;
            }
            TEVStageIDComboBox.SelectedIndex = 0;
            SelectedStage = 0;
            startup = false;
        }

        OpenFileDialog ofd = new OpenFileDialog();
        MainForm MainWindow;
        List<Material> MaterialList;
        int SelectedMaterial;
        int SelectedStage;
        bool startup = true;

        Presets.Presets.CombineColorInput colin;
        Presets.Presets.CombineAlphaInput alphin;
        Presets.Presets.ColourOperator Coperate;
        Presets.Presets.AlphaOperator Aoperate;
        Presets.Presets.TevBias bias;
        TevScale scale;
        Presets.Presets.TevRegisterId regID;

        private void TEVStageIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex] == null)
            {
                if (TEVStageIDComboBox.SelectedIndex == 0)
                {
                    MaterialList[SelectedMaterial].TevStages[0] = Presets.Presets.BaseFirstTevStage;
                    TEVStageIDComboBox.Items[TEVStageIDComboBox.SelectedIndex] = "TEV Stage 0";
                }
                else
                {
                    MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex] = Presets.Presets.BaseTevStage;
                    TEVStageIDComboBox.Items[TEVStageIDComboBox.SelectedIndex] = "TEV Stage "+ TEVStageIDComboBox.SelectedIndex;
                }
            }
            if (!startup && MaterialList[SelectedMaterial].TevStages[SelectedStage] != null)
            {
                #region Saving
                MaterialList[SelectedMaterial].TevStages[SelectedStage].ColorInA = ColInAComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].ColorInB = ColInBComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].ColorInC = ColInCComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].ColorInD = ColInDComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].ColorOp = ColOPComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].ColorBias = ColOPComboBox.Enabled ? ColBiasComboBox.SelectedItem.ToString() : "Add";
                MaterialList[SelectedMaterial].TevStages[SelectedStage].ColorScale = ColScaleComboBox.Enabled ? ColScaleComboBox.SelectedItem.ToString() : "Scale_1";
                MaterialList[SelectedMaterial].TevStages[SelectedStage].ColorRegId = ColRegIDComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].ColorClamp = ColClampCheckBox.Checked;
                //---------------------------------------------------------------------------------------------------------------------------------------
                MaterialList[SelectedMaterial].TevStages[SelectedStage].AlphaInA = AlphaInAComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].AlphaInB = AlphaInBComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].AlphaInC = AlphaInCComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].AlphaInD = AlphaInDComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].AlphaOp = AlphaOPComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].AlphaBias = AlphaOPComboBox.Enabled ? AlphaBiasComboBox.SelectedItem.ToString() : "Add";
                MaterialList[SelectedMaterial].TevStages[SelectedStage].AlphaScale = AlphaScaleComboBox.Enabled ? AlphaScaleComboBox.SelectedItem.ToString() : "Scale_1";
                MaterialList[SelectedMaterial].TevStages[SelectedStage].AlphaRegId = AlphaRegIDComboBox.SelectedItem.ToString();
                MaterialList[SelectedMaterial].TevStages[SelectedStage].AlphaClamp = AlphaClampCheckBox.Checked;
                #endregion
            }
            //---------------------------------------------------------------------------------------------------------------------------------------
            #region Colour Parsing
            Enum.TryParse<Presets.Presets.CombineColorInput>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorInA, out colin);
            ColInAComboBox.SelectedItem = colin;
            Enum.TryParse<Presets.Presets.CombineColorInput>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorInB, out colin);
            ColInBComboBox.SelectedItem = colin;
            Enum.TryParse<Presets.Presets.CombineColorInput>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorInC, out colin);
            ColInCComboBox.SelectedItem = colin;
            Enum.TryParse<Presets.Presets.CombineColorInput>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorInD, out colin);
            ColInDComboBox.SelectedItem = colin;
            Enum.TryParse<Presets.Presets.ColourOperator>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorOp, out Coperate);
            ColOPComboBox.SelectedItem = Coperate;
            Enum.TryParse<Presets.Presets.TevBias>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorBias, out bias);
            ColBiasComboBox.SelectedItem = bias;
            Enum.TryParse<TevScale>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorScale, out scale);
            ColScaleComboBox.SelectedItem = scale;
            Enum.TryParse<Presets.Presets.TevRegisterId>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorRegId, out regID);
            ColRegIDComboBox.SelectedItem = regID;
            ColClampCheckBox.Checked = MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorClamp;
            #endregion
            //---------------------------------------------------------------------------------------------------------------------------------------
            #region Aplha Parsing
            Enum.TryParse<Presets.Presets.CombineAlphaInput>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaInA, out alphin);
            AlphaInAComboBox.SelectedItem = alphin;
            Enum.TryParse<Presets.Presets.CombineAlphaInput>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaInB, out alphin);
            AlphaInBComboBox.SelectedItem = alphin;
            Enum.TryParse<Presets.Presets.CombineAlphaInput>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaInC, out alphin);
            AlphaInCComboBox.SelectedItem = alphin;
            Enum.TryParse<Presets.Presets.CombineAlphaInput>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaInD, out alphin);
            AlphaInDComboBox.SelectedItem = alphin;
            Enum.TryParse<Presets.Presets.AlphaOperator>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaOp, out Aoperate);
            AlphaOPComboBox.SelectedItem = Coperate;
            Enum.TryParse<Presets.Presets.TevBias>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaBias, out bias);
            AlphaBiasComboBox.SelectedItem = bias;
            Enum.TryParse<TevScale>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaScale, out scale);
            AlphaScaleComboBox.SelectedItem = scale;
            Enum.TryParse<Presets.Presets.TevRegisterId>(MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaRegId, out regID);
            AlphaRegIDComboBox.SelectedItem = regID;
            AlphaClampCheckBox.Checked = MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaClamp;
            #endregion
            //---------------------------------------------------------------------------------------------------------------------------------------
            SelectedStage = TEVStageIDComboBox.SelectedIndex;
        }

        private void TEVStageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            //---------------------------------------------------------------------------------------------------------------------------------------
            #region Saving
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorInA = ColInAComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorInB = ColInBComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorInC = ColInCComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorInD = ColInDComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorOp = ColOPComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorBias = ColOPComboBox.Enabled ? ColBiasComboBox.SelectedItem.ToString() : "Add";
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorScale = ColScaleComboBox.Enabled ? ColScaleComboBox.SelectedItem.ToString() : "Scale_1";
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorRegId = ColRegIDComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].ColorClamp = ColClampCheckBox.Checked;
            //---------------------------------------------------------------------------------------------------------------------------------------
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaInA = AlphaInAComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaInB = AlphaInBComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaInC = AlphaInCComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaInD = AlphaInDComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaOp = AlphaOPComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaBias = AlphaOPComboBox.Enabled ? AlphaBiasComboBox.SelectedItem.ToString() : "Add";
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaScale = AlphaScaleComboBox.Enabled ? AlphaScaleComboBox.SelectedItem.ToString() : "Scale_1";
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaRegId = AlphaRegIDComboBox.SelectedItem.ToString();
            MaterialList[SelectedMaterial].TevStages[TEVStageIDComboBox.SelectedIndex].AlphaClamp = AlphaClampCheckBox.Checked;
            #endregion
            //---------------------------------------------------------------------------------------------------------------------------------------
            MainWindow.materials = MaterialList;
            MainWindow.Show();
            MainWindow.ReloadImages();
        }

        private void TevDeleteButton_Click(object sender, EventArgs e)
        {
            if (TEVStageIDComboBox.SelectedIndex < 0)
            {
                return;
            }
            for (int i = TEVStageIDComboBox.SelectedIndex; i < 15; i++)
            {
                MaterialList[SelectedMaterial].TevStages[i] = MaterialList[SelectedMaterial].TevStages[i + 1];
            }
            MaterialList[SelectedMaterial].TevStages[MaterialList[SelectedMaterial].TevStages.Length - 1] = null;
            TEVStageIDComboBox.Items.Clear();
            var count = 0;
            foreach (var TevStage in MaterialList[SelectedMaterial].TevStages)
            {
                if (TevStage != null)
                {
                    TEVStageIDComboBox.Items.Add("TEV Stage " + count);
                }
                else
                {
                    TEVStageIDComboBox.Items.Add("TEV Stage " + count + " (Empty)");
                }
                count++;
            }
            TEVStageIDComboBox.SelectedIndex = SelectedStage-1;
        }

        private void ColOPComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColOPComboBox.SelectedIndex >= 2)
            {
                ColBiasComboBox.Enabled = false;
                ColScaleComboBox.Enabled = false;
            }
            else
            {
                ColBiasComboBox.Enabled = true;
                ColScaleComboBox.Enabled = true;
            }
        }

        private void AlphaOPComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlphaOPComboBox.SelectedIndex >= 2)
            {
                AlphaBiasComboBox.Enabled = false;
                AlphaScaleComboBox.Enabled = false;
            }
            else
            {
                AlphaBiasComboBox.Enabled = true;
                AlphaScaleComboBox.Enabled = true;
            }
        }
    }
}
