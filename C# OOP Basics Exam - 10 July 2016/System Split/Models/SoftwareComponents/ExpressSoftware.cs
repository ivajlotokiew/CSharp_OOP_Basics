namespace System_Split.Models.SoftwareComponents
{
    public class ExpressSoftware : Software
    {
        public ExpressSoftware(string name, int capacity, int memory)
            : base(name, capacity, memory)
        {
        }

        public override int Capacity
        {
            get { return base.Capacity; }
        }

        public override int Memory
        {
            get { return 2 * base.Memory; }
        }
    }
}
