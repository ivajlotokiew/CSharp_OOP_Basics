using ReallySimpleEngine.Contracts;

namespace ReallySimpleEngine.Models.Behavior
{
    public class InflatedBehavior : IBehavior
    {
        private readonly IUnit unit;

        public InflatedBehavior(IUnit unit)
        {
            this.unit = unit;
        }

        public void ActivateBehavior()
        {
            if (this.unit.Health < 0)
            {
                this.unit.Health = 0;
            }

            this.unit.Health += 50;
        }

        public void SubsequentActions()
        {
            this.unit.Health -= 10; // Must check if unit healt in negative in Engine
        }
    }
}