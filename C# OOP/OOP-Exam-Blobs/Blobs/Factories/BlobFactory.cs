
namespace Blobs.Factories
{
    using Blobs.Interfaces;
    using Models.Interfaces;
    using Models;

    public class BlobFactory : IBlobFactory
    {
        public IBlob CreateBlob(string name, int health, int damage, IBehavior behavior, IAttack attackType)
        {
            return new Blob(name, health, damage, behavior, attackType);
        }
    }
}
