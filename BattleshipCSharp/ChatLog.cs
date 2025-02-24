using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal static class ChatLog
    {
        private static List<Chat> chats = new List<Chat>();
        public static void Add(Chat chat)
        {
            chats.Add(chat);
        }
        public static void Print()
        {
            TextPrinter.PrintBlankLine();
            foreach (Chat chat in chats)
            {
                Console.ForegroundColor = chat.Color;
                Console.WriteLine(chat.Text);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Clear()
        {
            chats.Clear();
        }
    }
}