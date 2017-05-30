namespace ReallySimpleEngine.Models.Centers
{
    using System;
    using System.Collections.Generic;
    using ReallySimpleEngine.Contracts;

    public class CleansingCenter : ICleansingCenter
    {
        public CleansingCenter(string name)
        {
            this.Name = name;
            this.AnimalsForCleansing = new Dictionary<string, List<IAnimal>>();
        }

        public string Name { get; }

        public IDictionary<string, List<IAnimal>> AnimalsForCleansing { get; }
    }
}
