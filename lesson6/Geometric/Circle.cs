using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric
{
    internal class Circle : Point
    {
        private readonly int _radius;
        public int Radius 
        { 
            get { return _radius; }
        }
        public Circle(int radius)
        {
            _radius = radius;
        }
        public override void Draw()
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            base.Draw();
            Console.WriteLine($"Radius: {_radius}");
            Console.ForegroundColor = consoleColor;
        }
        public override sealed int Square()
        {
            return (int)(Math.PI * _radius * _radius);
        }
    }
}
