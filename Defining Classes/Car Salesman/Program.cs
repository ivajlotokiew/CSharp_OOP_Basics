using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Problem
{
    public class Car
    {
        public Car(string modelCar, string engineCar)
        {
            this.modelCar = modelCar;
            this.engineCar = engineCar;
            this.weightCar = "n/a";
            this.colorCar = "n/a";
        }

        public string modelCar;
        public string engineCar;
        public string weightCar;
        public string colorCar;
    }

    public class Engine
    {
        public Engine(string modelEngine, int powerEngine)
        {
            this.modelEngine = modelEngine;
            this.powerEngine = powerEngine;
            this.displacementEngine = "n/a";
            this.efficienci = "n/a";
        }

        public string modelEngine;
        public int powerEngine;
        public string displacementEngine;
        public string efficienci;
    }

    public class CarSalesman
    {
        public static void Main()
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineFields = Console.ReadLine().Split();
                string modelEngine = engineFields[0];
                int powerEngine = int.Parse(engineFields[1]);
                Engine currentEngine = new Engine(modelEngine, powerEngine);

                if (engineFields.Length > 3)
                {
                    string displacementEngine = engineFields[2];
                    string efficienci = engineFields[3];
                    currentEngine.displacementEngine = displacementEngine;
                    currentEngine.efficienci = efficienci;
                    engines.Add(currentEngine);
                    continue;
                }
                if (engineFields.Length > 2)
                {

                    if (engineFields[2].Any(ch => char.IsDigit(ch)))
                    {
                        string displacementEngine = engineFields[2];
                        currentEngine.displacementEngine = displacementEngine;
                    }
                    else
                    {
                        string efficienci = engineFields[2];
                        currentEngine.efficienci = efficienci;
                    }
                }

                engines.Add(currentEngine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carFields = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string modelCar = carFields[0];
                string engineCar = carFields[1];
                Car currentCar = new Car(modelCar, engineCar);

                if (carFields.Length > 3)
                {
                    string weightCar = carFields[2];
                    string colorCar = carFields[3];
                    currentCar.weightCar = weightCar;
                    currentCar.colorCar = colorCar;
                    cars.Add(currentCar);
                    continue;
                }
                if (carFields.Length > 2)
                {
                    if (carFields[2].Any(ch => char.IsDigit(ch)))
                    {
                        string weightCar = carFields[2];
                        currentCar.weightCar = weightCar;
                    }
                    else
                    {
                        string colorCar = carFields[2];
                        currentCar.colorCar = colorCar;
                    }
                }

                cars.Add(currentCar);
            }

            var output = cars.Join(engines,
                car => car.engineCar,
                eng => eng.modelEngine,
                (car, eng) => new { Car = car, Eng = eng });

            foreach (var item in output)
            {

                Console.WriteLine($"{item.Car.modelCar}:\n  {item.Eng.modelEngine}:\n    Power: " +
                                  $"{item.Eng.powerEngine}\n    Displacement: {item.Eng.displacementEngine}\n" +
                                  $"    Efficiency: {item.Eng.efficienci}\n  " +
                                  $"Weight: {item.Car.weightCar}\n  Color: {item.Car.colorCar}");
            }

        }
    }
}