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
            string[] carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double cFuelQuantity = double.Parse(carInfo[1]);
            double cConsumation = double.Parse(carInfo[2]);
            double cTankCapacity = double.Parse(carInfo[3]);

            Vehicle car = new Car(cFuelQuantity, cConsumation, cTankCapacity);
            vehicles.Add(car);

            string[] truckInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double tFuelQuantity = double.Parse(truckInfo[1]);
            double tConsumation = double.Parse(truckInfo[2]);
            double tTankCapacity = double.Parse(truckInfo[3]);
            Vehicle truck = new Truck(tFuelQuantity, tConsumation, tTankCapacity);
            vehicles.Add(truck);

            string[] busInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double bFuelQuantity = double.Parse(busInfo[1]);
            double bConsumation = double.Parse(busInfo[2]);
            double bTankCapacity = double.Parse(busInfo[3]);
            Vehicle bus = new Bus(bFuelQuantity, bConsumation, bTankCapacity);

            int numbLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbLines; i++)
            {
                try
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
                                car.Distance(cResult);
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
                                truck.Distance(tResult);
                            }
                            else
                            {
                                truck.Refuel(tResult);
                            }
                            break;
                        case "Bus":
                            string bAction = data[0];
                            double bResult = double.Parse(data[2]);
                            if (bAction == "Drive")
                            {
                                bus.Distance(bResult);
                            }
                            else if (bAction == "DriveEmpty")
                            {
                                bus.DistanceEmpty(bResult);
                            }
                            else
                            {
                                bus.Refuel(bResult);
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

        }
    }
}
