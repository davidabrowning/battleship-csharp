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
            Player playerOne = new HumanPlayer("Player 1");
            Player playerTwo = new HumanPlayer("Player 2");
            playerOne.OpponentBoard = playerTwo.MyBoard;
            playerTwo.OpponentBoard = playerOne.MyBoard;
            Players.Add(playerOne);
            Players.Add(playerTwo);
        }
    }
}
