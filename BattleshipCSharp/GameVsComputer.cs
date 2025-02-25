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
            Player humanPlayer = new HumanPlayer();
            Player computerPlayer = new ComputerPlayer();
            humanPlayer.OpponentBoard = computerPlayer.MyBoard;
            computerPlayer.OpponentBoard = humanPlayer.MyBoard;
            Players.Add(humanPlayer);
            Players.Add(computerPlayer);
        }
    }
}
