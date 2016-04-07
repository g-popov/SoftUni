namespace Empires.Factrories
{
    using Empires.Interfaces;
    using Models;
    using Models.Interfaces;

    public class ResourceFactory : IResourceFactory
    {
        public IResource ProduceResource(int quantity, ResourceType type)
        {
            return new Resource(quantity, type);
        }
    }
}
