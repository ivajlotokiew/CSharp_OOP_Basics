using System.Collections;
using System.Collections.Generic;
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
            IBuildingFactory buildingFactory = new BuildingFactory();
            IBuildingData buildingData = new BuildingData();

            var engine = new Engine(reader, writer, buildingFactory, buildingData);

            engine.Run();
        }
    }
}