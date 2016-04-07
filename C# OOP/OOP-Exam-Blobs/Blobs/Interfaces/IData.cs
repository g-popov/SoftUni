namespace Blobs.Interfaces
{
    using System.Collections.Generic;
    using Blobs.Models.Interfaces;

    public interface IData
    {
        ICollection<IBlob> Blobs { get; }

        void AddBlob(IBlob blob);
    }
}
