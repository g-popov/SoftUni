namespace Blobs.Core
{
    using System;
    using Blobs.Interfaces;

    public class BlobsEngine : IEngine
    {
        private IReader reader;
        private IDispatcher dispatcher;
        private IData data;

        public BlobsEngine(IReader reader, IDispatcher dispatcher, IData data)
        {
            this.reader = reader;
            this.dispatcher = dispatcher;
            this.data = data;
        }

        public void Run()
        {
            while (true)
            {
                var line = reader.ReadLine();
                if (line == "drop")
                {
                    break;
                }
                
                var command = new Command(line);
                this.dispatcher.DispatchCommand(command);
                this.UpdateBlobs();

            }
        }

        private void UpdateBlobs()
        {
            foreach (var blob in this.data.Blobs)
            {
                blob.Update();
            }
        }
    }
}
