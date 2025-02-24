using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    abstract class Player
    {
        string Name { get; }
        Board MyBoard { get; }
        Board OpponentBoard { get; set; }
        public Player(string name)
        {
            Name = name;
            MyBoard = new Board(name);
        }
        public abstract Location GetNextMove();
        public virtual void PlaceFleet()
        {
            // Not yet implemented
        }        
        public void ProcessOpponentMove(Location location)
        {
            // Not yet implemented
        }
    }
}
