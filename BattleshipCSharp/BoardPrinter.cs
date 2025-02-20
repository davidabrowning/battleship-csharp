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

        public static void Print(List<Board> boards)
        {
            Console.Clear();
            PrintColumnHeaders(boards);
            PrintBoardArea(boards);
            PrintColumnHeaders(boards);
        }
        private static void PrintColumnHeaders(List<Board> boards)
        {
            Board board = boards[0];
            TilePrinter.PrintHeaderTile(" ");
            for (int x = board.XMin; x <= board.XMax; x++)
                TilePrinter.PrintHeaderTile(x.ToString());
            TilePrinter.PrintHeaderTile(" ");
            TilePrinter.PrintHeaderTile(" ");
            TilePrinter.PrintHeaderTile(" ");
            TilePrinter.PrintHeaderTile(" ");
            TilePrinter.PrintHeaderTile(" ");
            for (int x = board.XMin; x <= board.XMax; x++)
                TilePrinter.PrintHeaderTile(x.ToString());
            Console.WriteLine();
        }
        private static void PrintBoardArea(List<Board> boards)
        {
            for (int y = boards[0].YMin; y <= boards[0].YMax; y++)
            {
                foreach (Board board in boards)
                    PrintBoardRow(board, y);
                Console.WriteLine();
            }
        }
        private static void PrintBoardRow(Board board, int y)
        {
            PrintRowHeader(y);
            for (int x = board.XMin; x <= board.XMax; x++)
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
            PrintRowHeader(y);
            TilePrinter.PrintHeaderTile(" ");
            TilePrinter.PrintHeaderTile(" ");
            TilePrinter.PrintHeaderTile(" ");
        }
        private static void PrintRowHeader(int y)
        {
            TilePrinter.PrintHeaderTile($"{(char)(65 + y)}");
        }
    }
}
