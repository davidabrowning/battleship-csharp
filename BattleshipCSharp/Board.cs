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
        public string PlayerName { get; private set; }
        public Fleet Fleet { get; private set; }
        public List<Location> Attempts { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int XMin { get; }
        public int YMin { get; }
        public int XMax { get { return Width - 1; } }
        public int YMax { get { return Height - 1; } }
        public Board()
        {
            PlayerName = "Player";
            Fleet = new Fleet();
            Attempts = new List<Location>();
            Height = 10;
            Width = 10;
            XMin = 0;
            YMin = 0;

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
        public void ProcessAttempt(Location location)
        {
            if (ValidAttemptLocation(location))
                LogAttempt(location);
            Thread.Sleep(2000);
        }
        private bool ValidAttemptLocation(Location location)
        {
            if (IsOffBoard(location))
                return false;

            if (Attempts.Contains(location))
                return false;

            return true;
        }
        private void LogAttempt(Location location)
        {
            Attempts.Add(location);
            if (Fleet.Contains(location))
                Fleet.ProcessHit(location);
            else
                TextPrinter.PrintInfo("Miss.");
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
