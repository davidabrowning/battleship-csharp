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
            Console.WriteLine("Running Fleet tests");
            RunFleetTests();
            Console.WriteLine("Running Board tests");
            RunBoardTests();
            Console.WriteLine("Running GameVsHuman tests");
            RunGameVsHumanTests();
            Console.WriteLine("Running ComputerPlayer tests");
            RunComputerPlayerTests();
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
            Fleet fleet;
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
            bool shipsOverlap = false;
            for (int i = 0; i < 100; i++)
            {
                board = new Board();
                board.Fleet.Add(new Ship("Carrier", ShipLength.Carrier));
                board.Fleet.Add(new Ship("Battleship", ShipLength.Battleship));
                board.Fleet.PlaceRandomly(board);
                foreach (Location ship0Location in board.Fleet.Ships[0].Locations)
                {
                    if (board.Fleet.Ships[1].Contains(ship0Location))
                    {
                        shipsOverlap = true;
                    }
                }
            }
            TestHelper.AssertFalse(title, shipsOverlap);

            title = "Ship contains hit after being hit";
            ship = new Ship("Carrier", ShipLength.Carrier);
            board = new Board();
            ship.PlaceRandomly(board);
            location = ship.Locations[2];
            ship.ProcessHit(location);
            TestHelper.AssertTrue(title, ship.IsHit(location));

            title = "Ship is not sunk after being hit at some locations";
            ship = new Ship("Carrier", ShipLength.Carrier);
            ship.PlaceRandomly(new Board());
            for (int i = 2; i < ship.Length; i++)
            {
                location = ship.Locations[i];
                ship.ProcessHit(location);
            }
            TestHelper.AssertFalse(title, ship.IsSunk());

            title = "Ship is sunk after being hit at all locations";
            ship = new Ship("Carrier", ShipLength.Carrier);
            ship.PlaceRandomly(new Board());
            for (int i = 0; i < ship.Length; i++)
            {
                location = ship.Locations[i];
                ship.ProcessHit(location);
            }
            TestHelper.AssertTrue(title, ship.IsSunk());

        }

        private void RunFleetTests()
        {
            // Variables
            string title;
            Ship ship;
            Ship ship2;
            Fleet fleet;
            Board board;

            title = "Fleet size is initially 0";
            fleet = new Fleet();
            TestHelper.AssertEquals(title, 0, fleet.Size);

            title = "Fleet size is 2 after adding 2 ships";
            fleet = new Fleet();
            ship = new Ship("Destroyer", ShipLength.Destroyer);
            ship2 = new Ship("Submarine", ShipLength.Submarine);
            fleet.Add(ship);
            fleet.Add(ship2);
            TestHelper.AssertEquals(title, 2, fleet.Size);

            title = "PlaceRandomly places ships";
            board = new Board();
            fleet = new Fleet();
            fleet.Add(new Ship("Destroyer", ShipLength.Destroyer));
            fleet.Add(new Ship("Submarine", ShipLength.Submarine));
            fleet.PlaceRandomly(board);
            TestHelper.AssertNotEquals(title, 0, fleet.Ships[0].Locations.Count);
        }

        private void RunBoardTests()
        {
            // Variables
            string title;
            Board board;
            Location location;

            title = "ContainsShips returns false when location is off of board";
            board = new Board();
            location = new Location(0, board.Height);
            TestHelper.AssertFalse(title, board.ContainsShips(location));

            title = "ContainsShips initially returns false for origin";
            board = new Board();
            location = new Location(0, 0);
            TestHelper.AssertFalse(title, board.ContainsShips(location));

            title = "ConstainsShips returns true if ship is present at location";
            board = new Board();
            board.Fleet.Add(new Ship("Battleship", ShipLength.Battleship));
            board.Fleet.PlaceRandomly(board);
            TestHelper.AssertTrue(title, board.ContainsShips(board.Fleet.Ships[0].Locations[0]));
        }

        private void RunGameVsHumanTests()
        {
            // Variables
            string title;
            GameVsHuman game;
            int currentPlayer;

            title = "It is initially Player 0's turn";
            game = new GameVsHuman();
            TestHelper.AssertEquals(title, 0, game.CurrentPlayer);

            title = "It is Player 1's turn after Player 0 takes a turn";
            game = new GameVsHuman();
            game.Boards[0].ProcessAttempt(new Location(0, 0));
            TestHelper.AssertEquals(title, 1, game.CurrentPlayer);

            title = "It is Player 0's turn after Player 1 takes a turn";
            game = new GameVsHuman();
            game.Boards[0].ProcessAttempt(new Location(0, 0));
            game.Boards[1].ProcessAttempt(new Location(1, 0));
            TestHelper.AssertEquals(title, 0, game.CurrentPlayer);

            title = "Current player does not change after invalid input";
            game = new GameVsHuman();
            game.Boards[0].ProcessAttempt(new Location(0, 0));
            game.Boards[1].ProcessAttempt(new Location(1, 0));
            currentPlayer = game.CurrentPlayer;
            game.Boards[0].ProcessAttempt(new Location(-1, 0));
            TestHelper.AssertEquals(title, currentPlayer, game.CurrentPlayer);

            title = "Current player does not change after retrying existing location";
            game = new GameVsHuman();
            game.Boards[0].ProcessAttempt(new Location(2, 2));
            game.Boards[1].ProcessAttempt(new Location(1, 0));
            currentPlayer = game.CurrentPlayer;
            game.Boards[0].ProcessAttempt(new Location(2, 2));
            TestHelper.AssertEquals(title, currentPlayer, game.CurrentPlayer);
        }

        private void RunComputerPlayerTests()
        {
            // Variables
            string title;
            ComputerPlayer computerPlayer;
            Board board;
        }
    }
}
