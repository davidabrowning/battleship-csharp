using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Ship : IAttackable
    {
        public string Name { get; private set; }
        public int Length { get; private set; }
        public List<Location> Locations { get; private set; }
        public List<Location> Hits { get; private set; }
        public Ship(string name, ShipLength length)
        {
            Name = name;
            Length = (int)length;
            Locations = new List<Location>();
            Hits = new List<Location>();
        }
        public bool IsHit(Location location)
        {
            return Hits.Contains(location);
        }
        public bool IsSunk()
        {
            return Locations.Count == Hits.Count;
        }
        public bool Contains(Location location)
        {
            return Locations.Contains(location);
        }
        public void ProcessHit(Location location)
        {
            Hits.Add(location);
            if (IsSunk())
                TextPrinter.PrintSuccess(Name + " has been hit and sunk!");
            else
                TextPrinter.PrintSuccess("Hit!");
        }
        public void PlaceRandomly(Board board)
        {
            List<Location> potentialLocations = new List<Location>();
            bool potentialLocationsAreEmpty = false;
            Random random = new Random();

            while (potentialLocationsAreEmpty == false)
            {
                potentialLocations.Clear();

                // Choose ship orientation
                ShipOrientation orientation = (ShipOrientation)random.Next(0, 2);

                // Choose ship origin
                int xstart = random.Next(board.XMin, board.XMax + 1);
                int ystart = random.Next(board.YMin, board.YMax + 1);

                switch (orientation)
                {
                    case ShipOrientation.Horizontal:
                        for (int i = 0; i < Length; i++)
                        {
                            potentialLocations.Add(new Location(xstart + i, ystart));
                        }
                        break;
                    case ShipOrientation.Vertical:
                        for (int i = 0; i < Length; i++)
                        {
                            potentialLocations.Add(new Location(xstart, ystart + i));
                        }
                        break;
                    default:
                        break;
                }

                // Check if ship locations are valid
                potentialLocationsAreEmpty = board.IsEmpty(potentialLocations);
            }

            Locations = potentialLocations;
        }
    }
}
