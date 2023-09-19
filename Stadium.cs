﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    // Этот класс называется Stadium (стадион) и представляет собой абстракцию стадиона с заданными шириной и высотой.

    public class Stadium
    {
        // Этот конструктор принимает два параметра: ширину и высоту стадиона.
        public Stadium(int width, int height)
        {
            // Здесь мы сохраняем переданные значения ширины и высоты в соответствующих полях.
            Width = width;
            Height = height;
        }

        // Это свойство позволяет получать ширину стадиона (не изменяемую после создания).
        public int Width { get; }

        // Это свойство позволяет получать высоту стадиона (не изменяемую после создания).

        public int Height { get; }

        // Этот метод проверяет, находятся ли координаты (x, y) внутри границ стадиона.
        // Он возвращает true, если координаты находятся внутри стадиона, иначе - false.
        public bool IsIn(double x, double y)
        {
            // Проверяем, что x находится между 0 и шириной стадиона, а также y между 0 и высотой стадиона.
            // Если оба условия выполняются, то точка (x, y) находится внутри стадиона, и метод возвращает true.
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }

}