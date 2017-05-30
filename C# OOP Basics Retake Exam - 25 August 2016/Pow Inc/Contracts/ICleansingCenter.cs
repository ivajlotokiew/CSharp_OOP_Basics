using System.Collections.Generic;

namespace ReallySimpleEngine.Contracts
{
    public interface ICleansingCenter
    {
        string Name { get; }

        IDictionary<string, List<IAnimal>> AnimalsForCleansing { get; }
    }
}
