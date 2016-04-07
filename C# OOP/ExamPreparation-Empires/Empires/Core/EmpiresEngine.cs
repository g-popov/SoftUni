namespace Empires.Core
{
    using System;
    using Empires.Interfaces;
    using IO;
    using Models.Interfaces;

    public class EmpiresEngine : IEngine
    {
        private IDispatcher dispatcher;
        private IUserInterface userInterface;
        private IData data;

        public EmpiresEngine(IUserInterface userInterface, IData data, IDispatcher dispatcher)
        {
            this.userInterface = userInterface;
            this.data = data;
            this.dispatcher = dispatcher;
        }

        public void Run()
        {
            while (true)
            {
                var line = userInterface.ReadLine();
                if (line == "armistice")
                {
                    break;
                }

                var command = new Command(line);
                this.dispatcher.ExecuteCommand(command);

                this.UpdateBuildings();
            }
        }

        private void UpdateBuildings()
        {
           
            foreach (IBuilding building in this.data.Buildings)
            {
                building.TurnsPassed++;
                var unit = building.ProduceUnit();
                if (unit != null)
                {
                    this.data.AddUnit(unit);
                }
                var resource = building.ProduceResource();
                if (resource != null)
                {
                    this.data.Treasury[resource.Type] += resource.Quantity;
                }
            }
        }

         
    }
}
