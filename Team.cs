using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Team
    {
        // Список игроков в команде.
        public List<Player> Players { get; } = new List<Player>();

        // Имя команды (может быть задано только при создании).
        public string Name { get; private set; }

        // Ссылка на игру, в которой участвует команда.
        public Game Game { get; set; }

        // Конструктор класса, который принимает имя команды и устанавливает его.
        public Team(string name)
        {
            Name = name;
        }

        // Метод начала игры, который расставляет игроков случайным образом на поле заданных размеров.
        public void StartGame(int width, int height)
        {
            Random rnd = new Random();
            foreach (var player in Players)
            {
                // Устанавливаем случайные координаты для каждого игрока.
                player.SetPosition(
                    rnd.NextDouble() * width,
                    rnd.NextDouble() * height
                );
            }
        }

        // Метод для добавления игрока в команду.
        public void AddPlayer(Player player)
        {
            // Проверяем, что игрок ещё не состоит в другой команде.
            if (player.Team != null) return;

            // Добавляем игрока в список и устанавливаем ссылку на эту команду.
            Players.Add(player);
            player.Team = this;
        }

        // Метод для получения текущей позиции мяча для этой команды из игры.
        public (double, double) GetBallPosition()
        {
            return Game.GetBallPositionForTeam(this);
        }

        // Метод для установки скорости мяча для этой команды в игре.
        public void SetBallSpeed(double vx, double vy)
        {
            Game.SetBallSpeedForTeam(this, vx, vy);
        }

        // Метод для получения ближайшего игрока к мячу в команде.
        public Player GetClosestPlayerToBall()
        {
            Player closestPlayer = Players[0];
            double bestDistance = Double.MaxValue;
            foreach (var player in Players)
            {
                var distance = player.GetDistanceToBall();
                // Если найден игрок, ближайший к мячу, обновляем ближайшего игрока и расстояние.
                if (distance < bestDistance)
                {
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }
            return closestPlayer;
        }

        // Метод, который двигает игроков в команде.
        public void Move()
        {
            // Двигаем ближайшего игрока к мячу.
            GetClosestPlayerToBall().MoveTowardsBall();

            // Двигаем всех игроков в команде.
            Players.ForEach(player => player.Move());
        }
    }
}
