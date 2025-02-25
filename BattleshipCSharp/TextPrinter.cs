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

        public static void PrintPageTitle(string text)
        {
            ConfirmContinueAndClear();
            PrintLineNeutral($" ========== {text} ========== ");
        }
        public static void ConfirmContinueAndClear()
        {
            PrintLineConfirmation("\nPress ENTER to continue.");
            Console.ReadLine(); // The purpose of this ReadLine() is to pause the program until user presses ENTER
            Console.Clear();
        }
        public static void PrintLineNeutral(string text) => PrintLine(text, defaultColor);
        public static void PrintNeutral(string text) => Print(text, defaultColor);
        public static void PrintLineInactive(string text) => PrintLine(text, ConsoleColor.DarkGray);
        public static void PrintLineWarning(string text) => PrintLine(text, ConsoleColor.Yellow);
        public static void PrintLineConfirmation(string text) => PrintLine(text, ConsoleColor.Gray);
        private static void PrintLine(string text, ConsoleColor textColor) => Print(text + "\n", textColor);
        private static void Print(string text, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Console.Write(text);
            Console.ForegroundColor = defaultColor;
        }
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
    }
}
