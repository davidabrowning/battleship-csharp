using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class GameVsHuman : Game
    {
        public GameVsHuman()
        {
            Boards.Add(new Board());
            Boards.Add(new Board());
        }
    }
}
