using System.Runtime.InteropServices;
using System;

namespace Multi_Roblox
{
    internal class Imports
    {

        internal delegate bool ConsoleEventDelegate(int eventType);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
    }
}
