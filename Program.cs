using System;
using System.Threading;
using System.Diagnostics;

using static Multi_Roblox.ConsoleExtensions;
using static Multi_Roblox.Janitor;
using static Multi_Roblox.Imports;

namespace Multi_Roblox
{
    internal class Program
    {
        static ConsoleEventDelegate ExitHandler;
        static void Main(string[] args)
        {
            ExitHandler = new(ConsoleEventCallback);
            SetConsoleCtrlHandler(ExitHandler, true);

            Console.Title = "Multi-Roblox";

            Process[] processes = Process.GetProcessesByName("RobloxPlayerBeta");
            if (processes.Length > 0)
            {
                WriteToConsole("Please close Roblox then relaunch this program.", LogTypes.Error);
                WriteToConsole("Press any key to exit...");
                Console.ReadKey();
                SafeExit();
                return;
            }

            WriteToConsole("Attempting to create the mutex...");
            Mutex mutex = new(true, "ROBLOX_singletonMutex");
            if (mutex == null)
            {
                WriteToConsole("Something went wrong while trying to create the mutex.", LogTypes.Error);
                WriteToConsole("Press any key to exit...");
                Console.ReadKey();
                SafeExit();
                return;
            }
            AddToCache(mutex);
            WriteToConsole("Successfully created the mutex.", LogTypes.Custom, ConsoleColor.Green);
            WriteToConsole("You can now open as many Roblox instances as you want.", LogTypes.Warn);

            WriteToConsole("Press any key to exit...");

            Console.ReadKey();

            SafeExit();
        }

        static bool ConsoleEventCallback(int iEventType)
        {
            if (iEventType == 2) SafeExit();
            return false;
        }
    }
}
