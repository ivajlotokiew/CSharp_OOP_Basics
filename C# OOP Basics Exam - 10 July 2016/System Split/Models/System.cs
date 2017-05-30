using System_Split.Interfaces;

namespace System_Split.Models
{
    public abstract class System : IComponentable
    {
        protected System(string name, int capacity, int memory)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Memory = memory;
        }

        public string Name { get; }

        public virtual int Capacity { get; }

        public virtual int Memory { get; }
    }
}
