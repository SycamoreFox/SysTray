using System;
using System.Drawing;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace SysTray
{
    class IconManager : IDisposable
    {
        private string iconType;
        private int iconIndex;
        //private int usageValue;
        public System.Timers.Timer t = new System.Timers.Timer();

        public void IconGenerate(int inputIconIndex, int inputInterval, string passedIconType)
        {
            //assign class variables as cannot pass to a timer event
            iconIndex = inputIconIndex;
            iconType = passedIconType;

            Globals.iconList[iconIndex].Tag =
            //set icon visibility
            Globals.iconList[iconIndex].Visible = true;

            t.Interval = inputInterval;
            t.Elapsed += TimerTick;
            t.Start();

            //assign the right click menu to the icon
            ContextMenu cms = new ContextMenu();
            cms.MenuCreate(iconIndex);
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            //create a Task to asynchronously perform the icon draw update 
            Task taskDrawIcon = Task.Factory.StartNew(() => IconRefresh(iconType, iconIndex));
        }

        public void IconRefresh(string iconType, int iconIndex)
        {
            try
            {
                int usageValue = 0;

                usageValue = PerfCounters.GetUsageValue(iconType);

                //create a bitmap object from an image file
                Bitmap theBitmap = new Bitmap(16, 16);
                //draw the bitmap graphics
                Graphics g = IconDraw.DrawGraphics(theBitmap, usageValue, iconType);

                //get an Hicon for the bitmap
                IntPtr hIcon = theBitmap.GetHicon();
                //create a new icon from the handle
                Icon newIcon = Icon.FromHandle(hIcon);
                //set the form icon attribute to the new icon
                Globals.iconList[iconIndex].Icon = newIcon;

                //set the tooltip text
                StringBuilder sb = new StringBuilder();

                switch (iconType)
                {
                    case "cpu":
                        sb = new StringBuilder("CPU: " + usageValue + "%");
                        break;

                    case "mem":
                        sb = new StringBuilder("MEM: " + usageValue + "%");
                        break;

                    case "cap":
                        if (Globals.capState)
                            sb = new StringBuilder("Caps Lock ON");
                        else
                            sb = new StringBuilder("Caps Lock OFF");
                        break;

                    case "num":
                        if (Globals.numState)
                            sb = new StringBuilder("Number Lock ON");
                        else
                            sb = new StringBuilder("Number Lock OFF");
                        break;
                }

                Globals.iconList[iconIndex].Text = sb.ToString();

                //dispose GDI elements (memory garbage collection)
                sb = null;
                theBitmap.Dispose();
                g.Dispose();
                SafeNativeMethods.DestroyIcon(hIcon);
                SafeNativeMethods.DestroyIcon(newIcon.Handle);
                newIcon.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}