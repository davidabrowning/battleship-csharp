using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal static class BoardPrinter
    {

        public static void Print(Game game)
        {
            Console.Clear();
            PrintBoardTitles(game);
            PrintTileArea(game);
        }
        private static void PrintBoardTitles(Game game)
        {
            foreach (Board board in game.Boards)
                PrintBoardTitle(board);
            TextPrinter.PrintBlankLine(2);
        }
        private static void PrintBoardTitle(Board board)
        {
            TextPrinter.PrintInfoWithoutLineBreak(
                $"{board.PlayerName} | Attempts: {board.Attempts.Count}");
            TextPrinter.PrintBlankSpace(24);
        }
        private static void PrintGameHeaders(Game game)
        {
            TilePrinter.PrintBlankTile();
            foreach (Board board in game.Boards)
                PrintBoardHeaders(board);
            Console.WriteLine();
        }

        private static void PrintBoardHeaders(Board board)
        {
            PrintHeaderTiles(board);
            TilePrinter.PrintBlankTile(5);
        }

        private static void PrintHeaderTiles(Board board)
        {
            for (int x = board.XMin; x <= board.XMax; x++)
                TilePrinter.PrintHeaderTile(x.ToString());
        }

        private static void PrintTileArea(Game game)
        {
            PrintGameHeaders(game);
            for (int y = game.YMin; y <= game.YMax; y++)
                PrintGameRow(game, y);
            PrintGameHeaders(game);
        }
        private static void PrintGameRow(Game game, int y)
        {
            foreach (Board board in game.Boards)
                PrintBoardRow(board, y);
            TextPrinter.PrintBlankLine();
        }
        private static void PrintBoardRow(Board board, int y)
        {
            PrintRowHeader(y);
            PrintRowTiles(board, y);
            PrintRowHeader(y);
            TilePrinter.PrintBlankTile(3);
        }
        private static void PrintRowHeader(int y)
        {
            TilePrinter.PrintHeaderTile($"{(char)(65 + y)}");
        }
        private static void PrintRowTiles(Board board, int y)
        {
            for (int x = board.XMin; x <= board.XMax; x++)
                PrintTile(board, y, x);
        }
        private static void PrintTile(Board board, int y, int x)
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
