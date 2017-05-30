using ReallySimpleEngine.Contracts;

namespace ReallySimpleEngine.Models.Unit
{
    public abstract class Unit : IUnit
    {
        protected Unit(int health, int damage)
        {
            this.Health = health;
            this.Damage = damage;
        }

        public int Health { get; }
        public int Damage { get; }
    }
}