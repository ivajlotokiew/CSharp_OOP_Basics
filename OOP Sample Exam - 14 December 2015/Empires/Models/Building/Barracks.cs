namespace ReallySimpleEngine.Models.Building
{
    public class Barracks : Building
    {
        private const int DefaultTurnsProduceUnit = 4;
        private const int DefaultTurnsProduceResource = 3;
        private const string TypeBuilding = "barracks";

        public Barracks()
            : base(DefaultTurnsProduceUnit, DefaultTurnsProduceResource, TypeBuilding)
        {
            this.TurnsProduceUnit = DefaultTurnsProduceUnit;
            this.TurnsProduceResource = DefaultTurnsProduceResource;
        }
    }
}