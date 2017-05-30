namespace Pizza.Models
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const int MinWeight = 0;
        private const int MaxWeight = 200;

        private readonly Dictionary<string, double> flourTypes = new Dictionary<string, double>()
        {
            { "White", 1.5 },
            { "Wholegrain", 1 },
        };

        private readonly Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
        {
            { "Crispy", 0.9 },
            { "Chewy", 1.1 },
            { "Homemade", 1 },
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            set
            {
                if (!this.flourTypes.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (!this.bakingTechniques.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                return this.CalculateCalories();
            }
        }

        private double CalculateCalories()
        {
            var totalCalories = 2 * this.weight * this.flourTypes[this.flourType] * this.bakingTechniques[this.bakingTechnique];

            return totalCalories;
        }
    }
}