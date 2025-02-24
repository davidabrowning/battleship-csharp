using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class GameVsComputer : Game
    {
        public GameVsComputer()
        {
            Boards.Add(new Board("Player"));
            Boards.Add(new Board("Computer"));
        }
    }
}
