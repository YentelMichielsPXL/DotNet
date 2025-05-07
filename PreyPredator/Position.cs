using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace PreyPredator
{
    internal class Position
    {
        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set
            {
                if (value >= 0 && value < 21)
                {
                    _x = value;
                }
            }
        }
        public int Y
        {
            get => _y;
            set
            {
                if (value >= 0 && value < 21)
                {
                    _y = value;
                }
            }
        }

        public Position (int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveUp() { Y--; }
        public void MoveDown() { Y++; }
        public void MoveLeft() { X--; }
        public void MoveRight() { X++; }

        public override string ToString()
        {
            return $"x: {_x}, y: {_y}";
        }


    }
}
