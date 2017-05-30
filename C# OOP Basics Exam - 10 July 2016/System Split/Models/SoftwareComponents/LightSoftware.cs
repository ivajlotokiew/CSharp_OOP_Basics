namespace System_Split.Models.SoftwareComponents
{
    class LightSoftware : Software
    {
        public LightSoftware(string name, int capacity, int memory)
            : base(name, capacity, memory)
        {
        }

        public override int Memory => base.Memory - (base.Memory / 2);

        public override int Capacity => base.Capacity * 3 / 2;
    }
}
