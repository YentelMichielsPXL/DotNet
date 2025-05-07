using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyPredator.Contracts
{
    internal interface IAnimal: IDisplayable
    {
        Position position { get; }
        bool IsDead();

        void Move();

        IAnimal TryBreed();
    }
}
