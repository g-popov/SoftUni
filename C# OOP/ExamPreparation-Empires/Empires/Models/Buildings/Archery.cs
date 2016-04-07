namespace Empires.Models.Buildings
{
    using Empires.Interfaces;

    public class Archery : Building
    {
        private const string ArcherUnitType = "Archer";
        private const int ArcherProductionCycle = 3;
        private const int GoldProductionCycle = 2;
        private const int GoldQuantity = 5;

        public Archery(IResourceFactory resourceFactory, IUnitFactory unitFactory) 
            : base(ArcherUnitType, ArcherProductionCycle, ResourceType.Gold, GoldProductionCycle, GoldQuantity, resourceFactory, unitFactory)
        {
        }
    }
}
