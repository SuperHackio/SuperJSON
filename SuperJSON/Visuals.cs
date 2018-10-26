using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Visuals
{
    public class Animations
    {
        Pen pen = new Pen(Color.Red,5);
        Rectangle rect = new Rectangle();


        int R = 0;
        int G = 0;
        int B = 0;
        bool direction = true;

        public Rectangle GetBoundingRectangle(Control Control)
        {
            rect.X = Control.FindForm().PointToClient(Control.Parent.PointToScreen(Control.Location)).X - 50;
            rect.Y = Control.FindForm().PointToClient(Control.Parent.PointToScreen(Control.Location)).Y - 5;
            rect.Width = Control.Width + 10;
            rect.Height = Control.Height + 10;
            return rect;
        }


        public Pen ControlSelectFlash(Control Control, bool enable = true)
        {

            if (enable)
            {
                switch (direction)
                {
                    case true:
                        R++;
                        G--;
                        break;
                    case false:
                        R--;
                        G++;
                        break;
                }

                if (R == 0)
                {
                    direction = true;
                }
                else if (G == 0)
                {
                    direction = false;
                }

                colourclamp();
                //pen.Color = Color.Red;
                return pen;
            }
            else
            {
                return pen;
            }
        }

        public void colourclamp()
        {
            if (R < 0)
            {
                R = 254;
            }
            if (G < 0)
            {
                G = 254;
            }
            if (B < 0)
            {
                B = 254;
            }

            if (R > 255)
            {
                R = 0;
            }
            if (G > 255)
            {
                G = 0;
            }
            if (B > 255)
            {
                B = 0;
            }
        }
    }
}
