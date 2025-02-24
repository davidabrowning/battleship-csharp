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
            TextPrinter.PrintWelcomeTitle("Hello, Admiral. Welcome to Battleship.");
            ShowMenu();
        }
        private void ShowMenu()
        {
            PrintMenuOptions();
            HandleMenuInput();
        }
        private void PrintMenuOptions()
        {
            TextPrinter.PrintPageTitle("Battleship: Main Menu");
            TextPrinter.PrintNeutral("[1] Start single player game");
            TextPrinter.PrintNeutral("[2] Start game against the computer");
            TextPrinter.PrintNeutral("[3] Start multiplayer game");
            TextPrinter.PrintNeutral("[Q] Quit");
        }
        private void HandleMenuInput()
        {
            switch (Console.ReadLine().Trim().ToUpper())
            {
                case "1":
                    StartSinglePlayerGame();
                    break;
                case "2":
                    StartGameVsComputer();
                    ShowMenu();
                    break;
                case "3":
                    StartMultiplayerGame();
                    break;
                case "Q":
                    TextPrinter.PrintNeutral("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    TextPrinter.PrintWarning("Invalid input.");
                    ShowMenu();
                    break;
            }
            ShowMenu();
        }
        private void StartSinglePlayerGame()
        {
            Game game = new GameVsSelf();
            game.Go();
        }
        private void StartGameVsComputer()
        {
            Game game = new GameVsComputer();
            game.Go();
        }
        private void StartMultiplayerGame()
        {
            Game game = new GameVsHuman();
            game.Go();
        }
    }
}
