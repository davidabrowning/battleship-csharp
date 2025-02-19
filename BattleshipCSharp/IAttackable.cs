using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    interface IAttackable
    {
        bool IsSunk();
        bool IsHit(Location location);
        bool Contains(Location location);
        void ProcessHit(Location location);
        void PlaceRandomly(Board board);
    }
}
