using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Game
    {
        Board board;
        public Game()
        {
            board = new Board();
        }
        public void Go()
        {
            BoardPrinter.Print(board);
            while (board.Fleet.IsSunk() == false)
            {
                TextPrinter.PrintPrompt($"\n{board.Attempts.Count} attempts | Choose a location: ");
                string userInput = Console.ReadLine().ToUpper().Trim();

                if (userInput.Length < 2)
                {
                    TextPrinter.PrintWarning("Too short");
                    continue;
                }

                string row = userInput.Substring(0, 1);
                string col = userInput.Substring(1);

                int x = -1;
                int y = -1;

                try
                {
                    x = int.Parse(col);
                    y = (int)Convert.ToChar(row) - 65;
                }
                catch (Exception ex)
                {
                    TextPrinter.PrintWarning("Invalid input.");
                    continue;
                }

                board.ProcessAttempt(new Location(x, y));
                Console.Clear();
                BoardPrinter.Print(board);
            }
        }
    }
}
