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

        public static void Print(Board board)
        {
            Console.Clear();
            PrintColumnHeaders(board);
            PrintBoardArea(board);
            PrintColumnHeaders(board);
        }
        private static void PrintColumnHeaders(Board board)
        {
            TextPrinter.PrintHeaderTile(" ");
            for (int x = board.XMin; x <= board.XMax; x++)
            {
                TextPrinter.PrintHeaderTile(x.ToString());
            }
            Console.WriteLine();
        }
        private static void PrintBoardArea(Board board)
        {
            for (int y = board.YMin; y <= board.YMax; y++)
            {
                PrintRowHeader(y);
                for (int x = board.XMin; x <= board.XMax; x++)
                {
                    Location location = new Location(x, y);
                    if (board.Fleet.IsSunk(location))
                        TextPrinter.PrintSunkTile();
                    else if (board.Fleet.IsHit(location))
                        TextPrinter.PrintHitTile();
                    else if (board.Fleet.Contains(location))
                        TextPrinter.PrintEmptyTile();
                    else if (board.Attempts.Contains(location))
                        TextPrinter.PrintMissTile();
                    else
                        TextPrinter.PrintEmptyTile();
                }
                PrintRowHeader(y);
                Console.WriteLine();
            }
        }
        private static void PrintRowHeader(int y)
        {
            TextPrinter.PrintHeaderTile($"{(char)(65 + y)}");
        }
    }
}
