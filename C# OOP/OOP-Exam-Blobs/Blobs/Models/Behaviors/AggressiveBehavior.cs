namespace Blobs.Models.Behaviors
{
    public class AggressiveBehavior : Behavior
    {
        private const int AggressiveDamageModifier = 2;
        private const int AggressiveHealthModifier = 0;
        private const int AggressiveDamageLossPerTurn = 5;
        private const int AggressiveHealthLossPerTurn = 0;

        public AggressiveBehavior() : 
            base(AggressiveDamageModifier, AggressiveHealthModifier, AggressiveDamageLossPerTurn, AggressiveHealthLossPerTurn)
        {
        }
    }
}
