using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Redis.PostgreSQL
{
    public interface IPostgresContext
    {
        public DatabaseFacade Database { get; }
        public DbSet<Pobject> Pobjects { get; set; }

        int SaveChanges();
    }
}
