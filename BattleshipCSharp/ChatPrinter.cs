using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal static class ChatPrinter
    {
        private static ConsoleColor defaultColor = ConsoleColor.White;
        private static string paddingText = "                                             ";
        private static bool padding = false;
        public static void AddPadding()
        {
            padding = true;
        }
        public static void RemovePadding()
        {
            padding = false;
        }
        public static void PrintPrompt(string text)
        {
            if (padding)
                text = paddingText + text;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(text);
            ChatLog.Add(new Chat(ConsoleColor.Cyan, text));
        }
        public static void PrintNeutral(string text)
        {
            if (padding)
                text = paddingText + text;
            Console.ForegroundColor = defaultColor;
            Console.WriteLine(text);
            ChatLog.Add(new Chat(defaultColor, text));
        }
        public static void PrintWarning(string text)
        {
            if (padding)
                text = paddingText + text;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
            ChatLog.Add(new Chat(ConsoleColor.Yellow, text));
        }
        public static void PrintSuccess(string text)
        {
            if (padding)
                text = paddingText + text;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
            ChatLog.Add(new Chat(ConsoleColor.Green, text));
        }
        public static void PrintFailure(string text)
        {
            if (padding)
                text = paddingText + text;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
            ChatLog.Add(new Chat(ConsoleColor.Red, text));
        }
    }
}
