namespace PortalAPI.Midleware.BaseStore.Contracts.Base
{
    public interface ICreate<T> where T : class
    {
        void Create(T entity);
    }
}