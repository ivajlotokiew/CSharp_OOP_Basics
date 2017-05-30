using System;
using System.Globalization;
using System.Threading;

namespace _08.Problem
{
    public class Car
    {
        public decimal speed;
        public decimal fuel;
        public decimal fuelEkonomy;
        public decimal totalDistance;
        public decimal totalTravelTime;

        public Car(decimal speed, decimal fuel, decimal fuelEkonomy)
        {
            this.speed = speed;
            this.fuel = fuel;
            this.fuelEkonomy = fuelEkonomy;
            this.totalDistance = 0;
            this.totalTravelTime = 0;
        }

        public void Travel(decimal distance)
        {
            decimal maxDistance = (this.fuel / this.fuelEkonomy) * 100;

            if (maxDistance <= distance)
            {
                this.fuel = 0;
                this.totalTravelTime += maxDistance / this.speed;
                this.totalDistance += maxDistance;
            }
            else
            {
                this.fuel -= (distance * this.fuelEkonomy) / 100;
                this.totalTravelTime += distance / this.speed;

                this.totalDistance += distance;
            }
        }

        public void Refuel(decimal fuelToCharge)
        {
            this.fuel = +fuelToCharge;
        }

        public decimal Distance()
        {
            return this.totalDistance;
        }

        public decimal Fuel()
        {
            return this.fuel;
        }

        public string Time()
        {
            string[] time = this.totalTravelTime.ToString().Split('.');
            string hours = time[0];
            string totalTime = String.Empty;

            if (time.Length > 1)
            {
                string mins = (decimal.Parse(time[1]) * 6).ToString();
                totalTime = $"{hours} hours and {mins} minutes";
            }
            else
            {
                totalTime = $"{hours} hours and 0 minutes";
            }

            return totalTime;
        }

    }

    public class CarsInfo
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string[] parametres = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            decimal speed = decimal.Parse(parametres[0]);
            decimal fuel = decimal.Parse(parametres[1]);
            decimal fuelEconomy = decimal.Parse(parametres[2]);
            Car curentCar = new Car(speed, fuel, fuelEconomy);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split();
                string command = data[0];
                switch (command)
                {
                    case "Travel":
                        decimal distance = decimal.Parse(data[1]);
                        curentCar.Travel(distance);
                        break;
                    case "Distance":
                        Console.WriteLine($"Total distance: {curentCar.Distance():F1} kilometers");
                        break;
                    case "Time":
                        Console.WriteLine($"Total time: {curentCar.Time()}");
                        break;
                    case "Fuel":
                        Console.WriteLine($"Fuel left: {curentCar.Fuel():F1} liters");
                        break;
                    default:
                        decimal refuel = decimal.Parse(data[1]);
                        curentCar.Refuel(refuel);
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}