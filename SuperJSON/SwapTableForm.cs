using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QuickType;

namespace SuperJSON
{
    public partial class SwapTableForm : Form
    {
        public SwapTableForm(MainForm home, int selectedmat, List<Material> mlist)
        {
            InitializeComponent();
            CenterToScreen();
            Home = home;
            SelectedMaterial = selectedmat;
            MaterialList = mlist;
            this.FormClosing += SwapTableForm_FormClosing;
            //---------------------------------------------------------------------------------------------------------------------------------------
            #region DataBinding

            SwapBoxes = new ComboBox[4] { RSwapComboBox, GSwapComboBox, BSwapComboBox, ASwapComboBox };

            RSwapComboBox.DataSource = Enum.GetValues(typeof(SwapTableLabels));
            GSwapComboBox.DataSource = Enum.GetValues(typeof(SwapTableLabels));
            BSwapComboBox.DataSource = Enum.GetValues(typeof(SwapTableLabels));
            ASwapComboBox.DataSource = Enum.GetValues(typeof(SwapTableLabels));
            #endregion
            //---------------------------------------------------------------------------------------------------------------------------------------
            var count = 0;
            foreach (var SwapMod in MaterialList[SelectedMaterial].SwapModes)
            {
                if (SwapMod != null)
                {
                    SwapModeComboBox.Items.Add("Swap Mode " + count);
                }
                count++;
            }
            SwapModeComboBox.SelectedIndex = 0;
            count = 0;
            foreach (var SwapTable in MaterialList[SelectedMaterial].SwapTables)
            {
                if (SwapTable != null)
                {
                    SwapTableComboBox.Items.Add("Swap Table " + count);
                }
                count++;
            }
            SwapTableComboBox.SelectedIndex = 0;
            //---------------------------------------------------------------------------------------------------------------------------------------
            DrawSwapTable(DrawMode.BoxesOnly);
            loaded = true;
        }

        MainForm Home;
        List<Material> MaterialList;
        ComboBox[] SwapBoxes;
        Graphics GraphicsEngine;

        int SelectedMaterial = 0;
        int SelectedTable = 0;
        int SelectedMode = 0;
        int colourcounter = 0;
        bool loaded = false;

        public enum SwapTableLabels { RED, GREEN, BLUE, ALPHA }
        private enum DrawMode { All, BoxesOnly, LinesOnly, Refresh }

