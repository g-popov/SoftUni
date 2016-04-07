namespace Blobs.Interfaces
{
    using Blobs.Models.Interfaces;

    public interface IAttackFactory
    {
        IAttack CreateAttack(string attackType);
    }
}
