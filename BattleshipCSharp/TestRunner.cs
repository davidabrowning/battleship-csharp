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
    }
}
