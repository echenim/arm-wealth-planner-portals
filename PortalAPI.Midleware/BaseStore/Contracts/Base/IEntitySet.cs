using Microsoft.EntityFrameworkCore;

namespace PortalAPI.Midleware.BaseStore.Contracts.Base
{
    public interface IEntitySet<T> where T : class
    {
        DbSet<T> DbEntitySet
        {
            get;
            set;
        }
    }
}