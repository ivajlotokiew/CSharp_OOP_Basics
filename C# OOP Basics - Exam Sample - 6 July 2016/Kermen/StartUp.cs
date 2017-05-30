using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Keren.Models;

namespace Keren
{
    public class StartUp
    {
        public static decimal totalPopulation;

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var houseHolders = new List<HouseHold>();
            Regex regex = new Regex(@"([\w]+)\(([^\)]+)\)");

            string input = Console.ReadLine();
            int counter = 0;

            while (input != "Democracy")
            {
                counter++;
                if (regex.IsMatch(input))

                {
                    MatchCollection matches = regex.Matches(input);

                    string houseHolder = matches[0].Groups[1].Value;

                    switch (houseHolder)
                    {
                        case "YoungCouple":
                            decimal salaryOne = decimal.Parse(matches[0].Groups[2].Value.Split(' ')[0]);
                            decimal salaryTwo = decimal.Parse(matches[0].Groups[2].Value.Split(' ')[1]);
                            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                            decimal lapTopCost = decimal.Parse(matches[3].Groups[2].Value);
                            HouseHold youngCouple = new YoungCouple(salaryOne, salaryTwo,
                                tvCost, fridgeCost, lapTopCost);

                            houseHolders.Add(youngCouple);

                            break;
                        case "YoungCoupleWithChildren":
                            decimal cSalaryOne = decimal.Parse(matches[0].Groups[2].Value.Split(' ', ',')[0]);
                            decimal cSalaryTwo = decimal.Parse(matches[0].Groups[2].Value.Split(' ', ' ')[1]);
                            decimal cTvCost = decimal.Parse(matches[1].Groups[2].Value);
                            decimal cFridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                            decimal cLapTopCost = decimal.Parse(matches[3].Groups[2].Value);

                            var childs = new List<Child>();
                            for (int i = 4; i < matches.Count; i++)
                            {
                                List<decimal> childCost = matches[i].Groups[2].Value
                                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(decimal.Parse).ToList();

                                Child child = new Child(childCost);
                                childs.Add(child);
                            }

                            HouseHold coupleWithChildren = new YoungCoupleWithChildren(cSalaryOne, cSalaryTwo,
                                cTvCost, cFridgeCost, cLapTopCost, childs);

                            houseHolders.Add(coupleWithChildren);

                            break;
                        case "OldCouple":
                            decimal oSalaryOne = decimal.Parse(matches[0].Groups[2].Value.Split(' ', ',')[0]);
                            decimal oSalaryTwo = decimal.Parse(matches[0].Groups[2].Value.Split(' ', ',')[1]);
                            decimal oTvCost = decimal.Parse(matches[1].Groups[2].Value);
                            decimal oFridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                            decimal stoveCost = decimal.Parse(matches[3].Groups[2].Value);
                            HouseHold oldCouple = new OldCouple(oSalaryOne, oSalaryTwo, oTvCost, oFridgeCost, stoveCost);
                            houseHolders.Add(oldCouple);
                            break;
                        case "AloneOld":
                            decimal aoSalary = decimal.Parse(matches[0].Groups[2].Value);
                            AloneOldPerson oldPerson = new AloneOldPerson(aoSalary);
                            houseHolders.Add(oldPerson);
                            break;
                        case "AloneYoung":
                            decimal aySalary = decimal.Parse(matches[0].Groups[2].Value);
                            decimal ayLaptopCost = decimal.Parse(matches[1].Groups[2].Value);
                            AloneYoungPerson aloneYoung = new AloneYoungPerson(aySalary, ayLaptopCost);
                            houseHolders.Add(aloneYoung);
                            break;
                        default:
                            throw new ArgumentException();
                    }

                    if (counter % 3 == 0)
                    {
                        foreach (var houseHold in houseHolders)
                        {
                            houseHold.GetSalary();
                        }
                    }
                }
                else if (input == "EVN")
                {
                    if (counter % 3 == 0)
                    {
                        foreach (var houseHold in houseHolders)
                        {
                            houseHold.GetSalary();
                        }
                    }

                    var totalConsumation = houseHolders.Select(st => st.Consumption).Sum();

                    Console.WriteLine($"Total consumption: {totalConsumation}");
                }
                else
                {
                    if (counter % 3 == 0)
                    {
                        foreach (var houseHold in houseHolders)
                        {
                            houseHold.GetSalary();
                        }
                    }

                    List<HouseHold> redundant = new List<HouseHold>();
                    foreach (var houseHolder in houseHolders)
                    {
                        if (houseHolder.IsMonyeEnough())
                        {
                            houseHolder.PayBills();
                        }
                        else
                        {
                            redundant.Add(houseHolder);
                        }
                    }

                    if (redundant.Count > 0)
                    {
                        foreach (var houseHold in redundant)
                        {
                            houseHolders.Remove(houseHold);
                        }
                    }

                    totalPopulation = houseHolders.Select(st => st.Population).Sum();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total population: {totalPopulation}");
        }
    }
}