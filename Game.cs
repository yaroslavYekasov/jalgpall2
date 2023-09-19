using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Game
    {
        // Класс игры представляет собой соревнование между двумя командами.
        // У каждой игры есть домашняя команда, гостевая команда и стадион.
        public Team HomeTeam { get; } // Домашняя команда.
        public Team AwayTeam { get; } // Гостевая команда.
        public Stadium Stadium { get; } // Стадион, на котором происходит игра.
        public Ball Ball { get; private set; } // Мяч, используемый в игре.

        // Конструктор класса Game принимает домашнюю команду, гостевую команду и стадион.
        public Game(Team homeTeam, Team awayTeam, Stadium stadium)
        {
            HomeTeam = homeTeam;
            homeTeam.Game = this; // Связываем домашнюю команду с этой игрой.
            AwayTeam = awayTeam;
            awayTeam.Game = this; // Связываем гостевую команду с этой игрой.
            Stadium = stadium;
        }

        // Метод Start начинает игру, инициализируя мяч и стартовую позицию команд.
        public void Start()
        {
            Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this); // Создаем мяч и помещаем его в центр поля.
            HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height); // Запускаем домашнюю команду.
            AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height); // Запускаем гостевую команду.
        }

        // Приватный метод GetPositionForAwayTeam вычисляет позицию для гостевой команды, отражая координаты относительно стадиона.
        private (double, double) GetPositionForAwayTeam(double x, double y)
        {
            return (Stadium.Width - x, Stadium.Height - y);
        }

        // Метод GetPositionForTeam возвращает позицию для указанной команды, учитывая координаты.
        public (double, double) GetPositionForTeam(Team team, double x, double y)
        {
            return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);
        }

        // Метод GetBallPositionForTeam возвращает текущую позицию мяча для указанной команды.
        public (double, double) GetBallPositionForTeam(Team team)
        {
            return GetPositionForTeam(team, Ball.X, Ball.Y);
        }

        // Метод SetBallSpeedForTeam устанавливает скорость мяча для указанной команды, инвертируя ее, если это гостевая команда.
        public void SetBallSpeedForTeam(Team team, double vx, double vy)
        {
            if (team == HomeTeam)
            {
                Ball.SetSpeed(vx, vy);
            }
            else
            {
                Ball.SetSpeed(-vx, -vy);
            }
        }

        // Метод Move обновляет положение домашней и гостевой команды, а также мяча.
        public void Move()
        {
            HomeTeam.Move();
            AwayTeam.Move();
            Ball.Move();
        }
    }

}
