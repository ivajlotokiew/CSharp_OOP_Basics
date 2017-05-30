namespace ReallySimpleEngine.Contracts
{
    public interface IEngine
    {
        IWriter Writer { get; }

        void Run();
    }
}