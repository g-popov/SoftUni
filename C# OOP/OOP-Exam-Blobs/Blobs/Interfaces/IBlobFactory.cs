namespace Blobs.Interfaces
{
    using Blobs.Models.Interfaces;

    public interface IBlobFactory
    {
        IBlob CreateBlob(string name, int health, int damage, IBehavior behavior, IAttack attackType);
    }
}
