namespace Blobs.Models.Behaviors
{
    public class InflatedBehavior : Behavior
    {
        private const int InflatedDamageModifier = 1;
        private const int InflatedHealthModifier = 50;
        private const int InflatedDamageLossPerTurn = 0;
        private const int InflatedHealthLossPerTurn = 10;

        public InflatedBehavior() : 
            base(InflatedDamageModifier, InflatedHealthModifier, InflatedDamageLossPerTurn, InflatedHealthLossPerTurn)
        {
        }
    }
}
