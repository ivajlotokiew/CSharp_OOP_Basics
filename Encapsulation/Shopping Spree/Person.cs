using System;
using System.Collections.Generic;

namespace _04.Problem_New
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProdutcts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProdutcts = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public void BuyingProduct(Product productToBuy)
        {
            if (this.money < productToBuy.Cost)
            {
                Console.WriteLine($"{this.name} can't afford {productToBuy.Name}");
            }
            else
            {
                Console.WriteLine($"{this.name} bought {productToBuy.Name}");
                this.bagOfProdutcts.Add(productToBuy);
                this.money -= productToBuy.Cost;
            }
        }

        public List<Product> ListOfProducts()
        {
            return this.bagOfProdutcts;
        }
    }
}
