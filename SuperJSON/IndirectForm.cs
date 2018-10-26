using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using QuickType;

namespace SuperJSON
{
    public partial class IndirectForm : Form
    {
        public IndirectForm(MainForm Mainform, List<Material> materiallist, int selectedmaterial)
        {
            InitializeComponent();
            CenterToScreen();
            this.FormClosing += IndirectForm_FormClosing;
            MainWindow = Mainform;
            MaterialList = materiallist;
            SelectedMaterial = selectedmaterial;
            //------------------------------------------------------------------------------------------------------
            IndTexCoordComboBox.DataSource = Enum.GetValues(typeof(TexCoord));
            IndTexMapComboBox.DataSource = Enum.GetValues(typeof(TexMap));
            //------------------------------------------------------------------------------------------------------
            IndScaleSComboBox.DataSource = Enum.GetValues(typeof(IndScale));
            IndScaleTComboBox.DataSource = Enum.GetValues(typeof(IndScale));
            //------------------------------------------------------------------------------------------------------
            FormatComboBox.DataSource = Enum.GetValues(typeof(IndTexFormat));
            BiasComboBox.DataSource = Enum.GetValues(typeof(IndTexBiasSel));
            WrapSComboBox.DataSource = Enum.GetValues(typeof(IndTexWrap));
            WrapTComboBox.DataSource = Enum.GetValues(typeof(IndTexWrap));
            IndMatScaleComboBox.DataSource = Enum.GetValues(typeof(IndTexMtxId));
            BumpAlphaComboBox.DataSource = Enum.GetValues(typeof(TevStageAlphaSel));
            //------------------------------------------------------------------------------------------------------
            LoadSettings(true);
        }

        OpenFileDialog ofd = new OpenFileDialog();
        MainForm MainWindow;
        List<Material> MaterialList;
        int SelectedMaterial;
        bool startup = true;

        public void LoadSettings(bool first = false)
        {
            MatNameTextBox.Text = MaterialList[SelectedMaterial].Name;
            if (first)
            {
                IndStageNumericUpDown.Value = MaterialList[SelectedMaterial].IndTexEntry.IndTexStageNum;
            }
            //------------------------------------------------------------------------------------------------------
            var count = 0;
            TevOrderIDComboBox.Items.Clear();
            foreach (TevOrderElement tevorder in MaterialList[SelectedMaterial].IndTexEntry.TevOrders)
            {
                TevOrderIDComboBox.Items.Add("TEV Order " + count);
                count++;
            }
            TevOrderIDComboBox.SelectedIndex = 0;
            //------------------------------------------------------------------------------------------------------
            count = 0;
            MatrixIDComboBox.Items.Clear();
            foreach (var Matrix in MaterialList[SelectedMaterial].IndTexEntry.Matrices)
            {
                MatrixIDComboBox.Items.Add("Matrix " + count);
                count++;
            }
            MatrixIDComboBox.SelectedIndex = 0;
            //------------------------------------------------------------------------------------------------------
            count = 0;
            IndScaleComboBox.Items.Clear();
            foreach (var Scanscale in MaterialList[SelectedMaterial].IndTexEntry.Scales)
            {
                IndScaleComboBox.Items.Add("Scale " + count);
                count++;
            }
            IndScaleComboBox.SelectedIndex = 0;
            //------------------------------------------------------------------------------------------------------
            count = 0;
            IndStageSelectComboBox.Items.Clear();
            for (int i = 0; i < IndStageNumericUpDown.Value; i++)
            {
                IndStageSelectComboBox.Items.Add("TEV Stage " + (count+1));
                count++;
            }
            if (IndStageSelectComboBox.Items.Count != 0)
            {
                foreach (Control child in IndGroupBox.Controls)
                {
                    child.Enabled = true;
                }
                IndStageSelectComboBox.SelectedIndex = 0;
            }
            else
            {
                foreach (Control child in IndGroupBox.Controls)
                {
                    child.Enabled = false;
                }
                StageAmountLabel.Enabled = true;
                IndStageNumericUpDown.Enabled = true;
            }
        }

