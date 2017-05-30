using System.Collections.Generic;
using System_Split.Models.SoftwareComponents;

namespace System_Split.Models.Hardware_Components
{
    public class HeavyHardware : Hardware
    {
        public HeavyHardware(string name, int capacity, int memory, List<Software> software)
            : base(name, capacity, memory, software)
        {
        }

        public override int Capacity
        {
            get { return base.Capacity * 2; }
        }

        public override int Memory
        {
            get { return base.Memory - base.Memory * 1 / 4; }
        }
    }
}
