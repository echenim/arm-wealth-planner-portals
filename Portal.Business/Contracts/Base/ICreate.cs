namespace Portal.Business.Contracts.Base
{
    public interface ICreate<T> where T : class
    {
        T Save(T model);
    }
}