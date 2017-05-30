using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReallySimpleEngine.Contracts;
using ReallySimpleEngine.Enums;
using ReallySimpleEngine.Factories;

namespace ReallySimpleEngine.Models.Building
{
    public abstract class Building : IBuilding
    {

        private readonly int defaultTurnsProduceUnit;
        private readonly int defaultTurnsProduceResource;
        private readonly string typeBuilding;
        private bool HasBuildingAlreadyCreated;

        protected Building(int defaultTurnsProduceUnit, int defaultTurnsProduceResource, string typeBuilding)
        {
            this.Units = new List<IUnit>();
            this.Resources = new List<IResource>();
            this.ResourceFactory = new ResourceFactory();
            this.UnitFactory = new UnitFactory();
            this.defaultTurnsProduceUnit = defaultTurnsProduceUnit;
            this.defaultTurnsProduceResource = defaultTurnsProduceResource;
            this.typeBuilding = typeBuilding;
            this.HasBuildingAlreadyCreated = false;
        }

        public int TurnsProduceUnit { get; set; }

        public int TurnsProduceResource { get; set; }

        protected IUnitFactory UnitFactory { get; set; }

        protected IResourceFactory ResourceFactory { get; set; }

        public List<IUnit> Units { get; }

        public List<IResource> Resources { get; }

        public int CountTurns { get; set; } = 0;

        public void ProduceUnit(string typeBuilding)
        {
            var unit = this.UnitFactory.CreateUnit(typeBuilding);

            this.Units.Add(unit);
        }

        public void ProduceRecource(string typeBuilding)
        {
            var resource = this.ResourceFactory.CreateResource(typeBuilding);

            this.Resources.Add(resource);
        }

        public void UpdateData()
        {
            if (this.HasBuildingAlreadyCreated)
            {
                this.TurnsProduceUnit--;
                this.TurnsProduceResource--;

                if (this.TurnsProduceUnit == 0)
                {
                    this.TurnsProduceUnit = this.defaultTurnsProduceUnit;
                    this.ProduceUnit(this.typeBuilding);
                }

                if (this.TurnsProduceResource == 0)
                {
                    this.TurnsProduceResource = this.defaultTurnsProduceResource;
                    this.ProduceRecource(this.typeBuilding);
                }

                this.CountTurns++;
            }

            this.HasBuildingAlreadyCreated = true;
        }
    }
}