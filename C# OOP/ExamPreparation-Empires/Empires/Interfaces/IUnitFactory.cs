using Empires.Models.Interfaces;

namespace Empires.Interfaces
{
    public interface IUnitFactory
    {
        IUnit ProduceUnit(string unitType);
    }
}
