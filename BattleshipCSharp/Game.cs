using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal abstract class Game
    {

        // Properties
        public int AttemptsCompleted { get { return CalculateAttemptsCompleted(Boards); } }
        public int NumPlayers { get { return Boards.Count; } }
        public Board CurrentBoard { get { return Boards[CurrentPlayer]; } }
        public int CurrentPlayer { get { return AttemptsCompleted % NumPlayers; } }
        public int XMin { get { return Boards[0].XMin; } }
        public int XMax { get { return Boards[0].XMax; } }
        public int YMin { get { return Boards[0].YMin; } }
        public int YMax { get { return Boards[0].YMax; } }
        public bool IsOver { get { return CheckForGameOver(Boards);  } }
        public List<Board> Boards { get; private set; }

        public Game()
        {
            Boards = new List<Board>();
        }
        public void Go()
        {
            BoardPrinter.Print(this);
            while (!IsOver)
                NextTurn(CurrentBoard);
            TextPrinter.PrintSuccess($"\nYou won the game!");
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
            if (CurrentPlayer > 0)
                TextPrinter.PrintDialogPadder();
            board.ProcessAttempt(location);
            BoardPrinter.Print(this);
        }

        private Location? AskUserForLocation(Board board)
        {
            Console.WriteLine();
            if (CurrentPlayer > 0)
                TextPrinter.PrintDialogPadder();
            TextPrinter.PrintPrompt($"Choose a location: ");
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
