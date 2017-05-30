using System;
using ReallySimpleEngine.Contracts;
using ReallySimpleEngine.Models.Unit;

namespace ReallySimpleEngine.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string sourceBuilding)
        {
            switch (sourceBuilding)
            {
                case "archery":
                    var archer = new Archer();
                    return archer;
                case "barracks":
                    var swordsman = new Swordsman();
                    return swordsman;
                default:
                    throw new ArgumentException("Unkonwn type buildin");
            }
        }
    }
}