using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace SysTray
{
    class Globals : IDisposable
    {
        //icons
        public static List<NotifyIcon> iconList = new List<NotifyIcon>();
        //public static NotifyIcon icon1 = new NotifyIcon();
        public static ContextMenu cms = new ContextMenu();

        //performance counters
        public static PerformanceCounter cpuCounter = new PerformanceCounter(
            categoryName: "Processor",
            instanceName: "_Total",
            counterName: "% Processor Time"
            );
        public static int[] cpuDrawHeight = new int[8];

        public static PerformanceCounter ramFree = new PerformanceCounter(
            categoryName: "Memory",
            counterName: "Available MBytes"
            );
        public static int[] memDrawHeight = new int[8];

        public static PerformanceCounter diskRead = new PerformanceCounter(
            categoryName: "PhysicalDisk",
            counterName: "Disk Reads/sec",
            instanceName: "_Total"
            );

        public static PerformanceCounter diskWrite = new PerformanceCounter(
            categoryName: "PhysicalDisk",
            counterName: "Disk Writes/sec",
            instanceName: "_Total"
            );

        public static PerformanceCounter diskActivity = new PerformanceCounter(
            categoryName: "PhysicalDisk",
            counterName: "Disk Transfers/sec",
            instanceName: "_Total"
            );

        public static float diskReadValue, diskWriteValue;

        public static PerformanceCounterCategory netPerformance = new PerformanceCounterCategory("Network Interface");
        public static string instanceName;

        public static float kbSent, kbReceived;

        public static PerformanceCounter netCounterSent = new PerformanceCounter(
            categoryName: "Network Interface",
            counterName: "Bytes Sent/sec"
            );
        public static PerformanceCounter netCounterReceived = new PerformanceCounter(
            categoryName: "Network Interface",
            counterName: "Bytes Received/sec"
            );

        public static bool capState, capPopupState;
        public static bool numState;

        //static colors
        public static Color colorTransparent = Color.Transparent;
        public static Color colorWhite = Color.White;
        public static Color colorBlack = Color.Black;
        //from fluentcolor.com which is a simple expansion of the standard Windows 10 color scheme (see color picker in personalizations)
        public static Color colorBackground = ColorTranslator.FromHtml("#68768A");
        public static Color colorGreen = ColorTranslator.FromHtml("#00CC6A");
        public static Color colorGold = ColorTranslator.FromHtml("#FFB900");
        public static Color colorRed = ColorTranslator.FromHtml("#E81123");

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}