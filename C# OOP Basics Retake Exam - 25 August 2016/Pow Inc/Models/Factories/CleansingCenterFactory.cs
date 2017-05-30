namespace ReallySimpleEngine.Models.Factories
{
    using Contracts;
    using Centers;

    public class CleansingCenterFactory : IFactoryCleansingCenter
    {
        public ICleansingCenter RegisterCleansingCenter(string name)
        {
            return new CleansingCenter(name);
        }
    }
}
