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
            Console.OutputEncoding = Encoding.Unicode; 

            Console.Clear();
            Console.SetWindowSize(130, 31);

            //Stadium field = new Stadium(99, 26);
            
            Build build = new Build();

            Stadium s = new Stadium(125, 25);

            Team t1 = new Team("Medovuha");
            Player m1 = new Player("M1");
            Player m2 = new Player("M2");
            Player m3 = new Player("M3");
            Player m4 = new Player("M4");
            Player m5 = new Player("M5");
            t1.AddPlayer(m1);
            t1.AddPlayer(m2);
            t1.AddPlayer(m3);
            t1.AddPlayer(m4);
            t1.AddPlayer(m5);

            Team t2 = new Team("Enelo");
            Player e1 = new Player("E1");
            Player e2 = new Player("E2");
            Player e3 = new Player("E3");
            Player e4 = new Player("E4");
            Player e5 = new Player("E5");
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
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
