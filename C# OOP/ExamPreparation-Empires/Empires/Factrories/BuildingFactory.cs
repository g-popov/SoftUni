namespace Empires.Factrories
{
    using System;
    using Empires.Interfaces;
    using Models.Interfaces;
    using Models.Buildings;

    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding CreateBuilding(string type, IResourceFactory resourceFactory, IUnitFactory unitFactory)
        {
            switch (type)
            {
                case "archery":
                    return new Archery(resourceFactory, unitFactory);
                case "barracks":
                    return new Barracks(resourceFactory, unitFactory);
                default:
                    throw new ArgumentException("Unknown building type.");
            }
        }
    }
}
