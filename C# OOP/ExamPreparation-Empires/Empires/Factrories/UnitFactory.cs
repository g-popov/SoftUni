namespace Empires.Factrories
{
    using System;
    using Empires.Models.Interfaces;
    using Empires.Interfaces;
    using Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit ProduceUnit(string unitType)
        {
            switch (unitType)
            {
                case "Archer":
                    return new Archer();
                case "Swordsman":
                    return new Swordsman();
                default:
                    throw new ArgumentException("Unknown unit type.");
                    
            }
        }
    }
}
