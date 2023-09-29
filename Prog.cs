using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    class Prog
    {
        static void Main(string[] args)   
        {
            Gates g1 = new Gates(5, 9, 13, 20);
            Gates g2 = new Gates(117, 9, 124, 20);

            Console.OutputEncoding = Encoding.Unicode; 

            Console.Clear();
            Console.SetWindowSize(130, 31);

            //Stadium field = new Stadium(99, 26);
            
            Build build = new Build();

            Stadium s = new Stadium(120, 28);

            Team t1 = new Team("Medovuha");
            Player m1 = new Player("◍");
            Player m2 = new Player("◍");
            Player m3 = new Player("◍");
            Player m4 = new Player("◍");
            Player m5 = new Player("◍");
            t1.AddPlayer(m1);
            t1.AddPlayer(m2);
            t1.AddPlayer(m3);
            t1.AddPlayer(m4);
            t1.AddPlayer(m5);

            Team t2 = new Team("Enelo");
            Player e1 = new Player("◍");
            Player e2 = new Player("◍");
            Player e3 = new Player("◍");
            Player e4 = new Player("◍");
            Player e5 = new Player("◍");
            t2.AddPlayer(e1);
            t2.AddPlayer(e2);
            t2.AddPlayer(e3);
            t2.AddPlayer(e4);
            t2.AddPlayer(e5);

            Game jalgpall = new Game(t1, t2, s);
            jalgpall.Start();

            while (true)
            {
                Console.Clear();
                jalgpall.Move();
                build.RedrawPlayers(jalgpall.GetAllPlayers());
                build.DrawGates();
                build.SetBall(jalgpall.Ball.X, jalgpall.Ball.Y, "●");
                System.Threading.Thread.Sleep(100);
                if (g1.IsInGates((int)jalgpall.Ball.X, (int)jalgpall.Ball.Y) == true)
                {
                    Console.SetCursorPosition(10, 30);
                    Console.ReadLine();

                }
                else if (g2.IsInGates((int)jalgpall.Ball.X, (int)jalgpall.Ball.Y) == true)
                {
                    Console.SetCursorPosition(10, 30);
                    Console.ReadLine();
                }
            }
        }
    }
}
