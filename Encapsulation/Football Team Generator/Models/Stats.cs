using System;
using System.Runtime.Remoting.Channels;

namespace _06.Problem_NewVersion.Models
{
    public class Stats
    {
        private const int MinValueRange = 0;
        private const int MaxValueRange = 100;

        private int range;

        public Stats(string name, int range)
        {
            this.Name = name;
            this.Range = range;
        }

        public string Name { get; set; }

        public int Range
        {
            get
            {
                return this.range;
            }
            set
            {
                if (value < MinValueRange || value > MaxValueRange)
                {
                    throw new ArgumentException($"{this.Name} should be between 0 and 100.");
                }

                this.range = value;
            }
        }
    }
}
