namespace Empires.Interfaces
{
    public interface IDispatcher
    {
        void ExecuteCommand(ICommand command);
    }
}
