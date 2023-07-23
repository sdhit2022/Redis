using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataBase_Test.SQL
{
    public interface ISQLContext
    {
        public DatabaseFacade Database { get; }
        public  DbSet<Object> Objects { get; set; }

        int SaveChanges();
        
    }
}
