namespace Blobs.Interfaces
{
    using Blobs.Models.Interfaces;

    public interface IBehaviorFactory
    {
        IBehavior CreateBehavior(string behaviorType);
    }
}
