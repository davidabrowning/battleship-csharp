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
            foreach (Board board in game.Boards)
                BoardPrinter.PrintTitle(board);
            TextPrinter.PrintBlankLine();
        }
        private void PrintPlayingArea()
        {
            PrintAllColumnHeaders();
            for (int y = game.YMin; y <= game.YMax; y++)
                PrintPlayingAreaRow(y);
            PrintAllColumnHeaders();
        }
        private void PrintAllColumnHeaders()
        {
            foreach (Board board in game.Boards)
            {
                BoardPrinter.PrintColumnHeaders(board);
                PrintBoardSpacer();
            }
            TextPrinter.PrintBlankLine();
        }
        private void PrintPlayingAreaRow(int y)
        {
            foreach (Board board in game.Boards)
            {
                BoardPrinter.PrintBoardRow(board, y);
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
