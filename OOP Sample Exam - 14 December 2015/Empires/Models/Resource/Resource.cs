using ReallySimpleEngine.Contracts;
using ReallySimpleEngine.Enums;

namespace ReallySimpleEngine.Models.Resource
{
    public class Resource : IResource
    {
        public Resource(ResourceType resourceType, int quantity)
        {
            this.ResourceType = resourceType;
            this.Quantity = quantity;
        }

        public ResourceType ResourceType { get; }

        public int Quantity { get; }
    }
}