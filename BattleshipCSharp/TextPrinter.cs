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

        public static void PrintBlankLine(int numLines = 1)
        {
            for (int i = 0; i < numLines; i++)
                Console.WriteLine();
        }
        public static void PrintBlankSpace(int numSpaces = 1)
        {
            for (int i = 0; i < numSpaces; i++)
                Console.Write(" ");
        }
        public static void PrintWelcomeTitle(string text)
        {
            Console.ForegroundColor = defaultColor;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintPageTitle(string text)
        {
            ConfirmContinueAndClear();
            Console.ForegroundColor = defaultColor;
            Console.WriteLine($" ========== {text} ========== ");
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintNeutral(string text)
        {
            Console.ForegroundColor = defaultColor;
            Console.WriteLine(text);
        }
        public static void PrintNeutralWithoutLineBreak(string text)
        {
            Console.ForegroundColor = defaultColor;
            Console.Write(text);
        }
        public static void PrintInactive(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
        public static void PrintWarning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
        public static void ConfirmContinueAndClear()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = defaultColor;
        }
    }
}
