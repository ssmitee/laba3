using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNumberApp
{
    public class FuzzyNumber
    {
        public double X { get; }
        public double A1 { get; }
        public double A2 { get; }

        public FuzzyNumber(double x, double a1, double a2)
        {
            X = x;
            A1 = a1;
            A2 = a2;
        }

        public static FuzzyNumber operator +(FuzzyNumber A, FuzzyNumber B)
        {
            return new FuzzyNumber(
                A.X + B.X,
                A.A1 + B.A1,
                A.A2 + B.A2
            );
        }

        public static FuzzyNumber operator -(FuzzyNumber A, FuzzyNumber B)
        {
            return new FuzzyNumber(
                A.X - B.X,
                A.A1 - B.A1,
                A.A2 - B.A2
            );
        }

        public static FuzzyNumber operator *(FuzzyNumber A, FuzzyNumber B)
        {
            return new FuzzyNumber(
                A.X * B.X,
                A.X * B.A1 + A.A1 * B.X,
                A.X * B.A2 + A.A2 * B.X
            );
        }

        public FuzzyNumber Inverse()
        {
            if (X - A1 <= 0 || X + A2 <= 0)
            {
                throw new InvalidOperationException("Обратное число не существует");
            }

            return new FuzzyNumber(
                1 / X,
                1 / (X + A2),
                1 / (X - A1)
            );
        }

        public static FuzzyNumber operator /(FuzzyNumber A, FuzzyNumber B)
        {
            if (B.X - B.A1 <= 0 || B.X + B.A2 <= 0)
            {
                throw new InvalidOperationException("Деление на ноль невозможно");
            }

            return new FuzzyNumber(
                A.X / B.X,
                (A.X - A.A1) / (B.X + B.A2),
                (A.X + A.A2) / (B.X - B.A1)
            );
        }

        public override string ToString()
        {
            return $"({X} - {A1}, {X}, {X} + {A2})";
        }
    }
}
