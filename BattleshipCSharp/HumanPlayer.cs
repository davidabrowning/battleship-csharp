using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer() : base("Player") { }
        public HumanPlayer(string name) : this() { }
        public override void TakeShot()
        {
            Location location = GetNextMove();
            if (location == null)
                return; // Get user to try again before proceeding
            ChatLog.Clear();
            OpponentBoard.SustainShot(location);
        }
        private Location GetNextMove()
        {
            ChatPrinter.PrintPrompt($"Choose a location: ");
            string userInput = Console.ReadLine().ToUpper().Trim();
            if (Equals(userInput, "Q"))
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
