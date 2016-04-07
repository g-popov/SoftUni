namespace Blobs
{
    using IO;
    using Core;
    using Factories;

    public class BlobsApplication
    {
        public static void Main()
        {
            var userConsole = new UserConsole();
            var blobsData = new BlobsData();
            var blobFactory = new BlobFactory();
            var behaviorFactory = new BehaviorFactory();
            var attackFactory = new AttackFactory();
            var commandDispatcher = new BlobsDispatcher(blobsData, blobFactory, behaviorFactory, attackFactory, userConsole);
            var engine = new BlobsEngine(userConsole, commandDispatcher, blobsData);

            engine.Run();
        }
    }
}
