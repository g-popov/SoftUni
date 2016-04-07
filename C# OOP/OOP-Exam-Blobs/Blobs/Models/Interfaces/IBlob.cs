namespace Blobs.Models.Interfaces
{
    public interface IBlob : IAttacker
    {
        string Name { get; }

        int Health { get; }

        int Damage { get; }

        IBehavior Behavior { get; }

        IAttack AttackType { get; }

        //void TriggerBehavior();

        void DropHealth(int damage);

        void Update();
    }
}