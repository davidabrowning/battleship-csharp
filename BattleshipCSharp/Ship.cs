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
            Random random = new Random();
            int xstart = random.Next(0, 100);
            for(int i = 0; i < Length; i++)
            {
                Locations.Add(new Location(xstart + i, 0));
            }
        }
    }
}
