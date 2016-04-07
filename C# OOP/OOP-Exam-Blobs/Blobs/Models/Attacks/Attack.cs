namespace Blobs.Models.Attacks
{
    using Blobs.Models.Interfaces;

    public abstract class Attack : IAttack
    {
        public Attack(int damageModifier, int healthModifier)
        {
            this.DamageModifier = damageModifier;
            this.HealthModifier = healthModifier;
        }

        public int DamageModifier { get; }

        public int HealthModifier { get; }
    }
}
