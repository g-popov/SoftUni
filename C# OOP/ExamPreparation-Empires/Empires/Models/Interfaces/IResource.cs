namespace Empires.Models.Interfaces
{
    public interface IResource
    {
        ResourceType Type { get; }

        int Quantity { get; }
    }
}