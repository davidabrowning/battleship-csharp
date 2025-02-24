using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class HumanPlayer : IPlayer
    {
        public string Name { get; private set; }
        public Board MyBoard { get; private set; }
        public Board OpponentBoard { get; private set; }
        public void PlaceFleet()
        {
            // Not implemented
        }
        public Location GetNextMove()
        {
            // Not implemented
            return null;
        }
        public void ProcessOpponentMove(Location location)
        {
            // Not implemented
        }
    }
}
