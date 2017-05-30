namespace ReallySimpleEngine
{
    using Contracts;
    using Core;
    using UI;
    using Models.Factories;
    using Models;
    using System.Collections.Generic;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IFactoryCleansingCenter factoryClearsinCenter = new CleansingCenterFactory();
            IFactoryAdoptedCenter factoryAdoptingCenter = new AdoptedCenterFactory();
            IFactoryDog factoryDog = new DogFactory();
            IFactoryCat factoryCat = new CatFactory();
            IDataBaseCenter dataBase = new DataBaseCenter();

            var engine = new Engine(reader, writer, factoryClearsinCenter,
                factoryAdoptingCenter, factoryDog, factoryCat, dataBase);

            engine.Run();
        }
    }
}