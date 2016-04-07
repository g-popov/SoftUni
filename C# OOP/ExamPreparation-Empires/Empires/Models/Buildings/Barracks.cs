namespace Empires.Models.Buildings
{
    using Empires.Interfaces;

    public class Barracks : Building
    {
        private const string SwordsmanUnitType = "Swordsman";
        private const int SwordsmanProductionCycle = 4;
        private const int SteelProductionCycle = 3;
        private const int SteelQuantity = 10;

        public Barracks(IResourceFactory resourceFactory, IUnitFactory unitFactory)
            : base(SwordsmanUnitType, SwordsmanProductionCycle, ResourceType.Steel, SteelProductionCycle, SteelQuantity, resourceFactory, unitFactory)
        {
        }
    }
}
