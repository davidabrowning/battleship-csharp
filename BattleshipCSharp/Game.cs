using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal abstract class Game
    {
        // Fields
        Board board;
        private List<Board> boards;

        // Properties
        public int AttemptsCompleted { get { return CalculateAttemptsCompleted(boards); } }
        public bool IsOver { get { return CheckForGameOver(boards);  } }

        public Game()
        {
            boards = new List<Board>();
            boards.Add(new Board());
        }
        public void Go()
        {
            board = boards[0];
            BoardPrinter.Print(board);
            while (!IsOver)
                NextTurn(board);
            TextPrinter.PrintSuccess($"\nYou won the game in {board.Attempts.Count} attempts!");
        }
        private int CalculateAttemptsCompleted(List<Board> boards)
        {
            int attemptsCompleted = 0;
            foreach (Board board in boards)
                attemptsCompleted += board.Attempts.Count;
            return attemptsCompleted;
        }

        private bool CheckForGameOver(List<Board> boards)
        {
            foreach (Board board in boards)
                if (board.Fleet.IsSunk())
                    return true;
            return false;
        }

        private void NextTurn(Board board)
        {
            Location location = AskUserForLocation(board);
            if (location == null)
                return;
            board.ProcessAttempt(location);
            BoardPrinter.Print(board);
        }

        private Location? AskUserForLocation(Board board)
        {
            TextPrinter.PrintPrompt($"\n{board.Attempts.Count} attempts | Choose a location: ");
            string userInput = Console.ReadLine().ToUpper().Trim();
            if (userInput == "Q")
                QuitGame();
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
