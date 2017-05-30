namespace ReallySimpleEngine.Models.Animals
{
    using System;
    using ReallySimpleEngine.Contracts;

    public class Cat : IAnimal
    {
        private int age;
        private string name;

        public Cat(string name, int age, int intelligenceCoefficient)
        {
            this.Name = name;
            this.Age = age;
            this.IntelligenceCoefficient = intelligenceCoefficient;
            this.Uncleansed = true;
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

        public int IntelligenceCoefficient { get; set; }

        public bool Uncleansed { get; set; }
    }
}
