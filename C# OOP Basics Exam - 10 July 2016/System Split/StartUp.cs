using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System_Split.Models.Hardware_Components;
using System_Split.Models.SoftwareComponents;

namespace System_Split
{
    public class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dictionary = new Dictionary<string, Hardware>();
            var dump = new Dictionary<string, Hardware>();

            string input = Console.ReadLine();
            Regex regex = new Regex(@"([\w]+)\(([^\)]+)\)");

            while (input != "System Split")
            {
                int totalOperacitonMemory = 0;
                int totalOperacitonCapacity = 0;
                int maxOperationMemory = 0;
                int maxOperationCapacity = 0;

                if (regex.IsMatch(input))
                {
                    MatchCollection matches = regex.Matches(input);
                    string name = matches[0].Groups[1].Value;
                    string[] dataSystem = matches[0].Groups[2].Value
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    switch (name)
                    {
                        case "RegisterPowerHardware":
                            Hardware hardwaredPower;
                            var namePHardware = CreatePowerHardware(dataSystem, name, out hardwaredPower);
                            dictionary.Add(namePHardware, hardwaredPower);
                            break;
                        case "RegisterHeavyHardware":
                            Hardware hardwaredHeavy;
                            var nameHHardware = CreateHeavyHardware(dataSystem, name, out hardwaredHeavy);
                            dictionary.Add(nameHHardware, hardwaredHeavy);
                            break;
                        case "RegisterLightSoftware":
                            Software lsSoft;
                            string lsHName = dataSystem[0];
                            CreateLightSoftware(dataSystem, out lsSoft);
                            bool isEnoughCapacityForLightSoft = CheckForEnoughSpace(dictionary, lsHName, lsSoft);
                            if (!isEnoughCapacityForLightSoft)
                            {
                                break;
                            }

                            dictionary[lsHName].Software.Add(lsSoft);
                            break;
                        case "RegisterExpressSoftware":
                            Software esSoft;
                            string elHName = dataSystem[0];
                            CreateExpressSoftware(dataSystem, out esSoft);
                            bool isEnoughCapacityForExpressSoft = CheckForEnoughSpace(dictionary, elHName, esSoft);
                            if (!isEnoughCapacityForExpressSoft)
                            {
                                break;
                            }

                            dictionary[elHName].Software.Add(esSoft);
                            break;
                        case "ReleaseSoftwareComponent":
                            ReleasedSoftwareComponentFromSystem(dataSystem, dictionary);
                            break;
                        case "Dump":
                            string hardwareToRemove = dataSystem[0];
                            dump.Add(hardwareToRemove, dictionary[hardwareToRemove]);
                            dictionary.Remove(hardwareToRemove);
                            break;

                        case "Restore":
                            string hardwareToRestore = dataSystem[0];
                            dictionary.Add(hardwareToRestore, dump[hardwareToRestore]);
                            dump.Remove(hardwareToRestore);
                            break;
                        case "Destroy":
                            string destroyHardware = dataSystem[0];
                            dump.Remove(destroyHardware);
                            break;

                    }
                }
                else if (input == "Analyze()")
                {
                    CalculateData(dictionary, ref totalOperacitonMemory,
                    ref totalOperacitonCapacity, ref maxOperationCapacity, ref maxOperationMemory);
                    PrintSystemAnalize(dictionary, totalOperacitonMemory, maxOperationMemory, totalOperacitonCapacity, maxOperationCapacity);
                }
                else if (input == "DumpAnalyze()")
                {
                    PrintDumpAnalyze(dump);
                }

                input = Console.ReadLine();
            }

