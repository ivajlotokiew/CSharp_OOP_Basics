using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using ReallySimpleEngine.Contracts;
using ReallySimpleEngine.Enums;
using ReallySimpleEngine.UI;

namespace ReallySimpleEngine.Core
{
    public class BuildingData : IBuildingData
    {
        public BuildingData()
        {
            this.Buildings = new List<IBuilding>();
        }

        public IList<IBuilding> Buildings { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            var gold = this.Buildings
                .SelectMany(t => t.Resources)
                .Where(g => g.ResourceType == ResourceType.Gold)
                .Sum(q => q.Quantity);

            var steel = this.Buildings
                .SelectMany(t => t.Resources)
                .Where(g => g.ResourceType == ResourceType.Steel)
                .Sum(q => q.Quantity);

            var countSwordsmans = this.Buildings
                .SelectMany(u => u.Units)
                .Count(t => t.GetType().Name == "Swordsman");

            var countArchers = this.Buildings
                .SelectMany(u => u.Units)
                .Count(t => t.GetType().Name == "Archer");

            output.AppendLine("Treasury:");
            output.AppendLine($"--Gold: {gold}");
            output.AppendLine($"--Steel: {steel}");
            output.AppendLine("Buildings:");

            var buildingsInfo = this.Buildings
                              .Where(b => (b.GetType().Name == "Barracks") || (b.GetType().Name == "Archery"))
                              .OrderByDescending(st => st.CountTurns)
                              .ToList();

            foreach (var building in buildingsInfo)
            {
                if (building.GetType().Name == "Archery")
                {
                    output.AppendLine($"--Archery: {building.CountTurns} turns (" +
                                      $"{building.TurnsProduceUnit} turns until Archer, " +
                                      $"{building.TurnsProduceResource} turns until Gold)");
                }
                else
                {
                    output.AppendLine($"--Barracks: {building.CountTurns} turns (" +
                                      $"{building.TurnsProduceUnit} turns until Swordsman, " +
                                      $"{building.TurnsProduceResource} turns until Steel)");
                }
            }

            output.AppendLine("Units:");

            if (countArchers == 0 && countSwordsmans == 0)
            {
                output.Append("N/A");
            }
            else if (countArchers == 0 && countSwordsmans > 0)
            {
                output.Append($"--Swordsman: {countSwordsmans}");
            }
            else if (countArchers > 0 && countSwordsmans == 0)
            {
                output.Append($"--Archer: {countArchers}");
            }
            else
            {
                bool isArcherBuildingIsFirstCreated =
                                     this.Buildings
                                    .Where(b => b.GetType()
                                    .Name == "Archery")
                                    .OrderByDescending(x => x.CountTurns)
                                    .ToList()[0].CountTurns >
                                    this.Buildings
                                    .Where(b => b.GetType().Name == "Barracks")
                                    .OrderByDescending(x => x.CountTurns)
                                    .ToList()[0].CountTurns;

                if (isArcherBuildingIsFirstCreated)
                {
                    output.AppendLine($"--Archer: {countArchers}");
                    output.Append($"--Swordsman: {countSwordsmans}");
                }
                else
                {
                    output.AppendLine($"--Swordsman: {countSwordsmans}");
                    output.Append($"--Archer: {countArchers}");
                }
            }

            return output.ToString();
        }
    }
}