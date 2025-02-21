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
                TextPrinter.PrintSuccess($"Hit! {Name} has been sunk!");
            else
                TextPrinter.PrintSuccess("Hit!");
        }
        public void PlaceRandomly(Board board)
        {
            List<Location> randomLocations;
            do
                randomLocations = GetRandomLocations(board);
            while (!board.IsEmpty(randomLocations));
            this.Locations = randomLocations;            
        }
        private List<Location> GetRandomLocations(Board board)
        {
            List<Location> randomLocations = new List<Location>();
            Random random = new Random();
            int startingX = random.Next(board.XMin, board.XMax + 1);
            int startingY = random.Next(board.YMin, board.YMax + 1);
            ShipOrientation orientation = (ShipOrientation)random.Next(0, 2);
            if (orientation == ShipOrientation.Horizontal)
                for (int i = 0; i < Length; i++)
                    randomLocations.Add(new Location(startingX + i, startingY));
            else
                for (int i = 0; i < Length; i++)
                    randomLocations.Add(new Location(startingX, startingY + i));
            return randomLocations;
        }
    }
}
