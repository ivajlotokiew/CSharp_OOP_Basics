using System;

namespace Polymorphism_new
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumation, double tankCapacity)
            : base(fuelQuantity, fuelConsumation, tankCapacity)
        {
            this.FuelConsumation += 0.9;
        }

        public override void Refuel(double littres)
        {
            if (this.FuelQuantity + littres <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.TankCapacity > this.FuelQuantity + littres)
            {
                this.FuelQuantity += littres;
            }
            else
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }
        }

        public override void Distance(double distance)
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
