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
        public bool IsSunk()
        {
            return false;
        }
        public bool IsHit(Location location)
        {
            return false;
        }
        public bool Contains(Location location)
        {
            return false;
        }
        public void ProcessHit(Location location)
        {
            Console.WriteLine("Ship.ProcessHit() not yet implemented.");
        }
        public void PlaceRandomly(Board board)
        {
            bool shipLocationsAreAllValid = false;
            Random random = new Random();

            while (shipLocationsAreAllValid == false)
            {
                Locations.Clear();

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
                            Locations.Add(new Location(xstart + i, ystart));
                        }
                        break;
                    case ShipOrientation.Vertical:
                        for (int i = 0; i < Length; i++)
                        {
                            Locations.Add(new Location(xstart, ystart + i));
                        }
                        break;
                    default:
                        break;
                }

                // Check if ship locations are valid
                shipLocationsAreAllValid = AllLocationsAreValid(board);
            }
        }

        private bool AllLocationsAreValid(Board board)
        {
            foreach (Location location in Locations)
            {
                if (!board.IsEmpty(location))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
