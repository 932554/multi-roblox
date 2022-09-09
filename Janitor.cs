using System;
using System.Collections.Generic;

namespace Multi_Roblox
{
    // simple janitor class for caching things
    internal class Janitor
    {
        static List<dynamic> _Cache = new();
        internal static void AddToCache(dynamic dObj) => _Cache.Add(dObj);

        internal static void SafeExit()
        {
            foreach (dynamic i in _Cache) i.Dispose();
            Environment.Exit(0);
        }
    }
}
