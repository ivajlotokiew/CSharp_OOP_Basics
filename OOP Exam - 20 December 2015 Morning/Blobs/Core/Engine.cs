using System.Collections.Generic;
using ReallySimpleEngine.Factories;

namespace ReallySimpleEngine.Core
{
    using System;
    using Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private IWriter writer;
        private Dictionary<string, IUnit> blobs;
        private IBlobFactory blobFactory;
        private IBehaviorFactory behaviorFactory;
        private IAttackFactory attackFactory;

        public Engine(
            IReader reader,
            IWriter writer,
            IBlobFactory blobFactory,
            IBehaviorFactory behaviorFactory,
            IAttackFactory attackFactory)
        {
            this.reader = reader;
            this.Writer = writer;
            this.blobFactory = blobFactory;
            this.behaviorFactory = behaviorFactory;
            this.attackFactory = attackFactory;
            this.blobs = new Dictionary<string, IUnit>();
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
                var commandArgs = this.reader.Read().Split(' ');

                try
                {
                    this.ProcessCommand(commandArgs);
                    this.UpdateData();
                }
                catch (Exception ex)
                {
                    this.writer.Print(ex.Message);
                }
            }
        }

        private void UpdateData()
        {
            string name = string.Empty;

            foreach (var blob in this.blobs.Values)
            {
                blob.Updateable();
                if (blob.Health <= 0)
                {
                    this.writer.Print($"Blob {blob.Name} KILLED");
                    name = blob.Name;
                }
            }

            this.blobs.Remove(name);
        }

        protected virtual void ProcessCommand(string[] commandArgs)
        {
            switch (commandArgs[0])
            {
                case "create":
                    this.ExecuteCreateCommand(commandArgs);
                    break;
                case "attack":
                    this.ExecuteAttackCommand(commandArgs);
                    break;
                case "status":
                    this.PrintBlobsStatus();
                    break;
                case "pass":
                    break;
                case "drop":
                    Environment.Exit(0);
                    break;
                default:
                    throw new NotImplementedException("Command not implemented yet");
            }
        }

        private void PrintBlobsStatus()
        {
            foreach (var blob in this.blobs)
            {
                this.writer.Print(blob.Value.ToString());
            }
        }

        private void ExecuteAttackCommand(string[] commandArgs)
        {
            var nameAttacker = commandArgs[1];
            var nameDeffender = commandArgs[2];

            if (!this.blobs.ContainsKey(nameAttacker) || !this.blobs.ContainsKey(nameDeffender))
            {
                throw new ArgumentException("Unknown unit name");
            }

            IUnit attacker = this.blobs[nameAttacker];
            int atackedDamage = attacker.Attacking();

            IUnit deffender = this.blobs[nameDeffender];
            deffender.Deffending(atackedDamage);

        }

        private void ExecuteCreateCommand(string[] commandArgs)
        {
            string name = commandArgs[1];
            int health = int.Parse(commandArgs[2]);
            int damage = int.Parse(commandArgs[3]);
            string behavior = commandArgs[4];
            string attack = commandArgs[5];

            var blob = this.blobFactory.CreateBlob(name, health, damage,
                behavior, attack, this.behaviorFactory, this.attackFactory);

            this.blobs.Add(name, blob);
        }
    }
}