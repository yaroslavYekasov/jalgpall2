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

                if (dire == 3)
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
            foreach (var player in players)
            {
                SetPlayer(player.X, player.Y, player.Name);
            }
        }

        public void SetBall(double x, double y, string sym)
        {
            Draw((int)x, (int)y, sym);
        }
    }
}
