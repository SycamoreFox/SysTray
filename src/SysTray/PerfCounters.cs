using System;
using System.Windows.Forms;

namespace SysTray
{
    class PerfCounters : IDisposable
    {
        public static int GetUsageValue(string iconType)
        {
            int x = 0;

            switch (iconType)
            {
                case "cpu":
                    x = GetCpuUsage();
                    break;

                case "mem":
                    x = GetMemUsage();
                    break;

                case "dsk":
                    GetDiskUsage();
                    break;

                case "net":
                    {
                        GetNetUsageSent();
                        GetNetUsageReceived();
                        break;
                    }
                case "cap":
                    {
                        GetKeyState(Keys.CapsLock);
                        break;
                    }
                case "num":
                    {
                        GetKeyState(Keys.NumLock);
                        break;
                    }
            }

            return x;
        }

        public static int GetCpuUsage()
        {
            return (int)Globals.cpuCounter.NextValue();
        }

        public static int GetMemUsage()
        {
            double freeMem = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;

            double availMem = new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory;

            double usedMem = (availMem / freeMem) * 100;

            return 100 - Convert.ToInt32(usedMem);
        }

        public static void GetDiskUsage()
        {
            Globals.diskReadValue = Globals.diskRead.NextValue();
        }

        public static void GetNetUsageSent()
        {
            Globals.kbSent = Globals.netCounterSent.NextValue();
        }

        public static void GetNetUsageReceived()
        {
            Globals.kbReceived = Globals.netCounterReceived.NextValue();
        }

        public static void GetKeyState(Keys theKey)
        {
            bool keyState = Control.IsKeyLocked(theKey);

            switch (theKey)
            {
                case Keys.CapsLock:
                    if (keyState != Globals.capState)
                        Globals.capState = keyState;
                    break;
                case Keys.NumLock:
                    if (keyState != Globals.numState)
                        Globals.numState = keyState;
                    break;
            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}