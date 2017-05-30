namespace ReallySimpleEngine.Models.Factories
{
    using ReallySimpleEngine.Contracts;
    using Centers;
    using System;
    using System.Collections.Generic;

    public class AdoptedCenterFactory : IFactoryAdoptedCenter
    {
        public IAdoptionCenter RegisterAdoptingCenter(string name)
        {
            return new AdoptionCenter(name);
        }
    }
}
