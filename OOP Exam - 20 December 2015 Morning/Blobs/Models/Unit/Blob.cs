using ReallySimpleEngine.Contracts;

namespace ReallySimpleEngine.Models.Unit
{
    public class Blob : IUnit
    {
        readonly IAttackFactory attackFactory;
        readonly IBehaviorFactory behaviorFactory;
        private readonly int initialHealth;
        private IBehavior behavior;
        private bool isBehaviorActivated;
        private bool IsBahaviuorIsDone;
        private bool isMoreThanOneUpdate;

        public Blob(string name, int health, int damage,
            string behaviorType, string attackType,
            IBehaviorFactory behaviorFactory, IAttackFactory attackFactory)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.BehaviorType = behaviorType;
            this.AttackType = attackType;
            this.behaviorFactory = behaviorFactory;
            this.attackFactory = attackFactory;
            this.initialHealth = health;
            this.isBehaviorActivated = false;
            this.IsBahaviuorIsDone = false;
            this.isMoreThanOneUpdate = false;
        }

        public string Name { get; }

        public int Health { get; set; }

        public int Damage { get; set; }

        public string BehaviorType { get; }

        public string AttackType { get; }

        public int Attacking()
        {
            IAttack attack = this.attackFactory.CreateAttack(this.AttackType, this);
            int attackDamage = attack.ActivateAtack();

            this.CheckIfBehaviorIsActivated();

            if (this.isBehaviorActivated && !this.IsBahaviuorIsDone)
            {
                this.behavior = this.behaviorFactory.CreateBehavior(this.BehaviorType, this);

                this.behavior.ActivateBehavior();
                this.IsBahaviuorIsDone = true;
                this.isMoreThanOneUpdate = false;
            }

            return attackDamage;
        }

        public void Deffending(int damage)
        {
            this.Health -= damage;

            this.CheckIfBehaviorIsActivated();

            if (this.isBehaviorActivated && !this.IsBahaviuorIsDone)
            {
                this.behavior = this.behaviorFactory.CreateBehavior(this.BehaviorType, this);

                this.behavior.ActivateBehavior();
                this.IsBahaviuorIsDone = true;
                this.isMoreThanOneUpdate = false;
            }
        }

        private void CheckIfBehaviorIsActivated()
        {
            if (this.Health <= this.initialHealth / 2)
            {
                this.isBehaviorActivated = true;
            }
        }

        public void Updateable()
        {
            if (this.isBehaviorActivated && this.isMoreThanOneUpdate)
            {
                this.behavior.SubsequentActions();
            }

            this.isMoreThanOneUpdate = true;
        }

        public override string ToString()
        {
            return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }
    }
}