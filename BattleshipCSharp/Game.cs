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
        public Player CurrentPlayer { get { return Players.ElementAt(CalculateTotalShots() % Players.Count); } }
        public bool IsOver { get { return CheckForGameOver();  } }
        public List<Player> Players { get; private set; }

        public Game()
        {
            gamePrinter = new GamePrinter(this);
            Players = new List<Player>();
        }
        public void Go()
        {
            gamePrinter.PrintAll();
            while (!IsOver)
                NextTurn(CurrentPlayer);
            ChatPrinter.PrintSuccess($"\nYou won the game in { CalculateMaxShots() } attempts!");
        }
        private int CalculateTotalShots()
        {
            int shotsTaken = 0;
            foreach (Player player in Players)
                shotsTaken += player.ShotsTaken;
            return shotsTaken;
        }

        private int CalculateMaxShots()
        {
            int maxShotsTaken = 0;
            foreach (Player player in Players)
                maxShotsTaken = Math.Max(maxShotsTaken, player.ShotsTaken);
            return maxShotsTaken;
        }

        private bool CheckForGameOver()
        {
            foreach (Player player in Players)
                if (player.IsVictorious)
                    return true;
            return false;
        }

        private void NextTurn(Player player)
        {
            if (Players.IndexOf(CurrentPlayer) == 0)
                ChatPrinter.RemovePadding();
            else
                ChatPrinter.AddPadding();
            Location location = AskUserForLocation(player.OpponentBoard);
            if (location == null)
                return;
            ChatLog.Clear();
            player.OpponentBoard.ProcessAttempt(location);
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
                if (x < Board.XMin || x > Board.XMax || y < Board.YMin || y > Board.YMax)
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
