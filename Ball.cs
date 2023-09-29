using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Ball
    {
        public double X { get; set; }
        public double Y { get; set; }

        private double _vx, _vy;

        private Game _game;

        public Ball() { }

        public Ball(double x, double y, Game game)
        {
            _game = game;
            X = x;
            Y = y;
        }

        public void SetSpeed(double vx, double vy)
        {
            _vx = vx;
            _vy = vy;
        }

        public void Move()
        {
            double newX = X + _vx;
            double newY = Y + _vy;
            if (_game.Stadium.IsIn(newX, newY))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                _vx = 0;
                _vy = 0;
            }  
        }

        public void SetBallPosition(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
