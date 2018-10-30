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
        Version SuperBMDVersion = new Version("1.4.0.0"); //Earliest SuperBMD Version compatable with SuperJSON
        Version CheckVersion;

        bool ValidSuperBMD = false;
        bool InValidSuperBMD = false;

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
                cmd.StandardInput.WriteLine("@Echo off");
                cmd.StandardInput.WriteLine("\"" + SuperBMDpath + "\"" + " --version");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                var result = cmd.StandardOutput.ReadToEnd();
                if (result.Contains("SuperBMD\r\n"))
                {
                    string version = result.Substring(result.IndexOf("SuperBMD\r\n"));
                    version = version.Replace("\r\n","");
                    version = version.Replace("SuperBMD","");
                    CheckVersion = new Version(version);
                    switch (SuperBMDVersion.CompareTo(CheckVersion))
                    {
                        case 0:
                        case -1:
                            ValidSuperBMD = true;
                            break;
                        case 1:
                            MessageBox.Show("SuperBMD Version "+SuperBMDVersion+ " is a requirement for BDL Export and TextureHeader usage. If you don't have " + SuperBMDVersion + " you can still export, but Texture Headers will not be used and you cannot export to BDL.", "Wrong Version alert!");
                            ValidSuperBMD = false;
                            break;
                    }
                    InValidSuperBMD = false;
                }
                else
                {
                    MessageBox.Show("This version of SuperBMD is unsupported.", "Wrong Version alert!");
                    InValidSuperBMD = true;
                }
                SuperBMDTextBox.Text = SuperBMDpath;
                #endregion

                if (!InValidSuperBMD)
                {
                    FindInButton.Enabled = true;
                }
                else
                {
                    FindOutButton.Enabled = false;
                    TriStripComboBox.Enabled = false;
                    RotateComboBox.Enabled = false;
                    FixntCheckBox.Enabled = false;
                    BDLCheckBox.Enabled = false;
                    NoTextureCheckBox.Enabled = false;
                    ExportButton.Enabled = true;
                }
            }
        }

        private void FindInButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "All Supported Formats (*.fbx *.dae *.3ds *.obj *.stl *.blend *.amf *.ogex *.x *.x3d *.mdc)|*.fbx; *.dae; *.3ds; *.obj; *.stl; *.blend; *.amf; *.ogex; *.x; *.x3d; *.mdc|AutoDesk Filmbox (*.fbx)|*.fbx|COLLAborative Design Activity (*.dae)|*.dae|3ds Max 3DS (*.3ds)|*.3ds|Wavefront Object (*.obj)|*.obj|Stereolithography (*.stl)|*.stl|Blender (*.blend)|.blend|Additive Manufacturing Format (*.amf)|*.amf|Open Game Engine Exchange (*.ogex)|*.ogex|DirectX (*.x)|*.x|X3D (*.x3d)|*.x3d|MDC (*.mdc)|*.mdc";
            ofd.FilterIndex = 1;
            ofd.FileName = "";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                InModelTextBox.Text = ofd.FileName;
                FindOutButton.Enabled = true;
                TriStripComboBox.Enabled = true;
                RotateComboBox.Enabled = true;
                FixntCheckBox.Enabled = true;

                if (ValidSuperBMD)
                {
                    BDLCheckBox.Enabled = true;
                    NoTextureCheckBox.Enabled = true;
                }
                else
                {
                    BDLCheckBox.Enabled = false;
                    BDLCheckBox.Checked = false;
                    NoTextureCheckBox.Enabled = false;
                    NoTextureCheckBox.Checked = false;
                }
                ExportButton.Enabled = true;
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
