using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataBase_Test.MySQL
{
    public interface ITestDbContext
    {
        public DatabaseFacade Database { get; }
        public DbSet<Object> Objects { get; set; }

        int SaveChanges();
    }
}
