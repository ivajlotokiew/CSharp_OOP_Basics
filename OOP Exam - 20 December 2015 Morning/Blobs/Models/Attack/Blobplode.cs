using ReallySimpleEngine.Contracts;

namespace ReallySimpleEngine.Models.Attack
{
    public class Blobplode : IAttack
    {
        private IUnit unit;

        public Blobplode(IUnit unit)
        {
            this.unit = unit;
        }

        public int ActivateAtack()
        {
            if (this.unit.Health > 1)
            {
                this.unit.Health -= this.unit.Health / 2;
            }

            var attackDamage = this.unit.Damage * 2;

            return attackDamage;
        }
    }
}