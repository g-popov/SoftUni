namespace Empires.Models
{
    using System;
    using Empires.Models.Interfaces;

    public class Resource : IResource
    {
        public Resource(int quantity, ResourceType type)
        {
            this.Quantity = quantity;
            this.Type = type;
        }

        public int Quantity
        {
            get; private set;
        }

        public ResourceType Type
        {
            get; private set;
        }
    }
}
