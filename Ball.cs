using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Ball
    {
        // Переменные для хранения координат мяча
        public double X { get; private set; } // Координата X мяча
        public double Y { get; private set; } // Координата Y мяча

        // Скорости мяча по осям X и Y
        private double _vx, _vy;

        // Игра, в которой находится мяч
        private Game _game;

        // Конструктор класса для создания мяча с начальными координатами и привязкой к игре
        public Ball(double x, double y, Game game)
        {
            _game = game; // Сохраняем ссылку на игру
            X = x; // Устанавливаем начальную координату X
            Y = y; // Устанавливаем начальную координату Y
        }

        public Ball() { }

        // Метод для установки скорости мяча по осям X и Y
        public void SetSpeed(double vx, double vy)
        {
            _vx = vx; // Устанавливаем скорость по X
            _vy = vy; // Устанавливаем скорость по Y
        }

        // Метод для перемещения мяча в соответствии со скоростью
        public void Move()
        {
            double newX = X + _vx; // Вычисляем новую координату X
            double newY = Y + _vy; // Вычисляем новую координату Y

            // Проверяем, находится ли новая позиция мяча в пределах игрового поля
            if (_game.Stadium.IsIn(newX, newY))
            {
                X = newX; // Если да, обновляем координаты мяча
                Y = newY;
            }
            else
            {
                _vx = 0; // Если новая позиция выходит за пределы поля, останавливаем мяч
                _vy = 0;
            }
        }
    }
}
