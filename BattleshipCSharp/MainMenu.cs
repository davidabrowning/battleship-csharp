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
            TextPrinter.PrintLineNeutral("Hello, Admiral. Welcome to Battleship.");
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
            TextPrinter.PrintLineNeutral("[1] Start single player game");
            TextPrinter.PrintLineNeutral("[2] Start game against the computer");
            TextPrinter.PrintLineNeutral("[3] Start multiplayer game");
            TextPrinter.PrintLineNeutral("[Q] Quit");
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
                    break;
                case "3":
                    StartMultiplayerGame();
                    break;
                case "Q":
                    TextPrinter.PrintLineNeutral("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    TextPrinter.PrintLineWarning("Invalid input.");
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
