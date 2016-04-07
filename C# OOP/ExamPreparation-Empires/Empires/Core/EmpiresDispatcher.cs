namespace Empires.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Empires.Interfaces;
    using Models;

    public class EmpiresDispatcher : IDispatcher
    {
        private IData data;
        private IBuildingFactory buildingFactory;
        private IResourceFactory resourceFactory;
        private IUnitFactory unitFactory;
        private IUserInterface userInterface;

        public EmpiresDispatcher(
            IUserInterface userInterface, 
            IBuildingFactory buildingFactory, 
            IResourceFactory resourceFactory,
            IUnitFactory unitFactory,
            IData data)
        {
            this.data = data;
            this.buildingFactory = buildingFactory;
            this.resourceFactory = resourceFactory;
            this.unitFactory = unitFactory;
            this.userInterface = userInterface;
        }

        public void ExecuteCommand(ICommand command)
        {
            switch (command.Name)
            {
                case "skip":
                    break;
                case "build":
                    this.ExecuteBuildCommand(command.Parameters);
                    break;
                case "empire-status":
                    this.ExecuteShowStatusCommand();
                    break;
                default:
                    throw new ArgumentException("Unknown command!");
            }
        }

        private void ExecuteShowStatusCommand()
        {
            StringBuilder output = new StringBuilder();

            this.AddTreasuryInfo(output);
            this.AddBuildingsInfo(output);
            this.AddUnitsInfo(output);

            this.userInterface.WriteLine(output.ToString().Trim());
        }

        private void AddUnitsInfo(StringBuilder output)
        {
            output.AppendLine("Units:");
            if (this.data.Units.Keys.Count < 1)
            {
                output.AppendLine("N/A");
            }
            else
            {
                foreach (var unit in this.data.Units)
                {
                    output.AppendLine($"--{unit.Key}: {unit.Value}");
                }
            }
        }

        private void AddBuildingsInfo(StringBuilder output)
        {
            output.AppendLine("Buildings:");
            if (this.data.Buildings.Count < 1)
            {
                output.AppendLine("N/A");
            }
            else
            {
                foreach (var building in this.data.Buildings)
                {
                    output.AppendLine(building.ToString());
                }
            }
        }

        private void AddTreasuryInfo(StringBuilder output)
        {
            output.AppendLine("Treasury:");
            foreach (var resource in this.data.Treasury)
            {
                output.AppendLine($"--{resource.Key}: {resource.Value}");
            }
        }

        private void ExecuteBuildCommand(IList<string> parameters)
        {
            string buildingType = parameters[0];
            var building = buildingFactory.CreateBuilding(buildingType, this.resourceFactory, this.unitFactory);
            this.data.AddBuilding(building);
        }
    }
}
