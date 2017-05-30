using System.Collections.Generic;

namespace ReallySimpleEngine.Contracts
{
    public interface IDataBaseCenter
    {
        IDictionary<string, IAdoptionCenter> StoreAdoptingCenters { get; }

        IDictionary<string, ICleansingCenter> StoreCleansingCenters { get; }
        
        List<string> AdoptedAnimals { get; }

        List<IAnimal> CleansedAnimals { get; }
    }
}
