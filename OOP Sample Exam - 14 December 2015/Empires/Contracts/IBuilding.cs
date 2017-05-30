using System.Collections.Generic;

namespace ReallySimpleEngine.Contracts
{
    public interface IBuilding : IUpdateable
    {
        List<IUnit> Units { get; }

        List<IResource> Resources { get; }

        int CountTurns { get; set; }

        int TurnsProduceUnit { get; set; }

        int TurnsProduceResource { get; set; }

        void ProduceUnit(string typeBuilding);

        void ProduceRecource(string sourceBuilding);
    }
}