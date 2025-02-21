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
            PrintBoardTitles();
            PrintTileArea();
        }
        private void PrintBoardTitles()
        {
            foreach (Board board in game.Boards)
                PrintBoardTitle(board);
            TextPrinter.PrintBlankLine(2);
        }
        private void PrintBoardTitle(Board board)
        {
            TextPrinter.PrintInfoWithoutLineBreak(
                $"{board.PlayerName} | Attempts: {board.Attempts.Count}");
            TextPrinter.PrintBlankSpace(24);
        }
        private void PrintGameHeaders()
        {
            TilePrinter.PrintBlankTile();
            foreach (Board board in game.Boards)
                PrintBoardHeaders(board);
            Console.WriteLine();
        }

        private void PrintBoardHeaders(Board board)
        {
            PrintHeaderTiles(board);
            TilePrinter.PrintBlankTile(5);
        }

        private void PrintHeaderTiles(Board board)
        {
            for (int x = board.XMin; x <= board.XMax; x++)
                TilePrinter.PrintHeaderTile(x.ToString());
        }

        private void PrintTileArea()
        {
            PrintGameHeaders();
            for (int y = game.YMin; y <= game.YMax; y++)
                PrintGameRow(y);
            PrintGameHeaders();
        }
        private void PrintGameRow(int y)
        {
            foreach (Board board in game.Boards)
                PrintBoardRow(board, y);
            TextPrinter.PrintBlankLine();
        }
        private void PrintBoardRow(Board board, int y)
        {
            PrintRowHeader(y);
            PrintRowTiles(board, y);
            PrintRowHeader(y);
            TilePrinter.PrintBlankTile(3);
        }
        private void PrintRowHeader(int y)
        {
            TilePrinter.PrintHeaderTile($"{(char)(65 + y)}");
        }
        private void PrintRowTiles(Board board, int y)
        {
            for (int x = board.XMin; x <= board.XMax; x++)
                PrintTile(board, y, x);
        }
        private void PrintTile(Board board, int y, int x)
        {
            Location location = new Location(x, y);
            if (board.Fleet.IsSunk(location))
                TilePrinter.PrintSunkTile();
            else if (board.Fleet.IsHit(location))
                TilePrinter.PrintHitTile();
            else if (board.Fleet.Contains(location))
                TilePrinter.PrintEmptyTile();
            else if (board.Attempts.Contains(location))
                TilePrinter.PrintMissTile();
            else
                TilePrinter.PrintEmptyTile();
        }
    }
}
