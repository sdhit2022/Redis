using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataBase_Test.PostgreSQL
{
    public interface IPostgresTestDbContext
    {
        public DatabaseFacade Database { get; }
        public DbSet<Pobject> Pobjects { get; set; }

        int SaveChanges();
    }
}
