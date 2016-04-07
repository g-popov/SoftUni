namespace Blobs.Factories
{
    using System;
    using Blobs.Interfaces;
    using Blobs.Models.Interfaces;
    using Models.Attacks;

    public class AttackFactory : IAttackFactory
    {
        public IAttack CreateAttack(string attackType)
        {
            switch (attackType)
            {
                case "PutridFart":
                    return new PutridFart();
                case "Blobplode":
                    return new Blobplode();
                default:
                    throw new ArgumentException("Unknown attack type.");
            }
        }
    }
}
