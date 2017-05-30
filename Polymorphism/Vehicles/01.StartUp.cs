using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Polymorphism_new
{
    public class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            List<Vehicle> vehicles = new List<Vehicle>();
            string[] carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.None);
            double cFuelQuantity = double.Parse(carInfo[1]);
            double cConsumation = double.Parse(carInfo[2]);
            Car car = new Car(cFuelQuantity, cConsumation);
            vehicles.Add(car);

            string[] truckInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.None);
            double tFuelQuantity = double.Parse(truckInfo[1]);
            double tConsumation = double.Parse(truckInfo[2]);
            Truck truck = new Truck(tFuelQuantity, tConsumation);
            vehicles.Add(truck);

            int numbLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbLines; i++)
            {
                string[] data = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string vehycleType = data[1];

                switch (vehycleType)
                {
                    case "Car":
                        string cAction = data[0];
                        double cResult = double.Parse(data[2]);
                        if (cAction == "Drive")
                        {
                            car.Driven(cResult);
                        }
                        else
                        {
                            car.Refuel(cResult);
                        }
                        break;
                    case "Truck":
                        string tAction = data[0];
                        double tResult = double.Parse(data[2]);
                        if (tAction == "Drive")
                        {
                            truck.Driven(tResult);
                        }
                        else
                        {
                            truck.Refuel(tResult);
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity :F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity :F2}");
        }
    }
}
