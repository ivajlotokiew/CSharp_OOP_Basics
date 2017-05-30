using System;
using ReallySimpleEngine.Contracts;
using ReallySimpleEngine.Models.Attack;

namespace ReallySimpleEngine.Factories
{
    public class AttackFactory : IAttackFactory
    {
        public IAttack CreateAttack(string typeAttack, IUnit unit)
        {
            switch (typeAttack)
            {
                case "PutridFart":
                    return new PutridFart(unit);
                case "Blobplode":
                    return new Blobplode(unit);
                default:
                    throw new ArgumentException("Unknown attack.");
            }
        }
    }
}