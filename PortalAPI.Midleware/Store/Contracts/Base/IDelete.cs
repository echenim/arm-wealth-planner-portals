namespace PortalAPI.Midleware.Store.Contracts.Base
{
   public  interface IDelete<T> where T:class
    {
        void Delete(T entity);
    }
}
