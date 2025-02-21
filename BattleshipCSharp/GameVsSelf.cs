using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class GameVsSelf : Game
    {
        public GameVsSelf()
        {
            Boards.Add(new Board("Player"));
        }
    }
}
