using System.Collections.Generic;

namespace ReallySimpleEngine.Contracts
{
    public interface IBuildingData
    {
        IList<IBuilding> Buildings { get; set; }
    }
}