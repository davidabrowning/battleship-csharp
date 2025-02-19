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
                NextTurn();
            }
            TextPrinter.PrintSuccess($"\nYou won the game in {board.Attempts.Count} attempts!");
        }
        private void NextTurn()
        {
            Location location = AskUserForLocation();
            if (location == null)
            {
                return;
            }
            board.ProcessAttempt(location);
            BoardPrinter.Print(board);
        }

        private Location? AskUserForLocation()
        {
            TextPrinter.PrintPrompt($"\n{board.Attempts.Count} attempts | Choose a location: ");
            string userInput = Console.ReadLine().ToUpper().Trim();
            if (userInput == "Q")
            {
                QuitGame();
                return null;
            }
            try
            {
                string row = userInput.Substring(0, 1);
                string col = userInput.Substring(1);
                int x = int.Parse(col);
                int y = (int)Convert.ToChar(row) - 65;
                return new Location(x, y);
            }
            catch (Exception ex)
            {
                TextPrinter.PrintWarning("Invalid input.");
                return null;
            }
        }

        private void QuitGame()
        {
            TextPrinter.PrintWarning("Game over.");
            Environment.Exit(0);
        }
    }
}
