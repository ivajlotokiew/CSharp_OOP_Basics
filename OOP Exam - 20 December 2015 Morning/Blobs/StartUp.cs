using System;
using ReallySimpleEngine.Factories;

namespace ReallySimpleEngine
{
    using Contracts;
    using Core;
    using UI;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IBlobFactory blobFactory = new BlobFactory();
            IAttackFactory attackFactory = new AttackFactory();
            IBehaviorFactory behaviorFactory = new BehaviorFactory();

            var engine = new Engine(reader, writer, blobFactory,
                 behaviorFactory, attackFactory);

            engine.Run();
        }
    }
}