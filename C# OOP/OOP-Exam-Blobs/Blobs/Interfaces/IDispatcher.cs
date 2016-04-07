namespace Blobs.Interfaces
{
    public interface IDispatcher
    {
        void DispatchCommand(ICommand command);
    }
}
