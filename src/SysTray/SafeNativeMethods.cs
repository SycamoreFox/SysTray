using System;
using System.Runtime.InteropServices;

namespace SysTray
{
    class SafeNativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool DestroyIcon(IntPtr handle);
    }
}