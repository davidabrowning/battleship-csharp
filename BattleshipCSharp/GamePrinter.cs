using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class GamePrinter
    {
        Game game;
        public GamePrinter(Game game)
        {
            this.game = game;
        }

        public void PrintAll()
        {
            Console.Clear();
            PrintTitleArea();
            PrintPlayingArea();
            ChatLog.Print();
        }
        private void PrintTitleArea()
        {
            foreach (Player player in game.Players)
                BoardPrinter.PrintTitle(player);
            TextPrinter.PrintBlankLine();
        }
        private void PrintPlayingArea()
        {
            PrintAllColumnHeaders();
            for (int y = Board.YMin; y <= Board.YMax; y++)
                PrintPlayingAreaRow(y);
            PrintAllColumnHeaders();
        }
        private void PrintAllColumnHeaders()
        {
            foreach (Player player in game.Players)
            {
                BoardPrinter.PrintColumnHeaders(player.OpponentBoard);
                PrintBoardSpacer();
            }
            TextPrinter.PrintBlankLine();
        }
        private void PrintPlayingAreaRow(int y)
        {
            foreach (Player player in game.Players)
            {
                BoardPrinter.PrintBoardRow(player.OpponentBoard, y);
                PrintBoardSpacer();
            }
            TextPrinter.PrintBlankLine();
        }
        private void PrintBoardSpacer()
        {
            TilePrinter.PrintBlankTile(3);
        }
    }
}
