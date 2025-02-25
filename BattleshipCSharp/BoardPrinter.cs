using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal static class BoardPrinter
    {
        public static void PrintTitle(Board board)
        {
            TextPrinter.PrintNeutral($"{board.PlayerName} | Attempts: {board.ShotsSustained.Count}");
            TextPrinter.PrintBlankSpace(24);
        }
        public static void PrintColumnHeaders(Board board)
        {
            TilePrinter.PrintBlankTile();
            for (int x = Board.XMin; x <= Board.XMax; x++)
                TilePrinter.PrintHeaderTile(x.ToString());
            TilePrinter.PrintBlankTile();
        }
        public static void PrintBoardRow(Board board, int y)
        {
            PrintRowHeader(y);
            PrintRowTiles(board, y);
            PrintRowHeader(y);
        }
        private static void PrintRowHeader(int y)
        {
            TilePrinter.PrintHeaderTile($"{(char)(65 + y)}");
        }
        private static void PrintRowTiles(Board board, int y)
        {
            for (int x = Board.XMin; x <= Board.XMax; x++)
                PrintTile(board, y, x);
        }
        private static void PrintTile(Board board, int y, int x)
        {
            Location location = new Location(x, y);
            if (board.Fleet.IsSunk(location))           // Sunk ship
                TilePrinter.PrintSunkTile();
            else if (board.Fleet.IsHit(location))       // Hit ship
                TilePrinter.PrintHitTile();
            else if (board.Fleet.Contains(location))    // Unhit (hidden) ship
                TilePrinter.PrintHeaderTile("s");
            else if (board.ShotsSustained.Contains(location)) // Missed shot attempt
                TilePrinter.PrintMissTile();
            else
                TilePrinter.PrintOpenOceanTile();       // Open ocean
        }
    }
}
