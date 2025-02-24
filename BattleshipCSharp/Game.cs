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
        private GamePrinter gamePrinter;

        // Properties
        public int AttemptsCompleted { get { return CalculateAttemptsCompleted(Boards); } }
        public int MaxAttempts { get { return Boards[0].Attempts.Count; } }
        public int NumPlayers { get { return Boards.Count; } }
        public Board CurrentBoard { get { return Boards[CurrentPlayer]; } }
        public int CurrentPlayer { get { return AttemptsCompleted % NumPlayers; } }
        public int XMin { get { return Boards[0].XMin; } }
        public int XMax { get { return Boards[0].XMax; } }
        public int YMin { get { return Boards[0].YMin; } }
        public int YMax { get { return Boards[0].YMax; } }
        public bool IsOver { get { return CheckForGameOver(Boards);  } }
        public List<IPlayer> Players { get; private set; }
        public List<Board> Boards { get; private set; }

        public Game()
        {
            gamePrinter = new GamePrinter(this);
            Boards = new List<Board>();
        }
        public void Go()
        {
            gamePrinter.PrintAll();
            while (!IsOver)
                NextTurn(CurrentBoard);
            ChatPrinter.PrintSuccess($"\nYou won the game in { MaxAttempts } attempts!");
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
            if (CurrentPlayer == 0)
                ChatPrinter.RemovePadding();
            else
                ChatPrinter.AddPadding();
            Location location = AskUserForLocation(board);
            if (location == null)
                return;
            ChatLog.Clear();
            board.ProcessAttempt(location);
            gamePrinter.PrintAll();
        }

        private Location? AskUserForLocation(Board board)
        {
            ChatPrinter.PrintPrompt($"Choose a location: ");
            string userInput = Console.ReadLine().ToUpper().Trim();
            if (userInput == "Q")
                QuitGame();
            try
            {
                string row = userInput.Substring(0, 1);
                string col = userInput.Substring(1);
                int y = (int)Convert.ToChar(row) - 65;
                int x = int.Parse(col);
                if (x < XMin || x > XMax || y < YMin || y > YMax)
                {
                    ChatPrinter.PrintWarning("Invalid coordinates.");
                    return null;
                }
                return new Location(x, y);
            }
            catch (Exception ex)
            {
                ChatPrinter.PrintWarning("Invalid input.");
                return null;
            }
        }

        private void QuitGame()
        {
            ChatPrinter.PrintWarning("Game over.");
            Environment.Exit(0);
        }
    }
}
