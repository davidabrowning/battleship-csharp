using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer() : base("Player")
        {

        }
        public override Location GetNextMove()
        {
            // Not implemented
            return null;
        }
    }
}
