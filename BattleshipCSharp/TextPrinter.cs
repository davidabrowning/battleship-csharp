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
        public static void PrintInfoWithoutLineBreak(string text)
        {
            Console.ForegroundColor = defaultColor;
            Console.Write(text);
        }
        public static void PrintInfoInactive(string text)
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
            Console.WriteLine("\nPress ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = defaultColor;
        }
        public  static void PrintDialogPadder()
        {
            Console.Write("                                             ");
        }
    }
}
