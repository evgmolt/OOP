using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric
{
    internal abstract class Figure
    {
        private int _x;
        private int _y;
        private bool _visible;
        private ConsoleColor _color;

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; } 
        }

        public void Move(int dx, int dy)
        {
            _x += dx;
            _y += dy;
        }

        public Figure()
        {
            Visible = true;
            Color = ConsoleColor.White;
        }

        public (int X, int Y) GetPosition()
        {
            return (_x, _y);
        }

        public virtual int Square()
        {
            return 0;
        }
        public virtual void Draw()
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            string visible = Visible ? "Visible" : "Invisible";
            Console.WriteLine($"{this.GetType()}:  X:{_x}, Y:{_y}, Color:{Color}, {visible}");
            Console.ForegroundColor = consoleColor;
        }
    }
}
