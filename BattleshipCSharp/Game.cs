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
            PrintChatPadding();
            player.TakeShot();
            gamePrinter.PrintAll();
        }

        private void PrintChatPadding()
        {
            if (Players.IndexOf(CurrentPlayer) == 0)
                ChatPrinter.RemovePadding();
            else
                ChatPrinter.AddPadding();
        }
    }
}
