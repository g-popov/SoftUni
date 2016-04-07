namespace Empires.Core
{
    using System;
    using System.Collections.Generic;
    using Empires.Interfaces;
    using System.Linq;

    public class Command : ICommand
    {
        public Command(string commandLine)
        {
            string[] commandParts = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.Name = commandParts[0];
            if (commandParts.Length > 1)
            {
                this.Parameters = commandParts.Skip(1).ToArray();
            }

        }

        public string Name
        {
            get; private set;
        }

        public IList<string> Parameters
        {
            get; private set;
        }
    }
}
