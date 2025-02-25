using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    abstract class Player
    {
        public string Name { get; }
        public Board MyBoard { get; set; }
        public Board OpponentBoard { get; set; }
        public int ShotsTaken { get { return OpponentBoard.ShotsSustained; } }
        public bool IsVictorious { get { return OpponentBoard.Fleet.IsSunk(); } }
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
