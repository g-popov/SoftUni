namespace Empires.Models.Interfaces
{
    public interface IBuilding
    {
        // bool CanProduceUnit();

        // bool CanProduceResource();

        int TurnsPassed { get; set; }

        IUnit ProduceUnit();

        IResource ProduceResource();

        //void Update();
    }
}
