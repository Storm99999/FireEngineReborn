using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEngine.src.ColorfulConsole
{
    internal class FireConsole
    {
        public static void WriteLine(string message, string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("] " + message + "\n");
        }
    }
}
