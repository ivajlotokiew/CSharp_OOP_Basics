using System;
using ReallySimpleEngine.Contracts;
using ReallySimpleEngine.Models.Behavior;

namespace ReallySimpleEngine.Factories
{
    public class BehaviorFactory : IBehaviorFactory
    {
        public IBehavior CreateBehavior(string typeBehavior, IUnit unit)
        {
            switch (typeBehavior)
            {
                case "Aggressive":
                    return new AggressiveBehavior(unit);
                case "Inflated":
                    return new InflatedBehavior(unit);
                default:
                    throw new ArgumentException("Unknown behavior");
            }
        }
    }
}