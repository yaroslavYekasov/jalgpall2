using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace jalgpall
{
    public class Gates
    {
        public int X1 { get; }
        public int Y1 { get; }
        public int X2 { get; }
        public int Y2 { get; }

        public Gates() { }
 
        public Gates(int x1, int y1, int x2, int y2) 
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public bool IsInGates(int x, int y)
        {
            if (x > X1 && x < X2 && y > Y1 && y < Y2) return true;
            else return false;
        }
    }
}
