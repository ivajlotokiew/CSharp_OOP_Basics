namespace ReallySimpleEngine.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using Contracts;
    using System.Text;

    public class DataBaseCenter : IDataBaseCenter
    {
        public DataBaseCenter()
        {
            this.StoreAdoptingCenters = new Dictionary<string, IAdoptionCenter>();
            this.StoreCleansingCenters = new Dictionary<string, ICleansingCenter>();
            this.AdoptedAnimals = new List<string>();
            this.CleansedAnimals = new List<IAnimal>();
        }

        public List<string> AdoptedAnimals { get; }

        public List<IAnimal> CleansedAnimals { get; }

        public IDictionary<string, IAdoptionCenter> StoreAdoptingCenters { get; }

        public IDictionary<string, ICleansingCenter> StoreCleansingCenters { get; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Paw Incorporative Regular Statistics");
            output.AppendLine($"Adoption Centers: {StoreAdoptingCenters.Count}");
            output.AppendLine($"Cleansing Centers: {StoreCleansingCenters.Count}");
            if (AdoptedAnimals.Count == 0)
            {
                output.AppendLine($"Adopted Animals: None");
            }
            else
            {
                output.AppendLine($"Adopted Animals: {string.Join(", ", AdoptedAnimals.OrderBy(x => x))}");
            }

            if (CleansedAnimals.Count == 0)
            {
                output.AppendLine($"Cleansed Animals: None");
            }
            else
            {
                output.AppendLine($"Cleansed Animals: {string.Join(", ", CleansedAnimals.Select(x => x.Name).OrderBy(x => x))}");
            }
            output.AppendLine($"Animals Awaiting Adoption: {StoreAdoptingCenters.SelectMany(x => x.Value.Cleansed).Count()}");
            output.AppendLine($"Animals Awaiting Cleansing: {StoreCleansingCenters.SelectMany(x => x.Value.AnimalsForCleansing.SelectMany(o => o.Value)).Count()}");

            return output.ToString();
        }
    }
}
