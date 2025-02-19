using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal static class TextPrinter
    {
        private static ConsoleColor defaultColor = ConsoleColor.White;
        public static void PrintTile(string text)
        {
            Console.Write($" {text} ");
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
            PrintTile("O");
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintEmptyTile()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            PrintTile("#");
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintPrompt(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(text);
        }
        public static void PrintInfo(string text)
        {
            Console.ForegroundColor = defaultColor;
            Console.WriteLine(text);
        }
        public static void PrintWarning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintSuccess(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintFailure(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
        public static void ConfirmContinueAndClear()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = defaultColor;
        }
    }
}
