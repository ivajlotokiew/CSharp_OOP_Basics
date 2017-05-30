using ReallySimpleEngine.Contracts;
using ReallySimpleEngine.Models.Behavior;
using ReallySimpleEngine.Models.Unit;

namespace ReallySimpleEngine.Factories
{
    public class BlobFactory : IBlobFactory
    {
        public IUnit CreateBlob(string name, int heatlh, int damage,
            string behaviorType, string attackType,
            IBehaviorFactory behavior, IAttackFactory attack)
        {
            var blob = new Blob(name, heatlh, damage, behaviorType, attackType, behavior, attack);

            return blob;
        }
    }
}