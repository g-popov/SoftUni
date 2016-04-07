namespace Empires.Interfaces
{
    using System.Collections.Generic;
    using Empires.Models;
    using Empires.Models.Interfaces;

    public interface IData
    {
        IDictionary<ResourceType, int> Treasury { get; }

        ICollection<IBuilding> Buildings { get; }

        IDictionary<string, int> Units { get; }

        void AddBuilding(IBuilding building);

        void AddUnit(IUnit unit);
    }
}