        #region Drawing
        static Rectangle IRswapRect = new Rectangle(6, 19, 32, 32);
        static Rectangle IGswapRect = new Rectangle(6, 55, 32, 32);
        static Rectangle IBswapRect = new Rectangle(6, 91, 32, 32);
        static Rectangle IAswapRect = new Rectangle(6, 127, 32, 32);
        Rectangle[] SwapRect = new Rectangle[8] { IRswapRect, IGswapRect, IBswapRect, IAswapRect, ORswapRect, OGswapRect, OBswapRect, OAswapRect };
        static Rectangle ORswapRect = new Rectangle(350, 19, 32, 32);
        static Rectangle OGswapRect = new Rectangle(350, 55, 32, 32);
        static Rectangle OBswapRect = new Rectangle(350, 91, 32, 32);
        static Rectangle OAswapRect = new Rectangle(350, 127, 32, 32);
        Brush[] SwapBrush = new Brush[4] { RSwapBrush, GSwapBrush, BSwapBrush, ASwapBrush };
        static SolidBrush RSwapBrush = new SolidBrush(Color.Red);
        static SolidBrush GSwapBrush = new SolidBrush(Color.Green);
        static SolidBrush BSwapBrush = new SolidBrush(Color.Blue);
        static HatchBrush ASwapBrush = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.FromArgb(255,255,255,255), Color.FromArgb(255, 204, 204, 204));
        char[] SwapChar = new char[4] { 'R', 'G', 'B', 'A' };
        Font SwapFont = new Font("Arial Black", 12.0f);
        Brush[] SwapBrushes = new Brush[4] { new SolidBrush(Color.FromArgb(255,255,204,204)), new SolidBrush(Color.FromArgb(255, 204, 255, 204)), new SolidBrush(Color.FromArgb(255, 204, 204, 255)), Brushes.Black };
        static Point IRSwapPoint = new Point { X = IRswapRect.X + (IRswapRect.Width-5), Y = IRswapRect.Y + IRswapRect.Height / 2 };
        static Point IGSwapPoint = new Point { X = IGswapRect.X + (IGswapRect.Width - 5), Y = IGswapRect.Y + IGswapRect.Height / 2 };
        static Point IBSwapPoint = new Point { X = IBswapRect.X + (IBswapRect.Width - 5), Y = IBswapRect.Y + IBswapRect.Height / 2 };
        static Point IASwapPoint = new Point { X = IAswapRect.X + (IAswapRect.Width - 5), Y = IAswapRect.Y + IAswapRect.Height / 2 };
        Point[] ISwapPoint = new Point[4] { IRSwapPoint, IGSwapPoint, IBSwapPoint, IASwapPoint };
        Point[] OSwapPoint = new Point[4] { ORSwapPoint, OGSwapPoint, OBSwapPoint, OASwapPoint };
        static Point ORSwapPoint = new Point { X = ORswapRect.X, Y = ORswapRect.Y + ORswapRect.Height / 2 };
        static Point OGSwapPoint = new Point { X = OGswapRect.X, Y = OGswapRect.Y + OGswapRect.Height / 2 };
        static Point OBSwapPoint = new Point { X = OBswapRect.X, Y = OBswapRect.Y + OBswapRect.Height / 2 };
        static Point OASwapPoint = new Point { X = OAswapRect.X, Y = OAswapRect.Y + OAswapRect.Height / 2 };
        Color[] SwapColours = new Color[4] { Color.Red, Color.Green, Color.Blue, Color.Gray };
        LinearGradientBrush SwapLineBrush;
        //---------------------------------------------------------------------------------------------------------------------------------------
        private void DrawSwapTable(DrawMode mode)
        {
            GraphicsEngine = PreviewGroupBox.CreateGraphics(); //Graphics for GroupBox
            colourcounter = 0;
            switch (mode)
            {
                case DrawMode.All:
                    PreviewGroupBox.Refresh();
                    DrawSwapTable(DrawMode.LinesOnly);
                    DrawSwapTable(DrawMode.BoxesOnly);
                    break;
                case DrawMode.BoxesOnly:
                    foreach (RectangleF rect in SwapRect)
                    {
                        GraphicsEngine.FillRectangle(SwapBrush[colourcounter], rect);
                        StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        GraphicsEngine.DrawString(SwapChar[colourcounter].ToString(), SwapFont, SwapBrushes[colourcounter], rect, sf);

                        colourcounter = colourcounter > 2 ? colourcounter = 0 : colourcounter + 1;
                    }
                    break;
                case DrawMode.LinesOnly:
                    for (int i = 0; i < 4; i++)
                    {
                        switch (SwapBoxes[i].SelectedItem)
                        {
                            case SwapTableLabels.RED:
                                SwapLineBrush = new LinearGradientBrush(new Point(6, 10), new Point(360, 10), SwapColours[0], SwapColours[i]);
                                GraphicsEngine.DrawLine(new Pen(SwapLineBrush, 5.0f), OSwapPoint[i], ISwapPoint[0]);
                                break;
                            case SwapTableLabels.GREEN:
                                SwapLineBrush = new LinearGradientBrush(new Point(6, 10), new Point(360, 10), SwapColours[1], SwapColours[i]);
                                GraphicsEngine.DrawLine(new Pen(SwapLineBrush, 5.0f), OSwapPoint[i], ISwapPoint[1]);
                                break;
                            case SwapTableLabels.BLUE:
                                SwapLineBrush = new LinearGradientBrush(new Point(6, 10), new Point(360, 10), SwapColours[2], SwapColours[i]);
                                GraphicsEngine.DrawLine(new Pen(SwapLineBrush, 5.0f), OSwapPoint[i], ISwapPoint[2]);
                                break;
                            case SwapTableLabels.ALPHA:
                                SwapLineBrush = new LinearGradientBrush(new Point(6, 10), new Point(360, 10), SwapColours[3], SwapColours[i]);
                                GraphicsEngine.DrawLine(new Pen(SwapLineBrush, 5.0f), OSwapPoint[i], ISwapPoint[3]);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
            }
        }
        #endregion

        private void SwapTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            //---------------------------------------------------------------------------------------------------------------------------------------
            #region Saving
            SaveSwapSettings();
            #endregion
            //---------------------------------------------------------------------------------------------------------------------------------------
            Home.materials = MaterialList;
            Home.Show();
            Home.ReloadImages();
        }

        private void SaveSwapSettings()
        {
            if (loaded)
            {
                MaterialList[SelectedMaterial].SwapModes[SelectedMode].RasSel = (long)RasIDNumericUpDown.Value;
                MaterialList[SelectedMaterial].SwapModes[SelectedMode].TexSel = (long)TexIDNumericUpDown.Value;

                MaterialList[SelectedMaterial].SwapTables[SelectedTable].R = RSwapComboBox.SelectedIndex;
                MaterialList[SelectedMaterial].SwapTables[SelectedTable].G = GSwapComboBox.SelectedIndex;
                MaterialList[SelectedMaterial].SwapTables[SelectedTable].B = BSwapComboBox.SelectedIndex;
                MaterialList[SelectedMaterial].SwapTables[SelectedTable].A = ASwapComboBox.SelectedIndex;
            }
        }

        private void SwapModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSwapSettings();
            if (MaterialList[SelectedMaterial].SwapModes[SwapModeComboBox.SelectedIndex] == null || MaterialList[SelectedMaterial].SwapModes[SwapModeComboBox.SelectedIndex] == null)
            {
                throw new Exception("SWAP MODE " + SwapModeComboBox.SelectedIndex + " IS MISSING");
            }
            else
            {
                RasIDNumericUpDown.Value = MaterialList[SelectedMaterial].SwapModes[SwapModeComboBox.SelectedIndex].RasSel;
                TexIDNumericUpDown.Value = MaterialList[SelectedMaterial].SwapModes[SwapModeComboBox.SelectedIndex].TexSel;
            }
            SelectedMode = SwapModeComboBox.SelectedIndex;
        }

