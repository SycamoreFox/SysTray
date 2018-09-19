using System;
using System.Windows.Forms;

namespace SysTray
{
    class MainClass : IDisposable
    {
        [STAThread]

        static void Main(string[] args)
        {
            int x = 0;

            Globals.iconList.Add(new NotifyIcon());
            IconManager trayCPU = new IconManager();
            trayCPU.IconGenerate(x, 500, "cpu");

            x++;

            Globals.iconList.Add(new NotifyIcon());
            IconManager trayMEM = new IconManager();
            trayMEM.IconGenerate(x, 500, "mem");

            x++;

            Globals.iconList.Add(new NotifyIcon());
            IconManager trayDSK = new IconManager();
            trayDSK.IconGenerate(x, 50, "dsk");

            x++;

            Globals.capState = Control.IsKeyLocked(Keys.CapsLock);

            Globals.iconList.Add(new NotifyIcon());
            IconManager trayCAP = new IconManager();
            trayCAP.IconGenerate(x, 100, "cap");

            x++;

            Globals.numState = Control.IsKeyLocked(Keys.NumLock);

            Globals.iconList.Add(new NotifyIcon());
            IconManager trayNUM = new IconManager();
            trayNUM.IconGenerate(x, 100, "num");

            //---------------------------------------------------------------------
            //potential future network monitor if performance load can be decreased

            //Globals.instanceName = Globals.netPerformance.GetInstanceNames()[0];
            //Globals.netCounterSent.InstanceName = Globals.instanceName;
            //Globals.netCounterReceived.InstanceName = Globals.instanceName;

            //x++;

            //Globals.iconList.Add(new NotifyIcon());
            //IconManager trayNET = new IconManager();
            //trayNET.IconGenerate(x, 25, "net");

            Application.Run();
        }

        public static void ExitActions()
        {
            //dispose of icons from the system tray
            foreach (NotifyIcon icon in Globals.iconList)
            {
                icon.Dispose();
            }

            Application.Exit();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
