using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class TestRunner
    {
        public void Go()
        {
            Console.WriteLine("Running Location tests");
            RunLocationTests();
            Console.WriteLine("Running Ship tests");
            RunShipTests();
            Console.WriteLine("Running Board tests");
            RunBoardTests();
        }

        public void RunLocationTests()
        {
            // Variables
            string title;
            Location location;
            Location location2;

            title = "Location contains desired XPos";
            location = new Location(12, 15);
            TestHelper.AssertEquals(title, 12, location.XPos);

            title = "Location does not contain unexpected XPos";
            location = new Location(12, 15);
            TestHelper.AssertNotEquals(title, 11, location.YPos);

            title = "Can use .Equals() method to compare two Locations";
            location = new Location(12, 15);
            location2 = new Location(12, 15);
            TestHelper.AssertTrue(title, location.Equals(location2));

            title = "Location contains desired YPos";
            location = new Location(5, 8);
            TestHelper.AssertEquals(title, 8, location.YPos);

            title = "Location equals same Location";
            location = new Location(25, 28);
            location2 = new Location(25, 28);
            TestHelper.AssertEquals(title, location, location2);

            title = "Location does not equal different Location";
            location = new Location(25, 28);
            location2 = new Location(26, 28);
            TestHelper.AssertNotEquals(title, location, location2);
        }

        private void RunShipTests()
        {
            // Variables
            string title;
            Ship ship;
            Board board;
            Location location;

            title = "Ship contains intended name";
            ship = new Ship("Battleship", ShipLength.Battleship);
            TestHelper.AssertEquals(title, "Battleship", ship.Name);

            title = "Ship contains intended length";
            ship = new Ship("Battleship", ShipLength.Battleship);
            TestHelper.AssertEquals(title, (int)ShipLength.Battleship, ship.Length);

            title = "Ship initially contains no locations";
            ship = new Ship("Battleship", ShipLength.Battleship);
            TestHelper.AssertEquals(title, 0, ship.Locations.Count);

            title = "Ship contains intended number of locations after being placed";
            ship = new Ship("Battleship", ShipLength.Battleship);
            board = new Board();
            ship.PlaceRandomly(board);
            TestHelper.AssertEquals(title, (int)ShipLength.Battleship, ship.Locations.Count);

            title = "Ship is not always placed at the same location";
            bool shipAlwaysPlacedAtSameLocation = true;
            location = null;
            for (int i = 0; i < 10; i++)
            {
                ship = new Ship("Battleship", ShipLength.Battleship);
                board = new Board();
                ship.PlaceRandomly(board);
                Location shipOrigin = ship.Locations
                    .OrderBy(location => location.XPos)
                    .ThenBy(location => location.YPos)
                    .First();
                if (location != null && !location.Equals(shipOrigin))
                {
                    shipAlwaysPlacedAtSameLocation = false;
                    break;
                }
                location = shipOrigin;
            }
            TestHelper.AssertFalse(title, shipAlwaysPlacedAtSameLocation);

            title = "Ship is not always placed horizontally";
            bool shipAlwaysHorizontal = true;
            for (int i = 0; i < 10; i++)
            {
                ship = new Ship("Battleship", ShipLength.Battleship);
                board = new Board();
                ship.PlaceRandomly(board);
                if (ship.Locations[0].YPos != ship.Locations[1].YPos)
                {
                    shipAlwaysHorizontal = false;
                }
            }
            TestHelper.AssertFalse(title, shipAlwaysHorizontal);

            title = "Ship is not always placed vertically";
            bool shipAlwaysVertical = true;
            for (int i = 0; i < 10; i++)
            {
                ship = new Ship("Battleship", ShipLength.Battleship);
                board = new Board();
                ship.PlaceRandomly(board);
                if (ship.Locations[0].XPos != ship.Locations[1].XPos)
                {
                    shipAlwaysVertical = false;
                }
            }
            TestHelper.AssertFalse(title, shipAlwaysVertical);

            title = "Ship is not placed outside of game board";
            bool shipPlacedOutsideOfGameBoard = false;
            for (int i = 0; i < 100; i++)
            {
                ship = new Ship("Carrier", ShipLength.Carrier);
                board = new Board();
                ship.PlaceRandomly(board);
                foreach (Location loc in ship.Locations)
                {
                    if (loc.XPos < 0 || loc.XPos >= board.Width
                        || loc.YPos < 0 || loc.YPos >= board.Height)
                    {
                        shipPlacedOutsideOfGameBoard = true;
                    }
                }
            }
            TestHelper.AssertFalse(title, shipPlacedOutsideOfGameBoard);

            title = "Ship is not placed on top of other ships";
        }

        private void RunBoardTests()
        {
            // Variables
            string title;
            Board board;
            Location location;

            title = "IsEmpty returns false when location is off of board";
            board = new Board();
            location = new Location(0, board.Height);
            TestHelper.AssertFalse(title, board.IsEmpty(location));

            title = "IsEmpty initially returns true for origin";
            board = new Board();
            location = new Location(0, 0);
            TestHelper.AssertTrue(title, board.IsEmpty(location));
        }
    }
}
