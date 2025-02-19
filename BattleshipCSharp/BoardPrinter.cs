using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal static class BoardPrinter
    {
        public static void Print(Board board)
        {
            TextPrinter.PrintTile(" ");
            for (int x = board.XMin; x <= board.XMax; x++)
            {
                TextPrinter.PrintTile(x.ToString());
            }
            Console.WriteLine();
            for (int y = board.YMin; y <= board.YMax; y++)
            {
                TextPrinter.PrintTile($"{(char)(65 + y)}");
                for (int x = board.XMin; x <= board.XMax; x++)
                {
                    Location location = new Location(x, y);
                    if (board.Fleet.IsSunk(location))
                    {
                        TextPrinter.PrintSunkTile();
                    }
                    else if (board.Fleet.IsHit(location))
                    {
                        TextPrinter.PrintHitTile();
                    }
                    else if (board.Fleet.Contains(location))
                    {
                        TextPrinter.PrintEmptyTile();
                    }
                    else if (board.Attempts.Contains(location))
                    {
                        TextPrinter.PrintMissTile();
                    }
                    else
                    {
                        TextPrinter.PrintEmptyTile();
                    }
                }
                TextPrinter.PrintTile($"{(char)(65 + y)}");
                Console.WriteLine();
            }

            TextPrinter.PrintTile(" ");
            for (int x = board.XMin; x <= board.XMax; x++)
            {
                TextPrinter.PrintTile(x.ToString());
            }

            Console.WriteLine();
        }
    }
}
