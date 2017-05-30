using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Pizza.Models
{
    public class Topping
    {
        private readonly Dictionary<string, double> toppingTypes = new Dictionary<string, double>()
        {
            { "Meat", 1.2 },
            { "Veggies", 0.8 },
            { "Cheese", 1.1 },
            { "Sauce", 0.9 }
        };

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public double Weight
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingTypes.Keys} weight should be in the range[1..50].");
                }

                this.weight = value;
            }
        }

        public string ToppingType
        {
            set
            {
                if (!this.toppingTypes.ContainsKey(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                return this.CalculateCalories();
            }
        }

        public double CalculateCalories()
        {
            var totalCalories = 2 * this.weight * this.toppingTypes[this.toppingType];

            return totalCalories;
        }
    }
}
