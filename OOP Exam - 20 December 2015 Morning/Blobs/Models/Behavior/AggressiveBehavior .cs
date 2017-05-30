using System.Runtime.InteropServices;
using ReallySimpleEngine.Contracts;

namespace ReallySimpleEngine.Models.Behavior
{
    public class AggressiveBehavior : IBehavior
    {
        private IUnit unit;
        private readonly int initialDamage;

        public AggressiveBehavior(IUnit unit)
        {
            this.unit = unit;
            this.initialDamage = this.unit.Damage;
        }

        public void ActivateBehavior()
        {
            this.unit.Damage *= 2;
        }

        public void SubsequentActions()
        {
            if (this.unit.Damage <= this.initialDamage)
            {
                this.unit.Damage = this.initialDamage;
            }
            else
            {
                this.unit.Damage -= 5;
            }
        }
    }
}