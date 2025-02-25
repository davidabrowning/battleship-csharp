using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class ComputerPlayer : Player
    {
        public ComputerPlayer() : base("Computer")
        {

        }
        public override Location GetNextMove()
        {
            // Not implemented
            return null;
        }
    }
}
