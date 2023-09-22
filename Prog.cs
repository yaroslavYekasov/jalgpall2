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
        static void Main(string[] args)   /*(int x, int y, int dire, int times, string sym)*/
        {
            Console.Clear();
            Console.SetWindowSize(130, 30);

            Stadium field = new Stadium(99, 26);
            Build build = new Build();

            build.DrawInDirection(0, 0, 2, 130, "*");
            build.DrawInDirection(0, 0, 3, 30, "*");

            build.DrawInDirection(0, 29, 2, 130, "*");
            build.DrawInDirection(129, 0, 3, 30, "*");

            Stadium s = new Stadium(129, 29);

            Team t1 = new Team("Medovuha");
            Player m1 = new Player("Luca");
            Player m2 = new Player("Martin");
            Player m3 = new Player("Dasha");
            Player m4 = new Player("Yarik");
            Player m5 = new Player("Timur");
            t1.AddPlayer(m1);
            t1.AddPlayer(m2);
            t1.AddPlayer(m3);
            t1.AddPlayer(m4);
            t1.AddPlayer(m5);            

            Team t2 = new Team("Enelo");
            Player e1 = new Player("Denis");
            Player e2 = new Player("Katya");
            Player e3 = new Player("Akaki");
            Player e4 = new Player("Egor");
            Player e5 = new Player("Anton");
            t2.AddPlayer(e1);
            t2.AddPlayer(e2);
            t2.AddPlayer(e3);
            t2.AddPlayer(e4);
            t2.AddPlayer(e5);

            Game jalgpall = new Game(t1, t2, s);
            jalgpall.Start();
            build.SetPlayer(m1.X, m1.Y, "ML");
            build.SetPlayer(m2.X, m2.Y, "MM");
            build.SetPlayer(m3.X, m3.Y, "MD");
            build.SetPlayer(m4.X, m4.Y, "MY");
            build.SetPlayer(m5.X, m5.Y, "MT");

            build.SetPlayer(e1.X, e1.Y, "ED");
            build.SetPlayer(e2.X, e2.Y, "EK");
            build.SetPlayer(e3.X, e3.Y, "EA");
            build.SetPlayer(e4.X, e4.Y, "EE");
            build.SetPlayer(e5.X, e5.Y, "EA");

            while (true)
            {
                t1.GetBallPosition();
                t2.GetBallPosition();

                t1.GetClosestPlayerToBall();
                t2.GetClosestPlayerToBall();



            }


            //for (int i = 0; i < t2.Players.Count; i++)
            //{
            //    Console.WriteLine(t2.Players[i]);
            //}
        }
    }
}
