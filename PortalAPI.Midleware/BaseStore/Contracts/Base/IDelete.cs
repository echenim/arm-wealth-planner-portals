namespace PortalAPI.Midleware.BaseStore.Contracts.Base
{
    public interface IDelete<T> where T : class
    {
        void Delete(T entity);
    }
}