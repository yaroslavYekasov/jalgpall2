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

        Player player = new Player();
        Ball ball = new Ball();

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

        public void SetPlayer(int x, int y, string sym)
        {
            player.SetPosition(x, y);
            int a = Convert.ToInt32(player.X);
            int b = Convert.ToInt32(player.Y);
            Draw(a, b, sym);
        }

        public void SetBall(string sym)
        {
            int a = Convert.ToInt32(ball.X);
            int b = Convert.ToInt32(ball.Y);
            Console.SetCursorPosition(a, b);
            Console.Write(sym);
        }
    }
}
