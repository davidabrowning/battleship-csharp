using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class ComputerPlayer : Player
    {
        public ComputerPlayer() : base("Computer")
        {

        }
        public override void TakeShot()
        {
            ChatLog.Clear();
            Location location = GetNextMove();

            Thread.Sleep(2000);
            ChatPrinter.PrintPrompt(""); // Indents and formats computer dialog as if it were really "talking"
            Console.Write("Hmm... ");
            Thread.Sleep(2000);
            Console.Write("Let me think... ");
            Thread.Sleep(2000);
            Console.WriteLine($"Maybe {location}?");
            Thread.Sleep(1000);

            OpponentBoard.SustainShot(location);

            Thread.Sleep(2000);
            
        }
        private Location GetNextMove()
        {
            Random rand = new Random();
            List<Location> topLocations = CalculateTopLocations(OpponentBoard);
            Location location = topLocations[rand.Next(0, topLocations.Count)];
            return location;
        }

        public int CalculateRating(Board board, Location location)
        {
            int rating = 0;

            // Bonuses for adjacent hit tiles
            if (board.Fleet.IsHitButNotSunk(new Location(location.XPos + 1, location.YPos)))
                rating += 10000;
            if (board.Fleet.IsHitButNotSunk(new Location(location.XPos - 1, location.YPos)))
                rating += 10000;
            if (board.Fleet.IsHitButNotSunk(new Location(location.XPos, location.YPos + 1)))
                rating += 10000;
            if (board.Fleet.IsHitButNotSunk(new Location(location.XPos, location.YPos - 1)))
                rating += 10000;

            // Bonuses for two-in-a-row adjacent hit tiles
            if (board.Fleet.IsHitButNotSunk(new Location(location.XPos + 2, location.YPos)))
                rating += 100;
            if (board.Fleet.IsHitButNotSunk(new Location(location.XPos - 2, location.YPos)))
                rating += 100;
            if (board.Fleet.IsHitButNotSunk(new Location(location.XPos, location.YPos + 2)))
                rating += 100;
            if (board.Fleet.IsHitButNotSunk(new Location(location.XPos, location.YPos - 2)))
                rating += 100;

            for (int i = 0; i < board.Fleet.LongestUnsunkShip.Length; i++)
            {
                // Bonuses for adjacent empty tiles
                if (board.ValidAttemptLocation(new Location(location.XPos + i, location.YPos)))
                    rating++;
                if (board.ValidAttemptLocation(new Location(location.XPos - i, location.YPos)))
                    rating++;
                if (board.ValidAttemptLocation(new Location(location.XPos, location.YPos + i)))
                    rating++;
                if (board.ValidAttemptLocation(new Location(location.XPos, location.YPos - i)))
                    rating++;
            }

            // Penalty if this location is invalid
            if (!board.ValidAttemptLocation(location))
                rating = -100;

            return rating;
        }

        public List<Location> CalculateTopLocations(Board board)
        {
            List<Location> topLocations = new List<Location>();
            for (int x = Board.XMin; x <= Board.XMax; x++)
            {
                for (int y = Board.YMin; y <= Board.YMax; y++)
                {
                    Location location = new Location(x, y);
                    if (topLocations.Count == 0)
                        topLocations.Add(location);
                    else if (CalculateRating(board, location) == CalculateRating(board, topLocations.First()))
                        topLocations.Add(location);
                    else if (CalculateRating(board, location) > CalculateRating(board, topLocations.First())) {
                        topLocations.Clear();
                        topLocations.Add(location);
                    }
                }
            }
            return topLocations;
        }
    }
}
