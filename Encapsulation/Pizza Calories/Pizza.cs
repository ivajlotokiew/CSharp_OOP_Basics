using System;

namespace Pizza
{
    public class Pizza
    {
        private string pizzaName;
        private int numberOfToppings;

        public Pizza(string pizzaName, int numberOfToppings)
        {
            this.PizzaName = pizzaName;
            this.NumberOfToppings = numberOfToppings;
        }

        public string PizzaName
        {
            get
            {
                return this.pizzaName;
            }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.pizzaName = value;
            }
        }

        public int NumberOfToppings
        {
            get
            {
                return this.numberOfToppings;
            }
            private set
            {
                if (value < 0 || value > 10)
                {
                    throw new Exception("Number of toppings should be in range [0..10].");
                }

                this.numberOfToppings = value;
            }
        }

        public double TotalCalories
        {
            get
            {
                return this.CalculateTotalCalories();
            }
        }

        public double CalculateTotalCalories()
        {
            return PizzaMain.totalSUmCalories;
        }
    }
}
