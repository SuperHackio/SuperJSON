using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SuperJSON
{
    public partial class ExportForm : Form
    {
        public ExportForm(string MatPath, string TexPath)
        {
            InitializeComponent();
            CenterToScreen();

            TriStripComboBox.DataSource = Enum.GetValues(typeof(TristripOption));
            RotateComboBox.SelectedIndex = 0;

            MaterialPath = MatPath;
            TextureHeaderPath = TexPath;
        }

        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        Process cmd;

        bool ValidSuperBMD = false;

        string SuperBMDpath = "";
        string ModelInPath = "";
        string ModelOutPath = "";
        string MaterialPath = "";
        string TextureHeaderPath = "";
        TristripOption triopt = TristripOption.DoTriStripStatic;
        bool rotate = false;
        bool fixnt = false;
        bool makebdl = false;
        bool texturent = false;

        enum TristripOption { DoNotTriStrip, DoTriStripStatic, DoTriStripAll }

        private void FindSuperBMDButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "SuperBMD (SuperBMD.exe)|*SuperBMD.exe";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                SuperBMDpath = ofd.FileName;

                #region Check SuperBMD Version
                cmd = new Process();
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
                    MessageBox.Show("You need SuperBMD Version 1.3.6 or higher to export with SuperJSON", "Wrong Version alert!");
                    ValidSuperBMD = false;
                    return;
                }
                SuperBMDTextBox.Text = SuperBMDpath;
                ValidSuperBMD = true;
                #endregion
            }
        }

        private void FindInButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "AutoDesk Filmbox (.fbx)|*.fbx|COLLAborative Design Activity (.dae)|*.dae|3ds Max 3DS (.3ds)|*.3ds|Wavefront Object (.obj)|*.obj";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                InModelTextBox.Text = ofd.FileName;
            }
        }

        private void FindOutButton_Click(object sender, EventArgs e)
        {
            if (makebdl)
                sfd.Filter = "Nintendo BDL (*.bdl)|*.bdl";
            else
                sfd.Filter = "Nintendo BMD (*.bmd)|*.bmd";
            sfd.FilterIndex = 1;
            sfd.FileName = "";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                OutModelTextBox.Text = sfd.FileName;
            }
        }

        private void InModelTextBox_TextChanged(object sender, EventArgs e) => ModelInPath = InModelTextBox.Text;

        private void OutModelTextBox_TextChanged(object sender, EventArgs e) => ModelOutPath = OutModelTextBox.Text;

        private void TriStripComboBox_SelectedIndexChanged(object sender, EventArgs e) => triopt = (TristripOption)Enum.Parse(typeof(TristripOption), TriStripComboBox.SelectedValue.ToString(), true);

        private void BDLCheckBox_CheckedChanged(object sender, EventArgs e) => makebdl = BDLCheckBox.Checked;

        private void RotateComboBox_SelectedIndexChanged(object sender, EventArgs e) => rotate = RotateComboBox.SelectedIndex == 1;

        private void FixntCheckBox_CheckedChanged(object sender, EventArgs e) => fixnt = FixntCheckBox.Checked;

        private void NoTextureCheckBox_CheckedChanged(object sender, EventArgs e) => texturent = NoTextureCheckBox.Checked;

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ModelInPath))
            {
                MessageBox.Show("The model could not be found.","Error");
                return;
            }
            string args = "";

            args += "\"" + SuperBMDpath + "\"";
            args += " ";
            args += "\"" + ModelInPath + "\"";
            args += " ";
            if (ModelOutPath != "")
                args += "\"" + ModelOutPath + "\"" + " ";
            args += "--mat " + "\"" + MaterialPath + "\"";
            args += " ";
            if (!texturent && ValidSuperBMD)
                args += "--texheader "+"\"" + TextureHeaderPath + "\"" + " ";
            switch (triopt)
            {
                case TristripOption.DoNotTriStrip:
                    args += "--tristrip none ";
                    break;
                case TristripOption.DoTriStripStatic:
                    args += "--tristrip static ";
                    break;
                case TristripOption.DoTriStripAll:
                    args += "--tristrip all ";
                    break;
                default:
                    break;
            }
            if (rotate)
                args += "--rotate ";
            if (fixnt)
                args += "--dontFix ";
            if (makebdl && ValidSuperBMD)
                args += "--bdl";

            cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(args);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            System.IO.File.WriteAllText(@AppDomain.CurrentDomain.BaseDirectory+"SuperBMDLog.txt", cmd.StandardOutput.ReadToEnd());
            this.Close();
        }


    }
}
