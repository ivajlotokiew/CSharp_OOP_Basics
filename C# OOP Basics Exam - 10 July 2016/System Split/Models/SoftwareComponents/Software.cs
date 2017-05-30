namespace System_Split.Models.SoftwareComponents
{
    public abstract class Software : System
    {
        protected Software(string name, int capacity, int memory)
            : base(name, capacity, memory)
        {
        }
    }
}