using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _06.Problem
{
    public class Car
    {
        public string model;
        public Engine engine;
        public Cargo cargo;
        public Tire tire;

        public Car(string model, Engine engine, Cargo cargo, Tire tire)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tire = tire;
        }
    }

    public class Engine
    {
        public int engineSpeed;
        public int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }
    }

    public class Cargo
    {
        public int cargoWeight;
        public string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }
    }

    public class Tire
    {
        public double tire1Pressure;
        public int tire1Age;
        public double tire2Pressure;
        public int tire2Age;
        public double tire3Pressure;
        public int tire3Age;
        public double tire4Pressure;
        public int tire4Age;

        public Tire(double tire1Pressure, int tire1Age,
            double tire2Pressure, int tire2Age, double tire3Pressure,
            int tire3Age, double tire4Pressure, int tire4Age)
        {
            this.tire1Pressure = tire1Pressure;
            this.tire1Age = tire1Age;
            this.tire2Pressure = tire2Pressure;
            this.tire2Age = tire2Age;
            this.tire3Pressure = tire3Pressure;
            this.tire3Age = tire3Age;
            this.tire4Pressure = tire4Pressure;
            this.tire4Age = tire4Age;
        }
    }

    public class RawData
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string modelCar = input[0];
                int engineSpeedCar = int.Parse(input[1]);
                int enginePowerCar = int.Parse(input[2]);
                int cargoWeightCar = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1PressureCar = double.Parse(input[5]);
                int tire1AgeCar = int.Parse(input[6]);
                double tire2PressureCar = double.Parse(input[7]);
                int tire2AgeCar = int.Parse(input[8]);
                double tire3PressureCar = double.Parse(input[9]);
                int tire3AgeCar = int.Parse(input[10]);
                double tire4PressureCar = double.Parse(input[11]);
                int tire4AgeCar = int.Parse(input[12]);

                var currentCar = new Car(modelCar, new Engine(engineSpeedCar, enginePowerCar),
                    new Cargo(cargoWeightCar, cargoType), new Tire(tire1PressureCar, tire1AgeCar,
                    tire2PressureCar, tire2AgeCar, tire3PressureCar, tire3AgeCar, tire4PressureCar, tire4AgeCar));

                cars.Add(currentCar);
            }

            string command = Console.ReadLine();

            switch (command)
            {
                case "fragile":
                    cars.Where(car => car.cargo.cargoType == "fragile")
                        .Where(tire => tire.tire.tire1Pressure < 1 || tire.tire.tire2Pressure < 1 ||
                                       tire.tire.tire3Pressure < 1 || tire.tire.tire4Pressure < 1)
                                       .ToList().ForEach(cw => Console.WriteLine($"{cw.model}"));
                    break;

                case "flamable":
                    cars.Where(car => car.cargo.cargoType == "flamable")
                        .Where(eng => eng.engine.enginePower > 250)
                        .ToList()
                        .ForEach(cw => Console.WriteLine($"{cw.model}"));
                    break;
            }
        }
    }
}