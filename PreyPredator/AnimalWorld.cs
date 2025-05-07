using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using PreyPredator.Contracts;

namespace PreyPredator
{
    internal class AnimalWorld : IAnimalWorld
    {

        private readonly Canvas _canvas;
        private readonly IList<IAnimal> _allAnimals;
        private readonly IList<IAnimal> _newbornAnimals;
        private readonly IList<IAnimal> _deadAnimals;
        public int CurrentRoundNumber { get; private set; }
        public AnimalWorld(Canvas canvas)
        {
            _canvas = canvas;
            _allAnimals = new List<IAnimal>();
            _newbornAnimals = new List<IAnimal>();
            _deadAnimals = new List<IAnimal>();
            CurrentRoundNumber = 0;
        }
        
        public void AddAnimal(IAnimal animal)
        {
            _allAnimals.Add(animal);
            animal.DisplayOn(_canvas);
        }
        public IList<IAnimal> Animals => _allAnimals;


        public void ProcessRound()
        {
            foreach (var animal in _allAnimals)
            {
                animal.Move();
                if (animal is IPredator predator)
                {
                    predator.Hunt(_allAnimals);
                }

                var newAnimal = animal.TryBreed();
                if(newAnimal != null)
                {
                    _newbornAnimals.Add(newAnimal);
                    newAnimal.DisplayOn(_canvas);
                }

                if (animal.IsDead())
                {
                    _deadAnimals.Add(animal);

                }
            }

            foreach ( var deadAnimal in _deadAnimals)
            {
                _allAnimals.Remove(deadAnimal);
                deadAnimal.StopDisplaying();
            }

            foreach (var newborn in _newbornAnimals)
            {
                _allAnimals.Add(newborn);
            }

            _deadAnimals.Clear();
            _newbornAnimals.Clear();

            CurrentRoundNumber++;
        }

    }
}
