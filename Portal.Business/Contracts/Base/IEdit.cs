namespace Portal.Business.Contracts.Base
{
    public interface IEdit<T> where T : class
    {
        T Edit(T model);
    }
}