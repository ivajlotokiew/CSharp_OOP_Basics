namespace ReallySimpleEngine.Contracts
{
    using ReallySimpleEngine.Enums;
    public interface IResource
    {
        ResourceType ResourceType { get; }

        int Quantity { get; }
    }
}