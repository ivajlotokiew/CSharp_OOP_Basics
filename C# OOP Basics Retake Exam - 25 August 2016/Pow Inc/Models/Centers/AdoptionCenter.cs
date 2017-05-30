namespace ReallySimpleEngine.Models.Centers
{
    using System;
    using System.Collections.Generic;
    using ReallySimpleEngine.Contracts;

    class AdoptionCenter : IAdoptionCenter
    {
        public AdoptionCenter(string name)
        {
            this.Name = name;
            this.Cleansed = new List<IAnimal>();
            this.Uncleansed = new List<IAnimal>();
        }

        public List<IAnimal> Cleansed { get; }

        public string Name { get; set; }

        public IList<IAnimal> Uncleansed { get; }
    }
}
