using System;

namespace RangeStruct
{
    public struct Range
    {
        // Левая граница диапазона
        public int A { get; set; }

        // Правая граница диапазона
        int b;
        public int B
        {
            get => b;
            set
            {
                if (value < A)
                    throw new ArgumentException("Правая граница должна быть больше или равна левой границе.");
                b = value;
            }
        }

        // Число чисел в диапазоне (только для чтения)
        public int Count => B - A;

        // Конструктор для задания значений основных полей
        public Range(int a, int b) : this()
        {
            A = a;
            B = b;
        }

        // Метод для проверки, лежит ли заданное число в диапазоне
        public bool IsContains(int value) => value >= A && value < B;

        // Переопределение метода ToString() для представления экземпляра структуры в виде строки
        public override string ToString() => $"[{A}; {B})";

        // Переопределение метода Equals() для проверки равенства диапазонов
        public override bool Equals(object obj)
        {
            if (obj is Range)
            {
                var other = (Range)obj;
                return A == other.A && B == other.B;
            }
            throw new ArgumentException("Объект для сравнения не является диапазоном.");
        }

        // Переопределение метода GetHashCode() для генерации хеш-кода
        public override int GetHashCode() => (A, B).GetHashCode();

        // Перегрузка оператора & (пересечение диапазонов)
        public static Range operator &(Range x, Range y)
        {
            int start = Math.Max(x.A, y.A);
            int end = Math.Min(x.B, y.B);
            if (start >= end)
                return new Range(0, 0); // Пустой диапазон
            return new Range(start, end);
        }

        // Перегрузка оператора | (наименьший диапазон, содержащий оба диапазона)
        public static Range operator |(Range x, Range y)
        {
            int start = Math.Min(x.A, y.A);
            int end = Math.Max(x.B, y.B);
            return new Range(start, end);
        }

        // Перегрузка операторов == и != для проверки равенства диапазонов
        public static bool operator ==(Range x, Range y) => x.Equals(y);
        public static bool operator !=(Range x, Range y) => !x.Equals(y);
    }
}
