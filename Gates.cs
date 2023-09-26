using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Gates
    {
        public Gates() { }

        public Gates(int width1, int height1, int width2, int height2)
        {
            Width1 = width1;
            Height1 = height1;
            Width2 = width2;
            Height2 = height2;
        }

        public int Width1 { get; }
        public int Height1 { get; }
        public int Width2 { get; }
        public int Height2 { get; }

        public bool IsInGates(double x, double y)
        {
            return ((int)x <= Width2 && (int)y <= Height2) && ((int)x >= Width1 && (int)y >= Height1);
        }
    }
}
