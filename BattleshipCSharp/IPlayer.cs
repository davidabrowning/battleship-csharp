using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    interface IPlayer
    {
        string Name { get; }
        Board MyBoard { get; }
        Board OpponentBoard { get; }
        void PlaceFleet();
        Location GetNextMove();
        void ProcessOpponentMove(Location location);
    }
}
