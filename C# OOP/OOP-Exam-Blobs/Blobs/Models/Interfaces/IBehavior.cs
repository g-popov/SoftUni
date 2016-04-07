namespace Blobs.Models.Interfaces
{
    public interface IBehavior
    {
        int DamageModifier { get; }

        int HealthModifier { get;  }

        int DamageLossPerTurn { get; }

        int HealthLossPerTurn { get; }
    }
}
