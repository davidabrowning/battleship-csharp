using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Board
    {
        public Fleet Fleet { get; private set; }
        public List<Location> Attempts { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int XMin { get { return 0; } }
        public int YMin { get { return 0; } }
        public int XMax { get { return Width - 1; } }
        public int YMax { get { return Height - 1; } }
        public Board()
        {
            Fleet = new Fleet();
            Attempts = new List<Location>();
            Height = 10;
            Width = 10;

            Fleet.Add(new Ship("Carrier", ShipLength.Carrier));
            Fleet.Add(new Ship("Battleship", ShipLength.Battleship));
            Fleet.Add(new Ship("Cruiser", ShipLength.Cruiser));
            Fleet.Add(new Ship("Submarine", ShipLength.Submarine));
            Fleet.Add(new Ship("Destroyer", ShipLength.Destroyer));
            Fleet.PlaceRandomly(this);
        }
        public void ProcessAttempt(Location location)
        {
            if (!IsOnBoard(location))
            {
                TextPrinter.PrintWarning("Not on board.");
                return;
            }

            if (Attempts.Contains(location))
            {
                TextPrinter.PrintWarning("Already attempted.");
                return;
            }

            Attempts.Add(location);
            if (Fleet.Contains(location))
            {
                TextPrinter.PrintSuccess("Hit!");
                Fleet.ProcessHit(location);
            }
            else
            {
                TextPrinter.PrintInfo("Miss.");
            }
            Thread.Sleep(2000);
        }
        public bool IsOnBoard(Location location)
        {
            if (XMin <= location.XPos && location.XPos <= XMax
                && YMin <= location.YPos && location.YPos <= YMax)
            {
                return true;
            }
            return false;
        }
        public bool IsEmpty(Location location)
        {
            if (!IsOnBoard(location))
            {
                return false;
            }
            if (Fleet.Contains(location))
            {
                return false;
            }
            return true;
        }
        public bool IsEmpty(List<Location> locations)
        {
            foreach (Location location in locations)
            {
                if (!IsEmpty(location))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
