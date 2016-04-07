namespace Blobs.Core
{
    using System;
    using System.Collections.Generic;
    using Blobs.Interfaces;
    using Blobs.Models.Interfaces;

    public class BlobsData : IData
    {
        public BlobsData()
        {
            this.Blobs = new List<IBlob>();
        }

        public ICollection<IBlob> Blobs { get; private set; }

        public void AddBlob(IBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            this.Blobs.Add(blob);
        }
    }
}
