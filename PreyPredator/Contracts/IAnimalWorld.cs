using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyPredator.Contracts
{
    internal interface IAnimalWorld 
    {
        IList<IAnimal> Animals { get; }
        int CurrentRoundNumber { get; }
        void AddAnimal(IAnimal animal);
        void ProcessRound();
    }
}
