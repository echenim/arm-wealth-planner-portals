namespace PortalAPI.Midleware.BaseStore.Contracts.Base
{
    public interface IEdit<T> where T : class
    {
        void Update(T entity);
    }
}