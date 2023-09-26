using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Build
    {
        public Build() { }

        Gates g = new Gates(6, 20, 14, 20);

        public int result = 0; 

        public void Draw(int x, int y, string sym)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void DrawResult(int x, int y, string sym, int goals)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym + " " + goals);
        }

        public void DrawInDirection(int x, int y, int dire, int times, string sym)
        {
            int i = 0;

            while (i < times)
            {
                if (dire == 2)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(sym + " ");
                    x++;
                }

                else if (dire == 3)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(sym);
                    y++;
                }
                i++;
            }
        }

        public void SetPlayer(double x, double y, string sym)
        {
            int a = Convert.ToInt32(x);
            int b = Convert.ToInt32(y);
            Draw(a, b, sym);
        }

        public void RedrawPlayers(List<Player> players)
        {
            Console.Clear();
            DrawInDirection(0, 0, 2, 130, "■");
            DrawInDirection(0, 0, 3, 30, "■");

            DrawInDirection(0, 29, 2, 130, "■");
            DrawInDirection(129, 0, 3, 30, "■");

            DrawInDirection(6, 30 - 10, 2, 8, "■");
            DrawInDirection(6, 30 - 21, 2, 8, "■");
            DrawInDirection(5, 30 - 21, 3, 12, "■");

            DrawInDirection(117, 30 - 10, 2, 8, "■");
            DrawInDirection(117, 30 - 21, 2, 8, "■");
            DrawInDirection(124, 30 - 21, 3, 12, "■");

            DrawResult(1, 30, "res:", result);

            foreach (var player in players)
            {
                SetPlayer(player.X, player.Y, player.Name);
            }
        }

        public void SetBall(double x, double y, string sym)
        {
            DrawInDirection(0, 0, 2, 130, "■");
            DrawInDirection(0, 0, 3, 30, "■");

            if (g.IsInGates(x, y) == true)
            {
                result++;             
            }

            DrawInDirection(0, 29, 2, 130, "■");
            DrawInDirection(129, 0, 3, 30, "■");
            Draw((int)x, (int)y, sym);
        }
    }
}
