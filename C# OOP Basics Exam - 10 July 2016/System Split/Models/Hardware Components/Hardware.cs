using System;
using System.Collections.Generic;
using System_Split.Models.SoftwareComponents;

namespace System_Split.Models.Hardware_Components
{
    public abstract class Hardware : System
    {
        protected Hardware(string name, int capacity, int memory, List<Software> software)
            : base(name, capacity, memory)
        {
            this.Software = software;
        }

        public List<Software> Software { get; set; }
    }
}
