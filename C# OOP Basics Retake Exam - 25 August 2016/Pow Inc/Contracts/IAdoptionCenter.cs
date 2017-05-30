using System.Collections;
using System.Collections.Generic;

namespace ReallySimpleEngine.Contracts
{
    public interface IAdoptionCenter
    {
        string Name { get; set; }

        IList<IAnimal> Uncleansed { get; }

        List<IAnimal> Cleansed { get; }
    }
}
