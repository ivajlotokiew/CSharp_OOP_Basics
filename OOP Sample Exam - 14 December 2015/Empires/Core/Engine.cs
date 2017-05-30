using System.Linq;

namespace ReallySimpleEngine.Core
{
    using System;
    using Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private IWriter writer;
        private readonly IBuildingFactory buildingFactory;
        private readonly IBuildingData buildingData;

        public Engine(
            IReader reader,
            IWriter writer,
            IBuildingFactory buildingFactory,
            IBuildingData buildingData)
        {
            this.reader = reader;
            this.Writer = writer;
            this.buildingFactory = buildingFactory;
            this.buildingData = buildingData;
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
                string[] commandArgs = this.reader.Read().Split(' ');

                try
                {
                    this.ProcessCommand(commandArgs);
                    UpdateMethod();
                }
                catch (Exception ex)
                {
                    this.writer.Print(ex.Message);
                }
            }
        }

        private void UpdateMethod()
        {
            foreach (var building in this.buildingData.Buildings)
            {
                building.UpdateData();
            }
        }

        protected virtual void ProcessCommand(string[] commandArgs)
        {
            switch (commandArgs[0])
            {
                case "build":
                    this.ExecuteBuildCommand(commandArgs);
                    break;
                case "empire-status":
                    this.PrintMethod();
                    break;
                case "skip":
                    break;
                case "armistice":
                    Environment.Exit(0);
                    break;
                default:
                    throw new NotImplementedException("Command not implemented yet");
            }
        }

        private void PrintMethod()
        {
            Console.WriteLine(this.buildingData.ToString());
        }

        private void ExecuteBuildCommand(string[] commandArgs)
        {
            string name = commandArgs[1];

            IBuilding building = this.buildingFactory.CreateBuilding(name);

            this.buildingData.Buildings.Add(building);
        }
    }
}