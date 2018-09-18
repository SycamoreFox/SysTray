using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SysTray
{
    class IconDraw
    {
        public static Graphics DrawGraphics(Bitmap passedBitmap, int usageValue, string iconType)
        {
            //initiate the drawing canvas
            Graphics g = Graphics.FromImage(passedBitmap);

            g.Clear(Properties.Settings.Default.IconBackground);

            switch (iconType)
            {
                case "dsk":
                    DrawHDD(g, usageValue);
                    break;
                case "mem":
                    DrawUsage(g, usageValue, iconType);
                    break;
                case "cpu":
                    DrawUsage(g, usageValue, iconType);
                    break;
                case "net":
                    DrawNET(g);
                    break;
                case "cap":
                    DrawCAP(g);
                    break;
                case "num":
                    DrawNUM(g);
                    break;
            }

            //dispose GDI elements (memory garbage collection)
            g.Dispose();
            iconType = null;

            return g;
        }

        public static Graphics DrawHDD(Graphics g, int usageValue)
        {
            //assign colors
            Pen thePen = new Pen(Globals.colorBackground, 1);
            SolidBrush theBrush = new SolidBrush(Globals.colorBackground);

            //draw disk icon
            Rectangle[] theRects = new Rectangle[5]
            {
                new Rectangle(0,11,2,4),
                new Rectangle(14,11,2,4),
                new Rectangle(1,10,14,2),
                new Rectangle(1,14,14,2),
                new Rectangle(4,12,10,2)
            };

            g.FillRectangles(theBrush, theRects);

            if (Globals.diskReadValue > 20)
            {
                theBrush = new SolidBrush(Globals.colorWhite);
                thePen = new Pen(Globals.colorWhite);
                g.FillRectangle(theBrush, 2, 12, 2, 2);
            }
            else
            {
                theBrush = new SolidBrush(Globals.colorBackground);
                thePen = new Pen(Globals.colorBackground);
            }

            //draw DISK READ (up) arrow using color assigned above  
            Point[] thePoints = new Point[8]
            {
                new Point(3,0),
                new Point(0,3),
                new Point(2,3),
                new Point(2,7),
                new Point(4,7),
                new Point(4,3),
                new Point(6,3),
                new Point(3,0)
            };

            g.FillPolygon(theBrush, thePoints);
            g.DrawLines(thePen, thePoints);

            if (Globals.diskWriteValue > 20)
            {
                theBrush = new SolidBrush(Globals.colorWhite);
                thePen = new Pen(Globals.colorWhite);
                g.FillRectangle(theBrush, 2, 12, 2, 2);
            }
            else
            {
                theBrush = new SolidBrush(Globals.colorBackground);
                thePen = new Pen(Globals.colorBackground);
            }

            //draw DISK WRITE (down) arrow using colors assigned above
            thePoints = new Point[8]
            {
                new Point(11,0),
                new Point(11,4),
                new Point(9,4),
                new Point(12,7),
                new Point(15,4),
                new Point(13,4),
                new Point(13,0),
                new Point(11,0)
            };

            g.FillPolygon(theBrush, thePoints);
            g.DrawLines(thePen, thePoints);

            thePen.Dispose();
            theBrush.Dispose();
            thePoints = null;
            theRects = null;

            return g;
        }

        public static Graphics DrawNET(Graphics g)
        {
            //assign colors
            Pen thePen = new Pen(Globals.colorBackground, 1);
            SolidBrush theBrush = new SolidBrush(Globals.colorBackground);

            //draw net icon
            Rectangle[] theRects = new Rectangle[4]
            {
                new Rectangle(0,13,3,2),
                new Rectangle(4,12,8,4),
                new Rectangle(7,8,2,4),
                new Rectangle(13,13,3,2)
            };

            g.FillRectangles(theBrush, theRects);

            //draw sent (up) arrow
            if (Globals.kbReceived > 5000)
            {
                theBrush = new SolidBrush(Globals.colorWhite);
                thePen = new Pen(Globals.colorWhite);
            }
            else
            {
                theBrush = new SolidBrush(Globals.colorBackground);
                thePen = new Pen(Globals.colorBackground);
            }

            //draw SENT (up) arrow using color assigned above  
            Point[] thePoints = new Point[8]
            {
                new Point(3,0),
                new Point(0,3),
                new Point(2,3),
                new Point(2,7),
                new Point(4,7),
                new Point(4,3),
                new Point(6,3),
                new Point(3,0)
            };

            g.FillPolygon(theBrush, thePoints);
            g.DrawLines(thePen, thePoints);

            //draw received (down) arrow
            if (Globals.kbReceived > 5000)
            {
                theBrush = new SolidBrush(Globals.colorWhite);
                thePen = new Pen(Globals.colorWhite);
                g.FillRectangle(theBrush, 2, 12, 2, 2);
            }
            else
            {
                theBrush = new SolidBrush(Globals.colorBackground);
                thePen = new Pen(Globals.colorBackground);
            }

            //draw RECEIVED (down) arrow using colors assigned above
            thePoints = new Point[8]
            {
                new Point(11,0),
                new Point(11,4),
                new Point(9,4),
                new Point(12,7),
                new Point(15,4),
                new Point(13,4),
                new Point(13,0),
                new Point(11,0)
            };

            g.FillPolygon(theBrush, thePoints);
            g.DrawLines(thePen, thePoints);

            thePen.Dispose();
            theBrush.Dispose();
            thePoints = null;
            theRects = null;

            return g;
        }

        public static Graphics DrawUsage(Graphics g, int usageValue, string iconType)
        {
            //assign colors
            Pen thePen = new Pen(Globals.colorBackground, 1);
            SolidBrush theBrush = new SolidBrush(Globals.colorBackground);

            switch (iconType)
            {
                case "mem":
                    //draw letter "M"
                    g.DrawLine(thePen, 0, 0, 0, 5);
                    g.DrawLine(thePen, 1, 0, 1, 1);
                    g.DrawLine(thePen, 2, 1, 2, 2);
                    g.DrawLine(thePen, 3, 2, 3, 3);
                    g.DrawLine(thePen, 4, 1, 4, 2);
                    g.DrawLine(thePen, 5, 0, 5, 1);
                    g.DrawLine(thePen, 6, 0, 6, 5);
                    break;

                case "cpu":
                    //draw letter "C"
                    g.DrawLine(thePen, 6, 0, 0, 0);
                    g.DrawLine(thePen, 0, 0, 0, 5);
                    g.DrawLine(thePen, 0, 5, 6, 5);
                    break;
            }

            //draw base triangle
            Point[] thePoints = new Point[3]
            {
                new Point(0,15),
                new Point(15,0),
                new Point(15,15)
            };

            g.FillPolygon(theBrush, thePoints);
            g.DrawPolygon(thePen, thePoints);

            //convert usagevalue (ex: 75%) to draw value
            int x = Convert.ToInt16((usageValue * .01) * 15);

            //draw usage triangle
            thePoints = new Point[3]
            {
                new Point(0,15), //starting corner
                new Point(x,(15-x)), //width, 
                new Point(x,15) //width, bottom always 15
            };

            theBrush = BrushAssign(usageValue);
            thePen = PenAssign(usageValue);

            g.FillPolygon(theBrush, thePoints);
            g.DrawPolygon(thePen, thePoints);

            ////draw horizontal lines
            ////thePen = new Pen(Color.DimGray);
            //thePen = new Pen(Globals.colorDarkGray);
            //g.DrawLine(thePen, 0, 0, 15, 0);
            //g.DrawLine(thePen, 0, 5, 15, 5);

            ////inherit points from the right
            //for (int i = 0; i <= 6; i++)
            //{
            //    arrayDrawHeight[i] = arrayDrawHeight[i + 1];
            //}

            ////assign current usage to array for use in next cycle to move to the left
            //arrayDrawHeight[7] = usageValue;

            //int x = 0;

            ////inherit points from the right
            //for (int i = 0; i <= 7; i++)
            //{
            //    //g.DrawLine(thePen, i, 9, i, arrayY[i]);
            //    int drawHeight = 10 - arrayDrawHeight[i];
            //    //g.FillRectangle(theBrush, i, x, 1, arrayDrawHeight[i]);
            //    g.FillRectangle(BrushAssign(arrayDrawHeight[i]), x, drawHeight, 2, arrayDrawHeight[i]);
            //    x = x + 2;
            //}

            //thePen = new Pen(Globals.colorWhite, 1);

            ////draw 'MEM' text
            //////Mem
            //g.DrawLine(thePen, 0, 11, 0, 15);
            //g.DrawLine(thePen, 1, 11, 1, 12);
            //g.DrawLine(thePen, 2, 12, 2, 14);
            //g.DrawLine(thePen, 3, 11, 3, 12);
            //g.DrawLine(thePen, 4, 11, 4, 15);
            //////mEm
            //g.DrawLine(thePen, 6, 11, 6, 15);
            //g.DrawLine(thePen, 7, 11, 9, 11);
            //g.DrawLine(thePen, 7, 13, 8, 13);
            //g.DrawLine(thePen, 7, 15, 9, 15);
            //////meM
            //g.DrawLine(thePen, 11, 11, 11, 15);
            //g.DrawLine(thePen, 12, 11, 12, 12);
            //g.DrawLine(thePen, 13, 12, 13, 14);
            //g.DrawLine(thePen, 14, 11, 14, 12);
            //g.DrawLine(thePen, 15, 11, 15, 15);

            thePen.Dispose();
            theBrush.Dispose();
            thePoints = null;

            return g;
        }

        public static Graphics DrawCAP(Graphics g)
        {
            Pen thePen = new Pen(Globals.colorWhite, 1);
            SolidBrush theBrush = new SolidBrush(Globals.colorWhite);

            //create point array for graphics path
            Point[] thePoints = new Point[11]
            {
                new Point(7,0),
                new Point(0,7),
                new Point(0,8),
                new Point(5,8),
                new Point(5,15),
                new Point(10,15),
                new Point(10,8),
                new Point(15,8),
                new Point(15,7),
                new Point(8,0),
                new Point(7,0)
            };

            GraphicsPath gPath = new GraphicsPath();
            gPath.AddLines(thePoints);

            if (!Globals.capState)
            {
                thePen = new Pen(Globals.colorBackground);
                theBrush = new SolidBrush(Globals.colorBackground);
            }

            //only draw fill path, which has interesting effect of shrinking path by 1 pixel, resulting in a 15x15 image, which appears quite sharp
            g.FillPath(theBrush, gPath);
            //g.DrawPath(thePen, gPath);

            thePen.Dispose();
            theBrush.Dispose();
            gPath.Dispose();
            thePoints = null;

            return g;
        }

        public static Graphics DrawNUM(Graphics g)
        {
            Pen thePen = new Pen(Globals.colorWhite, 1);
            SolidBrush theBrush = new SolidBrush(Globals.colorWhite);

            //create point array for graphics path
            Point[] thePoints = new Point[29]
                {
                new Point(3,0),
                new Point(3,3),
                new Point(0,3),
                new Point(0,6),
                new Point(3,6),
                new Point(3,9),
                new Point(0,9),
                new Point(0,12),
                new Point(3,12),
                new Point(3,15),
                new Point(6,15),
                new Point(6,12),
                new Point(9,12),
                new Point(9,15),
                new Point(12,15),
                new Point(12,12),
                new Point(15,12),
                new Point(15,9),
                new Point(12,9),
                new Point(12,6),
                new Point(15,6),
                new Point(15,3),
                new Point(12,3),
                new Point(12,0),
                new Point(9,0),
                new Point(9,3),
                new Point(6,3),
                new Point(6,0),
                new Point(3,0)
                };

            GraphicsPath gPath = new GraphicsPath();
            Rectangle theRect = new Rectangle(6, 6, 3, 3);
            gPath.AddLines(thePoints);
            gPath.AddRectangle(theRect);

            if (!Globals.numState)
            {
                thePen = new Pen(Globals.colorBackground);
                theBrush = new SolidBrush(Globals.colorBackground);
            }

            //only draw fill path, which has interesting effect of shrinking path by 1 pixel, resulting in a 15x15 image, which appears quite sharp
            g.FillPath(theBrush, gPath);
            //g.DrawPath(thePen, gPath);

            //////draw CAP text
            //////Cap
            //g.DrawLine(thePen, 0, 11, 0, 15);
            //g.DrawLine(thePen, 0, 11, 3, 11);
            //g.DrawLine(thePen, 0, 15, 3, 15);
            //////cAp
            //g.DrawLine(thePen, 5, 11, 5, 15);
            //g.DrawLine(thePen, 5, 11, 9, 11);
            //g.DrawLine(thePen, 5, 13, 9, 13);
            //g.DrawLine(thePen, 9, 11, 9, 15);
            //////caP
            //g.DrawLine(thePen, 11, 11, 11, 15);
            //g.DrawLine(thePen, 11, 11, 15, 11);
            //g.DrawLine(thePen, 11, 13, 15, 13);
            //g.DrawLine(thePen, 15, 11, 15, 13);

            thePen.Dispose();
            theBrush.Dispose();
            gPath.Dispose();
            thePoints = null;

            return g;
        }

        public static SolidBrush BrushAssign(int x)
        {
            SolidBrush y = new SolidBrush(Globals.colorGreen);

            if (x >= 65)
                y = new SolidBrush(Globals.colorGold);
            if (x >= 85)
                y = new SolidBrush(Globals.colorRed);

            return y;
        }

        public static Pen PenAssign(int x)
        {
            Pen y = new Pen(Globals.colorGreen);

            if (x >= 65)
                y = new Pen(Globals.colorGold);
            if (x >= 85)
                y = new Pen(Globals.colorRed);

            return y;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}