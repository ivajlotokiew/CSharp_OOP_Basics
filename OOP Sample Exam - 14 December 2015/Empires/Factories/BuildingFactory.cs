using System;
using System.Text;
using ReallySimpleEngine.Contracts;
using ReallySimpleEngine.Models.Building;

namespace ReallySimpleEngine.Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding CreateBuilding(string typeBuilding)
        {
            switch (typeBuilding)
            {
                case "archery":
                    return new Archery();
                case "barracks":
                    return new Barracks();
                default:
                    throw new ArgumentException("Unknown type building");
            }
        }
    }
}