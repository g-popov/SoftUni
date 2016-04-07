namespace Blobs.Models.Attacks
{
    public class PutridFart : Attack
    {
        private const int PutridDamageModifier = 1;
        private const int PutridHealthModifier = 1;

        public PutridFart()
            : base(PutridDamageModifier, PutridHealthModifier)
        {
        }
    }
}
