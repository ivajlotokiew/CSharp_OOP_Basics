using System;

namespace Polymorphism_new
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumation, double tankCapacity)
            : base(fuelQuantity, fuelConsumation, tankCapacity)
        {
            this.FuelConsumation += 1.6;
        }

        public override void Refuel(double littres)
        {
            if (this.FuelQuantity + littres < 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                this.FuelQuantity += littres * 0.95;
            }
        }

        public override void Distance(double distance)
        {
            double maxDistance = this.FuelQuantity / this.FuelConsumation;
            if (maxDistance < distance)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                this.FuelQuantity -= distance * this.FuelConsumation;
                Console.WriteLine($"Truck travelled {distance} km");
            }
        }
    }
}