        public void SaveSettings()
        {
            MaterialList[SelectedMaterial].IndTexEntry.HasLookup = IndStageNumericUpDown.Value >= 0 ? false : true;
            MaterialList[SelectedMaterial].IndTexEntry.IndTexStageNum = (int)IndStageNumericUpDown.Value;
            if (MaterialList[SelectedMaterial].IndTexEntry.HasLookup)
            {
                MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].AddPrev = AddPrevCheckBox.Checked;
                MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].UtcLod = UTCLODCheckBox.Checked;
            }
            
        }

        private void IndirectForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void IndStageNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LoadSettings();
            MaterialList[SelectedMaterial].IndTexEntry.IndTexStageNum = (int)IndStageNumericUpDown.Value;
        }

        #region TEV Orders
        private void TevOrderIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TexCoord Tcoord;
            TexMap Tmap;
            Enum.TryParse<TexCoord>(MaterialList[SelectedMaterial].IndTexEntry.TevOrders[TevOrderIDComboBox.SelectedIndex].TexCoord, out Tcoord);
            IndTexCoordComboBox.SelectedItem = Tcoord;
            Enum.TryParse<TexMap>(MaterialList[SelectedMaterial].IndTexEntry.TevOrders[TevOrderIDComboBox.SelectedIndex].TexMap, out Tmap);
            IndTexMapComboBox.SelectedItem = Tmap;

            startup = false;
        }

        private void TevOrderClearButton_Click(object sender, EventArgs e)
        {
            IndTexCoordComboBox.SelectedItem = TexCoord.Null;
            IndTexMapComboBox.SelectedItem = TexMap.Null;
        }

        private void IndTexCoordComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.TevOrders[TevOrderIDComboBox.SelectedIndex].TexCoord = IndTexCoordComboBox.SelectedItem.ToString();
        }

        private void IndTexMapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.TevOrders[TevOrderIDComboBox.SelectedIndex].TexMap = IndTexMapComboBox.SelectedItem.ToString();
        }
        #endregion

        #region Matrices
        private void MatrixIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InnerMatrixComboBox.Items.Clear();
            var x = 0;
            foreach (var Vec3 in MaterialList[SelectedMaterial].IndTexEntry.Matrices[MatrixIDComboBox.SelectedIndex].MatrixMatrix)
            {
                InnerMatrixComboBox.Items.Add("Vector3 " + x);
                x++;
            }
            InnerMatrixComboBox.SelectedIndex = 0;
        }

        private void InnerMatrixComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            XNumericUpDown.Value = (decimal)MaterialList[SelectedMaterial].IndTexEntry.Matrices[MatrixIDComboBox.SelectedIndex].MatrixMatrix[InnerMatrixComboBox.SelectedIndex][0];
            YNumericUpDown.Value = (decimal)MaterialList[SelectedMaterial].IndTexEntry.Matrices[MatrixIDComboBox.SelectedIndex].MatrixMatrix[InnerMatrixComboBox.SelectedIndex][1];
            ZNumericUpDown.Value = (decimal)MaterialList[SelectedMaterial].IndTexEntry.Matrices[MatrixIDComboBox.SelectedIndex].MatrixMatrix[InnerMatrixComboBox.SelectedIndex][2];
            ExponentNumericUpDown.Value = MaterialList[SelectedMaterial].IndTexEntry.Matrices[MatrixIDComboBox.SelectedIndex].Exponent;
        }

        private void XNumericUpDown_ValueChanged(object sender, EventArgs e) => MaterialList[SelectedMaterial].IndTexEntry.Matrices[MatrixIDComboBox.SelectedIndex].MatrixMatrix[InnerMatrixComboBox.SelectedIndex][0] = (double)XNumericUpDown.Value;

        private void YNumericUpDown_ValueChanged(object sender, EventArgs e) => MaterialList[SelectedMaterial].IndTexEntry.Matrices[MatrixIDComboBox.SelectedIndex].MatrixMatrix[InnerMatrixComboBox.SelectedIndex][1] = (double)YNumericUpDown.Value;

        private void ZNumericUpDown_ValueChanged(object sender, EventArgs e) => MaterialList[SelectedMaterial].IndTexEntry.Matrices[MatrixIDComboBox.SelectedIndex].MatrixMatrix[InnerMatrixComboBox.SelectedIndex][2] = (double)ZNumericUpDown.Value;

        private void ExponentNumericUpDown_ValueChanged(object sender, EventArgs e) => MaterialList[SelectedMaterial].IndTexEntry.Matrices[MatrixIDComboBox.SelectedIndex].Exponent = (long)ExponentNumericUpDown.Value;
        #endregion

        #region Scales
        private void IndScaleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndScale Iscale;
            Enum.TryParse<IndScale>(MaterialList[SelectedMaterial].IndTexEntry.Scales[IndScaleComboBox.SelectedIndex].ScaleS, out Iscale);
            IndScaleSComboBox.SelectedItem = Iscale;
            Enum.TryParse<IndScale>(MaterialList[SelectedMaterial].IndTexEntry.Scales[IndScaleComboBox.SelectedIndex].ScaleT, out Iscale);
            IndScaleTComboBox.SelectedItem = Iscale;
        }

        private void ScaleClearButton_Click(object sender, EventArgs e)
        {
            IndScaleSComboBox.SelectedItem = IndScale.ITS_1;
            IndScaleTComboBox.SelectedItem = IndScale.ITS_1;
        }

        private void IndScaleSComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.Scales[IndScaleComboBox.SelectedIndex].ScaleS = IndScaleSComboBox.SelectedItem.ToString();
        }

        private void IndScaleTComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.Scales[IndScaleComboBox.SelectedIndex].ScaleT = IndScaleTComboBox.SelectedItem.ToString();
        }
        #endregion

        #region Indirect Stages
        private void IndStageSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPrevCheckBox.Checked = MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].AddPrev;
            UTCLODCheckBox.Checked = MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].UtcLod;

            var txtfm = IndTexFormat.ITF_8;
            Enum.TryParse<IndTexFormat>(MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexFormat, out txtfm);
            FormatComboBox.SelectedItem = txtfm;
            var bias = IndTexBiasSel.ITB_S;
            Enum.TryParse<IndTexBiasSel>(MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexBiasSel, out bias);
            BiasComboBox.SelectedItem = bias;
            var MatScale = IndTexMtxId.ITM_OFF;
            Enum.TryParse<IndTexMtxId>(MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexMtxId, out MatScale);
            IndMatScaleComboBox.SelectedItem = MatScale;
            var Albump = TevStageAlphaSel.ITBA_OFF;
            Enum.TryParse<TevStageAlphaSel>(MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].AlphaSel, out Albump);
            BumpAlphaComboBox.SelectedItem = Albump;
            var Wrap = IndTexWrap.ITW_OFF;
            Enum.TryParse<IndTexWrap>(MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexWrapS, out Wrap);
            WrapSComboBox.SelectedItem = Wrap;
            Enum.TryParse<IndTexWrap>(MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexWrapT, out Wrap);
            WrapTComboBox.SelectedItem = Wrap;
        }

        private void AddPrevCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].AddPrev = AddPrevCheckBox.Checked;
        }

        private void UTCLODCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].UtcLod = UTCLODCheckBox.Checked;
        }

        private void FormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexFormat = FormatComboBox.SelectedItem.ToString(); ;
        }

        private void BiasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexBiasSel = BiasComboBox.SelectedItem.ToString();
        }

        private void IndMatScaleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexMtxId = IndMatScaleComboBox.SelectedItem.ToString();
        }

        private void BumpAlphaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].AlphaSel = BumpAlphaComboBox.SelectedItem.ToString();
        }

        private void WrapSComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexWrapS.ToString();
        }

        private void WrapTComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
                MaterialList[SelectedMaterial].IndTexEntry.TevStages[IndStageSelectComboBox.SelectedIndex].IndTexWrapT = WrapTComboBox.SelectedItem.ToString();
        }
        #endregion

        private void SwitchLeftButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            SelectedMaterial--;
            if (SelectedMaterial < 0)
            {
                SelectedMaterial = MaterialList.Count - 1;
            }
            LoadSettings(true);
        }

        private void SwitchRightButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            SelectedMaterial++;
            if (SelectedMaterial > MaterialList.Count - 1)
            {
                SelectedMaterial = 0;
            }
            LoadSettings(true);
        }


    }
}