        private void SwapTableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSwapSettings();
            if (MaterialList[SelectedMaterial].SwapTables[SwapTableComboBox.SelectedIndex] == null)
            {
                throw new Exception("SWAP TABLE "+SwapTableComboBox.SelectedIndex+" IS MISSING");
            }
            else
            {
                SwapTableLabels check = SwapTableLabels.RED;
                switch (MaterialList[SelectedMaterial].SwapTables[SwapTableComboBox.SelectedIndex].R)
                {
                    case 0:
                        check = SwapTableLabels.RED;
                        break;
                    case 1:
                        check = SwapTableLabels.GREEN;
                        break;
                    case 2:
                        check = SwapTableLabels.BLUE;
                        break;
                    case 3:
                        check = SwapTableLabels.ALPHA;
                        break;
                }
                RSwapComboBox.SelectedItem = check;
                check = SwapTableLabels.GREEN;
                switch (MaterialList[SelectedMaterial].SwapTables[SwapTableComboBox.SelectedIndex].G)
                {
                    case 0:
                        check = SwapTableLabels.RED;
                        break;
                    case 1:
                        check = SwapTableLabels.GREEN;
                        break;
                    case 2:
                        check = SwapTableLabels.BLUE;
                        break;
                    case 3:
                        check = SwapTableLabels.ALPHA;
                        break;
                }
                GSwapComboBox.SelectedItem = check;
                check = SwapTableLabels.BLUE;
                switch (MaterialList[SelectedMaterial].SwapTables[SwapTableComboBox.SelectedIndex].B)
                {
                    case 0:
                        check = SwapTableLabels.RED;
                        break;
                    case 1:
                        check = SwapTableLabels.GREEN;
                        break;
                    case 2:
                        check = SwapTableLabels.BLUE;
                        break;
                    case 3:
                        check = SwapTableLabels.ALPHA;
                        break;
                }
                BSwapComboBox.SelectedItem = check;
                check = SwapTableLabels.ALPHA;
                switch (MaterialList[SelectedMaterial].SwapTables[SwapTableComboBox.SelectedIndex].A)
                {
                    case 0:
                        check = SwapTableLabels.RED;
                        break;
                    case 1:
                        check = SwapTableLabels.GREEN;
                        break;
                    case 2:
                        check = SwapTableLabels.BLUE;
                        break;
                    case 3:
                        check = SwapTableLabels.ALPHA;
                        break;
                }
                ASwapComboBox.SelectedItem = check;

                DrawSwapTable(DrawMode.All);
            }
            SelectedTable = SwapTableComboBox.SelectedIndex;
        }

        private void RSwapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawSwapTable(DrawMode.All);
        }

        private void GSwapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawSwapTable(DrawMode.All);
        }

        private void BSwapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawSwapTable(DrawMode.All);
        }

        private void ASwapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawSwapTable(DrawMode.All);
        }
    }
}
