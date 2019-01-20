namespace PortalAPI.Midleware.Contracts.Base
{
    public interface ICreate<T> where T : class
    {
        T Save(T model);
    }
}