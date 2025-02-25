using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Chat
    {
        public ConsoleColor Color { get; private set; }
        public string Text { get; private set; }
        public Chat(ConsoleColor color, string text)
        {
            Color = color;
            Text = text;
        }
    }
}
