using System.Runtime.InteropServices;
using System;

namespace Multi_Roblox
{
    internal class Imports
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        internal static extern IntPtr FindWindow(string szClass, string szWindow);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        internal delegate bool ConsoleEventDelegate(int eventType);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
    }
}
