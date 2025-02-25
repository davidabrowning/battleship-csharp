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
        public HumanPlayer(string name) : base(name) { }
        public override void TakeShot()
        {
            Location location = GetNextMove();
            ChatLog.Clear();
            OpponentBoard.SustainShot(location);
        }
        private Location GetNextMove()
        {
            while (true)
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
                    Location shotLocation = new Location(x, y);
                    if (OpponentBoard.ValidAttemptLocation(shotLocation))
                        return new Location(x, y);
                    ChatPrinter.PrintWarning("Invalid coordinates.");
                }
                catch (Exception ex)
                {
                    ChatPrinter.PrintWarning("Invalid input.");
                }
            }
        }
        private void QuitGame()
        {
            ChatPrinter.PrintWarning("Game over.");
            Environment.Exit(0);
        }
    }
}
