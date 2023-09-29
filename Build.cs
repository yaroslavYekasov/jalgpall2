using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Build
    {
        public int result1 = 0;
        public int result2 = 0;

        public Build() { }

        Gates g1 = new Gates(5, 9, 13, 20);
        Gates g2 = new Gates(117, 9, 124, 20);

        Stadium s = new Stadium(120, 28);

        Ball bl = new Ball();

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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sym + " " + goals1 + " ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(sym + " " + goals2);

            //восстановление цвета консоли
            Console.ResetColor();
        }


        public void SetPlayer(double x, double y, string sym)
        {
            int a = Convert.ToInt32(x);
            int b = Convert.ToInt32(y);
            Draw(a, b, sym);
        }

        public void RedrawPlayers(List<Player> players)
        {
            DrawInDirection(0, 0, 2, 130, "*");
            DrawInDirection(0, 0, 3, 30, "*");

            DrawInDirection(0, 29, 2, 130, "*");
            DrawInDirection(129, 0, 3, 30, "*");

            //определяем цвета для первых 5
            ConsoleColor redColor = ConsoleColor.Red;
            ConsoleColor blueColor = ConsoleColor.Blue;

            int redCount = 0;
            int blueCount = 0;

            foreach (var player in players)
            {
                //определяем цвет текущего игрока
                ConsoleColor playerColor = redCount < 5 ? redColor : blueColor;

                Console.ForegroundColor = playerColor;

                SetPlayer(player.X, player.Y, player.Name);

                if (playerColor == redColor)
                {
                    redCount++;
                }
                else
                {
                    blueCount++;
                }
            }

            //восстановление цвета консоли
            Console.ResetColor();

            Console.WriteLine(new string(' ', Console.WindowWidth));
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

            //if (!s.IsIn((int)x, (int)y))
            //{
            //    // Set the ball's position to the center of the stadium
            //    x = s.Width / 2.0;
            //    y = s.Height / 2.0;
            //}

            DrawResult(1, 30, "res:", result1, result2);
            Draw((int)x, (int)y, sym);
        }

        public void DrawGates()
        {
            DrawInDirection(6, 30 - 10, 2, 8, "■");
            DrawInDirection(6, 30 - 21, 2, 8, "■");
            DrawInDirection(5, 30 - 21, 3, 12, "*");

            DrawInDirection(117, 30 - 10, 2, 8, "■");
            DrawInDirection(117, 30 - 21, 2, 8, "■");
            DrawInDirection(124, 30 - 21, 3, 12, "*");
        }
    }
}
