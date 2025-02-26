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
                    Location shotLocation = Location.ConvertToLocation(userInput);
                    if (OpponentBoard.ValidAttemptLocation(shotLocation))
                        return shotLocation;
                    else
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
