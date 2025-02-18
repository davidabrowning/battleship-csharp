using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Location
    {
        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public Location(int xpos, int ypos)
        {
            XPos = xpos;
            YPos = ypos;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Location compLocation = (Location)obj;
            if (XPos != compLocation.XPos || YPos != compLocation.YPos)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"({XPos}, {YPos})";
        }

    }
}
