namespace AzureStorage.Core.Contracts
{
    public interface IHandle<T> where T : class
    {
        object Handle(T command);
    }
}
