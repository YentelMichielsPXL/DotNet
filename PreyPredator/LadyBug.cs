using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using PreyPredator.Contracts;

namespace PreyPredator
{
    internal class LadyBug : Animal, IPredator
    {
        private int _roundWithNoFood = 0;

        public LadyBug() : base(16, Colors.Red){}

        public LadyBug(Position position) : base(16, Colors.Red, position)
        {
        }

        public override IAnimal TryBreed()
        {
            if (_age > 0 && _age %4 == 0)
            {
                return new LadyBug(new Position(position.X, position.Y));
            }
            return null;
        }

        public bool CanEat(IAnimal animal)
        {
            return animal is Louse;
        }

        public void Hunt(IList<IAnimal> possibleVictims)
        {
            foreach (var animal in possibleVictims)
            {
                if (CanEat(animal))
                {
                    if (DistanceTo(animal.position) <= 3)
                    {
                        animal.StopDisplaying();
                        _roundWithNoFood = 0;
                        this.position = animal.position;
                    }
                }
            }
            if (_roundWithNoFood >= 3)
            {
                StopDisplaying();
            }
            else
            {
                _roundWithNoFood++;
            }

        }
        public double DistanceTo(Position other)
        {
            
            return Math.Sqrt(Math.Pow(position.X - other.X, 2) + Math.Pow(position.Y - other.Y, 2));
        }
    }
}
