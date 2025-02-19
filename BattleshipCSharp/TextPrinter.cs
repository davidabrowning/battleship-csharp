using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal static class TextPrinter
    {
        public static void PrintTile(string text)
        {
            Console.Write($" {text} ");
        }
        public static void PrintSunkTile()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintTile("X");
        }
        public static void PrintHitTile()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintTile("X");
        }
        public static void PrintMissTile()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            PrintTile("O");
        }
        public static void PrintEmptyTile()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            PrintTile("#");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintPrompt(string text)
        {
            Console.Write(text);
        }
        public static void PrintInfo(string text)
        {
            Console.WriteLine(text);
        }
        public static void PrintWarning(string text)
        {
            Console.WriteLine(text);
        }
        public static void PrintSuccess(string text)
        {
            Console.WriteLine(text);
        }
        public static void PrintFailure(string text)
        {
            Console.WriteLine(text);
        }
        public static void ConfirmContinueAndClear()
        {
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
