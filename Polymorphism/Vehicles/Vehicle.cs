namespace Polymorphism_new
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumation;

        protected Vehicle(double fuelQuantity, double fuelConsumation)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumation = fuelConsumation;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumation { get; set; }

        public abstract void Refuel(double littres);

        public abstract void Driven(double distance);
    }
}
