using System.Text;

namespace ReallySimpleEngine.Models.Building
{
    public class Archery : Building
    {
        private const int DefaultTurnsProduceUnit = 3;
        private const int DefaultTurnsProduceResource = 2;
        private const string TypeBuilding = "archery";

        public Archery()
            : base(DefaultTurnsProduceUnit, DefaultTurnsProduceResource, TypeBuilding)
        {
            this.TurnsProduceUnit = DefaultTurnsProduceUnit;
            this.TurnsProduceResource = DefaultTurnsProduceResource;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            var countUnit = this.Units.Count;

            output.AppendLine("Units:");
            output.AppendLine($"--Swordsman: {countUnit}");

            return base.ToString();
        }
    }
}