using System;

namespace Multi_Roblox
{
    internal class ConsoleExtensions
    {
        internal enum LogTypes
        {
            Info,
            Warn,
            Error,
            Custom
        }

        internal static void WriteToConsole(string szText, LogTypes? ltType = LogTypes.Info, ConsoleColor? ccColor = default)
        {
            if (string.IsNullOrWhiteSpace(szText)) return;

            if (ltType.HasValue)
            {
                switch (ltType)
                {
                    case LogTypes.Warn:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case LogTypes.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case LogTypes.Custom:
                        if (ccColor.HasValue) Console.ForegroundColor = (ConsoleColor)ccColor;
                        break;
                }
            }

            Console.WriteLine(szText);
            Console.ResetColor();
        }
    }
}