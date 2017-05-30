namespace ReallySimpleEngine.Contracts
{
    public interface IResourceFactory
    {
        IResource CreateResource(string typeBuilding);
    }
}