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
            Console.SetWindowSize(120, 27);

            Stadium field = new Stadium(99, 26);
            Build build = new Build();

            build.DrawInDirection(0, 0, 2, 60, "*");
            build.DrawInDirection(0, 0, 3, 27, "*");

            build.DrawInDirection(0, 26, 2, 60, "*");
            build.DrawInDirection(119, 0, 3, 27, "*");

            Team t1 = new Team("Medovuha");

            Player m1 = new Player("Luca");
            t1.AddPlayer(m1);
            build.SetPlayer(10, 1, "1");

            Player m2 = new Player("Max");
            t1.AddPlayer(m2);
            build.SetPlayer(15, 4, "2");

            Player m3 = new Player("Robin");
            t1.AddPlayer(m3);
            build.SetPlayer(40, 9, "3");

            Team t2 = new Team("Enelo");

            Player n1 = new Player("Dodin");
            t2.AddPlayer(n1);
            build.SetPlayer(70, 5, "4");

            Player n2 = new Player("Nika");
            t2.AddPlayer(n2);
            build.SetPlayer(80, 7, "5");

            Player n3 = new Player("Pavlo");
            t2.AddPlayer(n3);
            build.SetPlayer(60, 6, "6");

            Game g = new Game(t1, t2, field);

            Ball b = new Ball(49, 13, g);
            build.SetBall("O");

            while (true)
            {
                
            }          
        }
    }
}
