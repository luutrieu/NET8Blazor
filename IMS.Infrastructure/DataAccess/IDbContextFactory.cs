using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.DataAccess
{
    public interface IDbContextFactory<T> where T : DbContext
    {
        T CreateDbContext();
    }
}
