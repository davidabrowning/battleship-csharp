using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Fleet : IAttackable
    {
        public List<Ship> Ships { get; private set; }
        public int Size { get { return Ships.Count; } }
        public Ship LongestUnsunkShip { get { return GetLongestUnsunkShip();  } }
        public Fleet()
        {
            Ships = new List<Ship>();
            AddStandardShipsToFleet();
        }
        public void AddStandardShipsToFleet()
        {
            Add(new Ship("Carrier", ShipLength.Carrier));
            Add(new Ship("Battleship", ShipLength.Battleship));
            Add(new Ship("Cruiser", ShipLength.Cruiser));
            Add(new Ship("Submarine", ShipLength.Submarine));
            Add(new Ship("Destroyer", ShipLength.Destroyer));
        }
        public void Add(Ship ship)
        {
            Ships.Add(ship);
        }
        public bool IsSunk()
        {
            foreach (Ship ship in Ships)
                if (!ship.IsSunk())
                    return false;
            return true;
        }
        public bool IsSunk(Location location)
        {
            foreach (Ship ship in Ships)
                if (ship.IsHit(location) && ship.IsSunk())
                    return true;
            return false;
        }
        public bool IsHit(Location location)
        {
            foreach (Ship ship in Ships)
                if (ship.IsHit(location))
                    return true;
            return false;
        }
        public bool IsHitButNotSunk(Location location)
        {
            foreach (Ship ship in Ships)
                if (ship.IsHitButNotSunk(location))
                    return true;
            return false;
        }
        public bool Contains(Location location)
        {
            foreach (Ship ship in Ships)
                if (ship.Contains(location))
                    return true;
            return false;
        }
        public Ship GetLongestUnsunkShip()
        {
            if (IsSunk())
                throw new Exception("No unsunk ships.");

            Ship longestUnsunkShip = null;
            foreach(Ship ship in Ships)
                if (longestUnsunkShip == null || longestUnsunkShip.Length < ship.Length)
                    longestUnsunkShip = ship;
            return longestUnsunkShip;
        }
        public void ProcessHit(Location location)
        {
            foreach (Ship ship in Ships)
                if (ship.Contains(location))
                    ship.ProcessHit(location);
            if (IsSunk())
                ChatPrinter.PrintSuccess("All ships in fleet have been sunk!");
        }
        public void PlaceRandomly(Board board)
        {
            foreach (Ship ship in Ships)
                ship.PlaceRandomly(board);
        }
    }
}
