namespace ReallySimpleEngine.Core
{
    using System;
    using Contracts;
    using Models.Factories;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private IWriter writer;
        private IFactoryCleansingCenter factoryCleansingCenter;
        private IFactoryAdoptedCenter factoryAdoptingCenter;
        private IFactoryDog factoryDog;
        private IFactoryCat factoryCat;
        private IDataBaseCenter dataBase;

        public Engine(
            IReader reader,
            IWriter writer,
            IFactoryCleansingCenter factoryCleansingCenter,
            IFactoryAdoptedCenter factoryAdoptingCenter,
            IFactoryDog factoryDog,
            IFactoryCat factoryCat,
            IDataBaseCenter dataBase)
        {
            this.reader = reader;
            this.Writer = writer;
            this.factoryCleansingCenter = factoryCleansingCenter;
            this.factoryAdoptingCenter = factoryAdoptingCenter;
            this.factoryDog = factoryDog;
            this.factoryCat = factoryCat;
            this.dataBase = dataBase;
        }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.writer = value;
            }
        }

        public void Run()
        {
            while (true)
            {
                string[] commandArgs = this.reader.Read().Split('|');

                try
                {
                    this.ProcessCommand(commandArgs);
                }
                catch (Exception ex)
                {
                    this.writer.Print(ex.Message);
                }
            }
        }

        protected virtual void ProcessCommand(string[] commandArgs)
        {
            switch (commandArgs[0].Trim())
            {
                case "RegisterCleansingCenter":
                    ExecuteRegisterCleansingCenter(commandArgs[1].Trim());
                    break;
                case "RegisterAdoptionCenter":
                    ExecuteRegisterAdoptionCenter(commandArgs[1].Trim());
                    break;
                case "RegisterDog":
                    ExecuteRegisterDog(commandArgs);
                    break;
                case "RegisterCat":
                    ExecuteRegisterCat(commandArgs);
                    break;
                case "SendForCleansing":
                    ExecuteSendForCleansing(commandArgs);
                    break;
                case "Cleanse":
                    ExecuteCleanse(commandArgs[1].Trim());
                    break;
                case "Adopt":
                    ExecuteAdopt(commandArgs[1].Trim());
                    break;
                case "Paw Paw Pawah":
                    ExecutePrint();
                    Environment.Exit(0);
                    break;
                default:
                    throw new NotImplementedException("Command not implemented yet");
            }
        }

        private void ExecutePrint()
        {
            Console.WriteLine(dataBase);
        }

        private void ExecuteAdopt(string name)
        {
            var adoptedAnimals = dataBase.StoreAdoptingCenters[name].Cleansed;
            foreach (var animal in adoptedAnimals)
            {
                dataBase.AdoptedAnimals.Add(animal.Name);
            }

            dataBase.StoreAdoptingCenters[name].Cleansed.Clear();
        }

        private void ExecuteCleanse(string name)
        {
            var animalsToReturn = dataBase.StoreCleansingCenters[name].AnimalsForCleansing;
            foreach (var item in animalsToReturn)
            {
                dataBase.StoreAdoptingCenters[item.Key].Cleansed.AddRange(item.Value);
                dataBase.CleansedAnimals.AddRange(item.Value);
            }

            animalsToReturn.Clear();
        }

        private void ExecuteSendForCleansing(string[] commandArgs)
        {
            string adoptionCenterName = commandArgs[1].Trim();
            string cleansingCenterName = commandArgs[2].Trim();

            var animalsForCleansing =
                dataBase.StoreAdoptingCenters[adoptionCenterName].Uncleansed;
            dataBase.StoreCleansingCenters[cleansingCenterName]
                .AnimalsForCleansing.Add(adoptionCenterName, new List<IAnimal>(animalsForCleansing));
            dataBase.StoreAdoptingCenters[adoptionCenterName].Uncleansed.Clear();
        }

        private void ExecuteRegisterCat(string[] commandArgs)
        {
            string name = commandArgs[1].Trim();
            int age = int.Parse(commandArgs[2].Trim());
            int intelligenceCoefficient = int.Parse(commandArgs[3].Trim());
            string adoptionCenterName = commandArgs[4].Trim();

            var cat = factoryCat.RegisterCat(name, age, intelligenceCoefficient, adoptionCenterName);
            dataBase.StoreAdoptingCenters[adoptionCenterName].Uncleansed.Add(cat);
        }

        private void ExecuteRegisterDog(string[] commandArgs)
        {
            string name = commandArgs[1].Trim();
            int age = int.Parse(commandArgs[2].Trim());
            int learnedCommands = int.Parse(commandArgs[3].Trim());
            string adoptionCenterName = commandArgs[4].Trim();

            var dog = factoryDog.RegisterDog(name, age, learnedCommands, adoptionCenterName);
            dataBase.StoreAdoptingCenters[adoptionCenterName].Uncleansed.Add(dog);
        }

        private void ExecuteRegisterAdoptionCenter(string name)
        {
            var adoptingCenter = this.factoryAdoptingCenter.RegisterAdoptingCenter(name);
            dataBase.StoreAdoptingCenters.Add(name, adoptingCenter);
        }

        private void ExecuteRegisterCleansingCenter(string name)
        {
            var cleansingCenter = this.factoryCleansingCenter.RegisterCleansingCenter(name);
            dataBase.StoreCleansingCenters.Add(name, cleansingCenter);
        }
    }
}