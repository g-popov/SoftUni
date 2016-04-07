using System;
using Empires.Models.Interfaces;
using Empires.Models.Units;
using Empires.Interfaces;
using Empires.Factrories;

namespace Empires.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        // private int turnsPassed;
        private string unitType;
        private int unitProductionCycle;
        private ResourceType resourceType;
        private int resourceProductionCycle;
        private int resorceQuantity;

        private IUnitFactory unitFactory;
        private IResourceFactory resourceFactory;

        public Building(
            string unitType, 
            int unitProductionCycle, 
            ResourceType resourceType, 
            int resourceProductionCycle, 
            int resorceQuantity,
            IResourceFactory resourceFactory,
            IUnitFactory unitFactory)
        {
            this.TurnsPassed = -1;
            this.unitType = unitType;
            this.unitProductionCycle = unitProductionCycle;
            this.resourceType = resourceType;
            this.resourceProductionCycle = resourceProductionCycle;
            this.resorceQuantity = resorceQuantity;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
        }

        public int TurnsPassed { get; set; }
        
        public IResource ProduceResource()
        {
            if (!this.CanProduceResource())
            {
                return null;
            }
            var resource = this.resourceFactory.ProduceResource(this.resorceQuantity, this.resourceType);
            return resource;
        }

        public IUnit ProduceUnit()
        {
            if (!this.CanProduceUnit())
            {
                return null;
            }
            var unit = unitFactory.ProduceUnit(this.unitType);
            return unit;
        }

        private bool CanProduceResource()
        {
            if (this.TurnsPassed == 0)
            {
                return false;
            }
            bool result = this.TurnsPassed % this.resourceProductionCycle == 0;
            return result;
        }

        private bool CanProduceUnit()
        {
            if (this.TurnsPassed == 0)
            {
                return false;
            }
            bool result = this.TurnsPassed % this.unitProductionCycle == 0;
            return result;
        }

        private int turnsToResource
        {
            get
            {
                return this.resourceProductionCycle -  this.TurnsPassed % this.resourceProductionCycle;
            }
        }

        private int turnsToUnit
        {
            get
            {
                return this.unitProductionCycle - this.TurnsPassed % this.unitProductionCycle;
            }
        }

        public override string ToString()
        {
            string output = string.Format($"--{this.GetType().Name}: {this.TurnsPassed} turns ({this.turnsToUnit} turns until {this.unitType}, {this.turnsToResource} turns until {this.resourceType})");
            return output;
        }
    }
}
