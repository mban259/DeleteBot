using System;

namespace DeleteBot.Utils
{
    static class Debug
    {
        internal static void Log(object obj)
        {
            Console.WriteLine($"{DateTime.Now} {obj}");
        }
    }
}
