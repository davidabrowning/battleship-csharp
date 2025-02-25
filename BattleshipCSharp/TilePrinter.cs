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
        private static void PrintTile(string text, ConsoleColor tileColor)
        {
            Console.ForegroundColor = tileColor;
            Console.Write($" {text} ");
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintBlankTile(int numTiles = 1)
        {
            for (int i = 0; i < numTiles; i++)
                PrintTile(" ", defaultColor);
        }
        public static void PrintHeaderTile(string text) => PrintTile(text, ConsoleColor.Gray);
        public static void PrintSunkTile() => PrintTile("X", ConsoleColor.DarkGreen);
        public static void PrintHitTile() => PrintTile("X", ConsoleColor.Red);
        public static void PrintMissTile() => PrintTile(" ", ConsoleColor.Gray);
        public static void PrintOpenOceanTile() => PrintTile("#", ConsoleColor.DarkCyan);
    }
}
