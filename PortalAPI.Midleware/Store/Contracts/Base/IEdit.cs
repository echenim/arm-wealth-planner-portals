namespace PortalAPI.Midleware.Store.Contracts.Base
{
    public interface IEdit<T> where T:class
    {
        void Update(T entity);
    }
}
