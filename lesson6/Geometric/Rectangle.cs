using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric
{
    internal class Rectangle : Point
    {
        private readonly int _sideA;
        private readonly int _sideB;

        public Rectangle(int sideA, int sideB)
        {
            _sideA = sideA;
            _sideB = sideB;
        }
        public (int sideA, int sideB) GetSides()
        {
            return (_sideA, _sideB);
        }
        public override sealed int Square()
        {
            return _sideA * _sideB;
        }

        public override void Draw()
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            base.Draw();
            Console.WriteLine($"Sides: {_sideA}, {_sideB}");
            Console.ForegroundColor = consoleColor;
        }
    }
}