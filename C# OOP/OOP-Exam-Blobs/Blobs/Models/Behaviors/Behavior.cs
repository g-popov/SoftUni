namespace Blobs.Models.Behaviors
{
    using System;
    using Blobs.Models.Interfaces;

    public abstract class Behavior : IBehavior
    {
        public Behavior(int damageModifier, int healthModifier, int damageLossPerTurn, int healthLossPerTurn)
        {
            DamageModifier = damageModifier;
            HealthModifier = healthModifier;
            DamageLossPerTurn = damageLossPerTurn;
            HealthLossPerTurn = healthLossPerTurn;
        }

        public int DamageModifier { get; private set; }

        public int HealthModifier { get; private set; }

        public int DamageLossPerTurn { get; private set; }

        public int HealthLossPerTurn { get; private set; }
    }
}
