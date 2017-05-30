using ReallySimpleEngine.Contracts;

namespace ReallySimpleEngine.Models.Unit
{
    public class Barbaron : IUnit
    {
        public void Updateable()
        {
            throw new System.NotImplementedException();
        }

        public string Name { get; }

        public int Health { get; set; }

        public int Damage { get; set; }

        public string BehaviorType { get; }

        public string AttackType { get; }

        public int Attacking()
        {
            throw new System.NotImplementedException();
        }

        public void Deffending(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}