            GetFullInfoSystem(dictionary);
        }

        private static void PrintSystemAnalize(Dictionary<string, Hardware> dictionary, int totalOperacitonMemory, int maxOperationMemory,
            int totalOperacitonCapacity, int maxOperationCapacity)
        {
            Console.WriteLine("System Analysis");
            Console.WriteLine($"Hardware Components: {dictionary.Count}");
            Console.WriteLine($"Software Components: {dictionary.Values.Sum(st => st.Software.Count)}");
            Console.WriteLine($"Total Operational Memory: {totalOperacitonMemory} / {maxOperationMemory}");
            Console.WriteLine($"Total Capacity Taken: {totalOperacitonCapacity} / {maxOperationCapacity}");
        }

        private static void PrintDumpAnalyze(Dictionary<string, Hardware> dump)
        {
            Console.WriteLine("Dump Analysis");
            Console.WriteLine($"Power Hardware Components: {dump.Values.Count(st => st is PowerHardware)}");
            Console.WriteLine($"Heavy Hardware Components: {dump.Values.Count(st => st is HeavyHardware)}");
            Console.WriteLine($"Express Software Components: " +
                              $"{dump.Values.SelectMany(st => st.Software).Count(st => st is ExpressSoftware)}");
            Console.WriteLine($"Light Software Components:" +
                              $" {dump.Values.SelectMany(st => st.Software).Count(st => st is LightSoftware)}");
            Console.WriteLine($"Total Dumped Memory: " +
                              $"{dump.Values.SelectMany(st => st.Software).Sum(st => st.Memory)}");
            Console.WriteLine($"Total Dumped Capacity: " +
                              $"{dump.Values.SelectMany(st => st.Software).Sum(st => st.Capacity)}");
        }

        private static void GetFullInfoSystem(Dictionary<string, Hardware> dictionary)
        {
            foreach (var hardware in dictionary)
            {
                Console.WriteLine($"Hardware Component - {hardware.Key}");
                Console.WriteLine($"Express Software Components - " +
                                  $"{hardware.Value.Software.Count(st => st is ExpressSoftware)}");
                Console.WriteLine($"Light Software Components - " +
                                  $"{hardware.Value.Software.Count(st => st is LightSoftware)}");
                Console.WriteLine($"Memory Usage: {hardware.Value.Software.Sum(st => st.Memory)} / " +
                                  $"{hardware.Value.Memory}");
                Console.WriteLine($"Capacity Usage: {hardware.Value.Software.Sum(st => st.Capacity)} / " +
                                  $"{hardware.Value.Capacity}");
                Console.WriteLine($"Type: {hardware.Value.GetType().Name.Substring(0, 5)}");
                int countSoftwareComponents = hardware.Value.Software.Count();
                if (countSoftwareComponents == 0)
                {
                    Console.WriteLine("Software Components: None");
                    continue;
                }

                Console.WriteLine($"Software Components: " +
                                  $"{string.Join(", ", hardware.Value.Software.Select(st => st.Name))}");
            }
        }

        private static void ReleasedSoftwareComponentFromSystem(string[] dataSystem, Dictionary<string, Hardware> dictionary)
        {
            string toBeReleasedFrom = dataSystem[0];
            string releasedComponent = dataSystem[1];

            foreach (var source in dictionary.Where(st => st.Key == toBeReleasedFrom))
            {
                source.Value.Software.RemoveAll(st => st.Name == releasedComponent);
            }
        }

        private static bool CheckForEnoughSpace(Dictionary<string, Hardware> dictionary, string hardwareName, Software currentSoft)
        {
            int totalHardwareCapacity = dictionary[hardwareName].Capacity;
            int totalHardwareMemory = dictionary[hardwareName].Memory;
            int consumeCapacity = dictionary[hardwareName].Software.Sum(st => st.Capacity);
            int consumeMemory = dictionary[hardwareName].Software.Sum(st => st.Memory);

            bool isEnoughCapacity = totalHardwareCapacity - (consumeCapacity + currentSoft.Capacity) >= 0;
            bool isEnoughMemory = totalHardwareMemory - (consumeMemory + currentSoft.Memory) >= 0;

            if (isEnoughCapacity && isEnoughMemory)
            {
                return true;
            }

            return false;
        }

        private static void CalculateData(Dictionary<string, Hardware> dictionary,
            ref int totalOperacitonMemory, ref int totalOperacitonCapacity,
            ref int maxOperationCapacity, ref int maxOperationMemory)
        {
            totalOperacitonMemory += dictionary.Values.Select(st => st.Software)
                .SelectMany(value => value).Sum(unit => unit.Memory);

            totalOperacitonCapacity += dictionary.Values.Select(st => st.Software)
                .SelectMany(value => value).Sum(unit => unit.Capacity);

            maxOperationCapacity += dictionary.Values.Sum(st => st.Capacity);

            maxOperationMemory += dictionary.Values.Sum(st => st.Memory);
        }

        private static string CreateExpressSoftware(string[] dataSystem, out Software esSoft)
        {
            string elHName = dataSystem[0];
            string esName = dataSystem[1];
            int esCapacity = int.Parse(dataSystem[2]);
            int esMemory = int.Parse(dataSystem[3]);
            esSoft = new ExpressSoftware(esName, esCapacity, esMemory);
            return elHName;
        }

        private static string CreateLightSoftware(string[] dataSystem, out Software lsSoft)
        {
            string lsHName = dataSystem[0];
            string lsName = dataSystem[1];
            int lsCapacity = int.Parse(dataSystem[2]);
            int lsMemory = int.Parse(dataSystem[3]);
            lsSoft = new LightSoftware(lsName, lsCapacity, lsMemory);
            return lsHName;
        }

        private static string CreateHeavyHardware(string[] dataSystem, string name, out Hardware hardwaredHeavy)
        {
            string nameHHardware = dataSystem[0];
            int capacityHHardware = int.Parse(dataSystem[1]);
            int memoryHHardware = int.Parse(dataSystem[2]);
            hardwaredHeavy = new HeavyHardware(name,
                capacityHHardware, memoryHHardware, new List<Software>());

            return nameHHardware;
        }

        private static string CreatePowerHardware(string[] dataSystem, string name, out Hardware hardwaredPower)
        {
            string namePHardware = dataSystem[0];
            int capacityPHardware = int.Parse(dataSystem[1]);
            int memoryPHardware = int.Parse(dataSystem[2]);
            hardwaredPower = new PowerHardware(name,
                capacityPHardware, memoryPHardware, new List<Software>());

            return namePHardware;
        }
    }
}
