using ReallySimpleEngine.Contracts;

namespace ReallySimpleEngine.Models.Attack
{
    public class PutridFart : IAttack
    {
        private readonly IUnit unit;

        public PutridFart(IUnit unit)
        {
            this.unit = unit;
        }

        public int ActivateAtack()
        {
            var attackDamage = this.unit.Damage;

            return attackDamage;
        }
    }
}