using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class ComputerPlayer : Player
    {
        public ComputerPlayer() : base("Computer")
        {

        }
        public override void TakeShot()
        {
            ChatLog.Clear();
            Location location = GetNextMove();

            Thread.Sleep(2000);
            ChatPrinter.PrintPrompt(""); // Indents and formats computer dialog as if it were really "talking"
            Console.Write("Hmm... ");
            Thread.Sleep(2000);
            Console.Write("Let me think... ");
            Thread.Sleep(2000);
            Console.WriteLine($"Maybe {location}?");
            Thread.Sleep(1000);

            OpponentBoard.SustainShot(location);

            Thread.Sleep(2000);
            
        }
        private Location GetNextMove()
        {
            Random rand = new Random();
            int x;
            int y;
            do
            {
                x = rand.Next(Board.XMin, Board.XMax + 1);
                y = rand.Next(Board.YMin, Board.YMax + 1);
            } while (OpponentBoard.ShotsSustained.Contains(new Location(x, y)));
            return new Location(x, y);
        }
    }
}
