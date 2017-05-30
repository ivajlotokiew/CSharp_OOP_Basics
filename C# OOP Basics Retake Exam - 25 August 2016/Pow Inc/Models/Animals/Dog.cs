namespace ReallySimpleEngine.Models.Animals
{
    using System;
    using ReallySimpleEngine.Contracts;

    public class Dog : IAnimal
    {
        private int age;
        private string name;

        public Dog(string name, int age, int amountOfCommands)
        {
            this.Name = name;
            this.Age = age;
            this.AmountOfCommands = amountOfCommands;
            this.Unclensed = true;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int AmountOfCommands { get; }

        public bool Unclensed { get; set; }
    }
}
