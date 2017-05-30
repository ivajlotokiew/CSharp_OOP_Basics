using System;

namespace Polymorphism_new
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumation, double tankCapacity)
            : base(fuelQuantity, fuelConsumation, tankCapacity)
        {
        }

        public override void Refuel(double littres)
        {
            if (this.FuelQuantity + littres < 0)
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
            double maxDistance = this.FuelQuantity / (this.FuelConsumation + 1.4);
            if (maxDistance < distance)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                this.FuelQuantity -= distance * (this.FuelConsumation + 1.4);
                Console.WriteLine($"Bus travelled {distance} km");
            }
        }

        public override void DistanceEmpty(double distance)
        {
            double maxDistance = this.FuelQuantity / this.FuelConsumation;
            if (maxDistance < distance)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                this.FuelQuantity -= distance * this.FuelConsumation;
                Console.WriteLine($"Bus travelled {distance} km");
            }
        }
    }
}
