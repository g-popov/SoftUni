namespace Empires.Interfaces
{
    using Empires.Models.Interfaces;

    public interface IBuildingFactory
    {
        IBuilding CreateBuilding(string type, IResourceFactory resourceFactory, IUnitFactory unitFactory);
    }
}
