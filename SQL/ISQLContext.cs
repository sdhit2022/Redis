using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Redis.SQL
{
    public interface ISQLContext
    {
        public DatabaseFacade Database { get; }
        public DbSet<Object> Objects { get; set; }

        int SaveChanges();

    }
}
