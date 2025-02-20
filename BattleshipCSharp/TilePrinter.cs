using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal static class TilePrinter
    {
        private static ConsoleColor defaultColor = ConsoleColor.White;
        private static void PrintTile(string text)
        {
            Console.Write($" {text} ");
        }
        public static void PrintHeaderTile(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            PrintTile(text);
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintSunkTile()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintTile("X");
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintHitTile()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintTile("X");
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintMissTile()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            PrintTile(" ");
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintEmptyTile()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            PrintTile("#");
            Console.ForegroundColor = defaultColor;
        }
    }
}
