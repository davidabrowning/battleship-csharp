using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Board
    {
        public Fleet Fleet { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int XMin { get { return 0; } }
        public int YMin { get { return 0; } }
        public int XMax { get { return Width - 1; } }
        public int YMax { get { return Height - 1; } }
        public Board()
        {
            Fleet = new Fleet();
            Height = 10;
            Width = 10;
        }
        public bool IsEmpty(Location location)
        {
            if (location.XPos < XMin || location.XPos > XMax
                || location.YPos < YMin || location.YPos > YMax)
            {
                return false;
            }
            return true;
        }
    }
}
