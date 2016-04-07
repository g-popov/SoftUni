namespace Empires.Core
{
    using System;
    using System.Collections.Generic;
    using Empires.Interfaces;
    using Empires.Models;
    using Empires.Models.Interfaces;

    public class EmpiresData : IData
    {
        public EmpiresData()
        {
            this.Buildings = new List<IBuilding>();
            this.Treasury = new Dictionary<ResourceType, int>();
            this.Units = new Dictionary<string, int>();
            this.InitializeResources();
        }

        public ICollection<IBuilding> Buildings { get; private set; }

        public IDictionary<ResourceType, int> Treasury { get; private set; }

        public IDictionary<string, int> Units { get; private set; }

        public void AddBuilding(IBuilding building)
        {
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            this.Buildings.Add(building);
        }

        public void AddUnit(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            string unitTypeName = unit.GetType().Name;
            if (!this.Units.ContainsKey(unitTypeName))
            {
                this.Units[unitTypeName] = 0;
            }
            this.Units[unitTypeName]++;
        }

        private void InitializeResources()
        {
            var resourceTypes = Enum.GetValues(typeof(ResourceType));
            foreach (ResourceType type in resourceTypes)
            {
                this.Treasury.Add(type, 0);
            }
        }
    }
}
