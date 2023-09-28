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

        public int result1 = 0;
        public int result2 = 0;

        Gates g1 = new Gates(5, 9, 13, 20);
        Gates g2 = new Gates(117, 9, 124, 20);

        public void Draw(int x, int y, string sym)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
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

        public void DrawResult(int x, int y, string sym, int goals1, int goals2)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym + " " + goals1 + " " + sym + " " + goals2);
        }

        public void SetPlayer(double x, double y, string sym)
        {
            int a = Convert.ToInt32(x);
            int b = Convert.ToInt32(y);
            Draw(a, b, sym);
        }

        public void RedrawPlayers(List<Player> players)
        {

            //DrawInDirection(0, 0, 2, 130, "■");
            //DrawInDirection(0, 0, 3, 30, "■");

            //DrawInDirection(0, 29, 2, 130, "■");
            //DrawInDirection(129, 0, 3, 30, "■");

            //DrawResult(1, 30, "res:", result);

            foreach (var player in players)
            {
                SetPlayer(player.X, player.Y, player.Name);
            }
        }

        public void SetBall(double x, double y, string sym)
        {      
            if (g1.IsInGates((int)x, (int)y) == true)
            {
                result1++;
            }
            else if (g2.IsInGates((int)x, (int)y) == true)
            {
                result2++;
            }
            DrawResult(1, 30, "res:", result1, result2);
            Draw((int)x, (int)y, sym);
        }

        public void DrawGates()
        {
            DrawInDirection(6, 30 - 10, 2, 8, "*");
            DrawInDirection(6, 30 - 21, 2, 8, "*");
            DrawInDirection(5, 30 - 21, 3, 12, "*");

            DrawInDirection(117, 30 - 10, 2, 8, "*");
            DrawInDirection(117, 30 - 21, 2, 8, "*");
            DrawInDirection(124, 30 - 21, 3, 12, "*");
        }
    }
}
