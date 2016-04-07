namespace Empires.Interfaces
{
    using Empires.Models;
    using Empires.Models.Interfaces;

    public interface IResourceFactory
    {
        IResource ProduceResource(int quantity, ResourceType type);
    }
}
