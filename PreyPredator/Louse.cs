using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PreyPredator.Contracts;

namespace PreyPredator
{
    internal class Louse : Animal
    {

        public Louse() : base(6, Colors.GreenYellow) { }

        public Louse(Position position) : base (6, Colors.GreenYellow, position) {}

        public override IAnimal TryBreed()
        {
            if (_age > 0 && _age % 2 == 0)
            {
                return new Louse(new Position(position.X, position.Y));
            }
            return null;
        }
    }
}
