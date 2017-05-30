using System;

namespace Polymorphism_new
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumation)
            : base(fuelQuantity, fuelConsumation)
        {
            this.FuelConsumation += 0.9;
        }

        public override void Refuel(double littres)
        {
            this.FuelQuantity += littres;
        }

        public override void Driven(double distance)
        {
            double maxDistance = this.FuelQuantity / this.FuelConsumation;
            if (maxDistance < distance)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                this.FuelQuantity -= distance * this.FuelConsumation;
                Console.WriteLine($"Car travelled {distance} km");
            }
        }
    }
}
