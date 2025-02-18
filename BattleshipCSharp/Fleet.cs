using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Fleet : IAttackable
    {
        public List<Ship> Ships { get; private set; }
        public int Size { get { return Ships.Count; } }
        public Fleet()
        {
            Ships = new List<Ship>();
        }
        public void Add(Ship ship)
        {
            Console.WriteLine("Fleet.Add() not yet implemented.");
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
            Console.WriteLine("Fleet.ProcessHit() not yet implemented.");
        }
        public void PlaceRandomly(Board board)
        {
            Console.WriteLine("Fleet.PlaceRandomly() not yet implemented.");
        }
    }
}
