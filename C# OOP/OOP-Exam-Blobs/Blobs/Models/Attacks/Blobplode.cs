namespace Blobs.Models.Attacks
{
    public class Blobplode : Attack
    {
        private const int BlobplodeDamageModifier = 2;
        private const int BlobplodeHealthModifier = 2;

        public Blobplode()
            : base(BlobplodeDamageModifier, BlobplodeHealthModifier)
        {
        }
    }
}
