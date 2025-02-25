using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Board
    {
        public static int XMin = 0;
        public static int YMin = 0;
        public static int XMax = 9;
        public static int YMax = 9;
        public string PlayerName { get; }
        public Fleet Fleet { get; }
        public List<Location> ShotsSustained { get; }
        public int NumShotsSustained { get { return ShotsSustained.Count; } }
        public Board()
        {
            PlayerName = "Player";
            Fleet = new Fleet();
            ShotsSustained = new List<Location>();

            AddStandardShipsToFleet();
            PlaceFleet();
        }
        public Board(string playerName) : this()
        {
            PlayerName = playerName;
        }
        public void AddStandardShipsToFleet()
        {
            Fleet.Add(new Ship("Carrier", ShipLength.Carrier));
            Fleet.Add(new Ship("Battleship", ShipLength.Battleship));
            Fleet.Add(new Ship("Cruiser", ShipLength.Cruiser));
            Fleet.Add(new Ship("Submarine", ShipLength.Submarine));
            Fleet.Add(new Ship("Destroyer", ShipLength.Destroyer));
        }
        public void PlaceFleet()
        {
            Fleet.PlaceRandomly(this);
        }
        public void SustainShot(Location location)
        {
            if (ValidAttemptLocation(location))
                LogAttempt(location);
        }
        public bool ValidAttemptLocation(Location location)
        {
            if (IsOffBoard(location))
                return false;

            if (ShotsSustained.Contains(location))
                return false;

            return true;
        }
        private void LogAttempt(Location location)
        {
            ShotsSustained.Add(location);
            if (Fleet.Contains(location))
                Fleet.ProcessHit(location);
            else
                ChatPrinter.PrintNeutral("Miss.");
        }
        public bool IsOffBoard(Location location)
        {
            if (XMin <= location.XPos && location.XPos <= XMax
                && YMin <= location.YPos && location.YPos <= YMax)
                return false;
            return true;
        }
        public bool IsOffBoard(List<Location> locations)
        {
            foreach (Location location in locations)
                if (IsOffBoard(location))
                    return true;
            return false;
        }
        public bool ContainsShips(Location location)
        {
            return Fleet.Contains(location);
        }
        public bool ContainsShips(List<Location> locations)
        {
            foreach (Location location in locations)
                if (ContainsShips(location))
                    return true;
            return false;
        }
    }
}
