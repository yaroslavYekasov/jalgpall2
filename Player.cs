using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Player
    {
        public Player() { }

        // Имя игрока, которое не может быть изменено после создания.
        public string Name { get; }

        // Текущая позиция игрока на поле (X и Y координаты).
        public double X { get; private set; }
        public double Y { get; private set; }

        // Скорость игрока по горизонтали (_vx) и вертикали (_vy).
        private double _vx, _vy;

        // Команда, в которой играет игрок (может быть null).
        public Team? Team { get; set; } = null;

        // Максимальная скорость передвижения игрока.
        private const double MaxSpeed = 5;

        // Максимальная сила удара мяча игроком.
        private const double MaxKickSpeed = 25;

        // Расстояние, на котором игрок может ударить мяч.
        private const double BallKickDistance = 10;

        // Генератор случайных чисел для различных случайных операций.
        private Random _random = new Random();

        // Конструктор для создания игрока с указанием имени.
        public Player(string name)
        {
            Name = name;
        }

        // Конструктор для создания игрока с указанием имени, начальных координат и команды.
        public Player(string name, double x, double y, Team team)
        {
            Name = name;
            X = x;
            Y = y;
            Team = team;
        }

        // Метод для установки новой позиции игрока.
        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Метод для получения абсолютной позиции игрока на поле (в контексте команды).
        public (double, double) GetAbsolutePosition()
        {
            return Team!.Game.GetPositionForTeam(Team, X, Y);
        }

        // Метод для вычисления расстояния от игрока до мяча.
        public double GetDistanceToBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Метод для перемещения игрока в направлении мяча.
        public void MoveTowardsBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;

            // Рассчитываем отношение для достижения максимальной скорости.
            var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;

            // Устанавливаем скорость по горизонтали и вертикали для движения к мячу.
            _vx = dx / ratio;
            _vy = dy / ratio;
        }

        // Метод для движения игрока по текущей скорости.
        public void Move()
        {
            // Если этот игрок не ближайший к мячу, он останавливается.
            if (Team.GetClosestPlayerToBall() != this)
            {
                _vx = 0;
                _vy = 0;
            }

            // Если игрок близко к мячу, он устанавливает силу удара мяча.
            if (GetDistanceToBall() < BallKickDistance)
            {
                Team.SetBallSpeed(
                    MaxKickSpeed * _random.NextDouble(),
                    MaxKickSpeed * (_random.NextDouble() - 0.5)
                );
            }

            // Вычисляем новые координаты на основе текущей скорости.
            var newX = X + _vx;
            var newY = Y + _vy;

            // Получаем абсолютные координаты игрока на поле команды.
            var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);

            // Проверяем, находится ли игрок внутри стадиона.
            if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                // Если игрок вышел за границы стадиона, он останавливается.
                _vx = _vy = 0;
            }
        }
    }
}
