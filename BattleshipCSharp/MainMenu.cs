using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class MainMenu
    {
        public void Go()
        {
            ShowMenu();
        }
        private void ShowMenu()
        {
            TextPrinter.PrintPageTitle("Main Menu");
            TextPrinter.PrintInfo("[1] Start single player game");
            TextPrinter.PrintInfo("[2] Start game against the computer (coming soon)");
            TextPrinter.PrintInfo("[3] Start multiplayer game (coming soon)");
            TextPrinter.PrintInfo("[Q] Quit");
            switch(Console.ReadLine().Trim().ToUpper())
            {
                case "1":
                    StartSinglePlayerGame();
                    break;
                case "2":
                    TextPrinter.PrintWarning("This feature is coming soon.");
                    ShowMenu();
                    break;
                case "3":
                    TextPrinter.PrintWarning("This feature is coming soon.");
                    ShowMenu();
                    break;
                case "Q":
                    TextPrinter.PrintInfo("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    TextPrinter.PrintWarning("Invalid input.");
                    ShowMenu();
                    break;
            }
        }
        private void StartSinglePlayerGame()
        {
            Game game = new Game();
            game.Go();
        }
    }
}
