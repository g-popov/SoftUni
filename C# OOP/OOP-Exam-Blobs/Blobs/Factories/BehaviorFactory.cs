namespace Blobs.Factories
{
    using System;
    using Blobs.Interfaces;
    using Blobs.Models.Interfaces;
    using Blobs.Models.Behaviors;

    public class BehaviorFactory : IBehaviorFactory
    {
        public IBehavior CreateBehavior(string behaviorType)
        {
            switch (behaviorType)
            {
                case "Aggressive":
                    return new AggressiveBehavior();
                case "Inflated":
                    return new InflatedBehavior();
                default:
                    throw new ArgumentException("Unknown behavior type.");
            }
        }
    }
}
