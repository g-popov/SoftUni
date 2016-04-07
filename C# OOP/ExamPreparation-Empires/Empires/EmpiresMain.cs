namespace Empires
{
    using Core;
    using Factrories;
    using IO;

    public class EmpiresMain
    {
        public static void Main()
        {
            var userInterface = new UserConsole();
            var data = new EmpiresData();
            var buildingFactory = new BuildingFactory();
            var resourceFactory = new ResourceFactory();
            var unitFactory = new UnitFactory();
            var dispatcher = new EmpiresDispatcher(userInterface, buildingFactory, resourceFactory, unitFactory, data);
            var engine = new EmpiresEngine(userInterface, data, dispatcher);

            engine.Run();
        }
    }
}
