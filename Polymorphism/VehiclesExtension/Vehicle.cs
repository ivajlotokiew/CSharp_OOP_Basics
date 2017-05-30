using System;

namespace Polymorphism_new
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumation;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumation, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumation = fuelConsumation;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumation { get; set; }

        public double TankCapacity { get; set; }

        public abstract void Refuel(double littres);

        public abstract void Distance(double distance);

        public virtual void DistanceEmpty(double distance)
        {
        }
    }
}
