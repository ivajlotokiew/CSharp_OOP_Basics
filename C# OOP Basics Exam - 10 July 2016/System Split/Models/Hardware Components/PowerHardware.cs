using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System_Split.Models.SoftwareComponents;

namespace System_Split.Models.Hardware_Components
{
    public class PowerHardware : Hardware
    {
        public PowerHardware(string name, int capacity, int memory, List<Software> software)
            : base(name, capacity, memory, software)
        {
        }

        public override int Capacity
        {
            get { return base.Capacity - base.Capacity * 3 / 4; }
        }

        public override int Memory
        {
            get { return base.Memory + base.Memory * 3 / 4; }
        }
    }
}
