using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBase_Test.SQL;

public partial class SQLContext : DbContext,ISQLContext
{
    private readonly IHttpContextAccessor _httpContext;

 
    public SQLContext()
    {
    }

    public SQLContext(DbContextOptions<SQLContext> options, IHttpContextAccessor httpContext)
        : base(options)
    {
        _httpContext = httpContext;
    }

    public virtual DbSet<Object> Objects { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("name=SqlServerConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Object>(entity =>
        {
            entity.ToTable("Object");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Decimal).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.String).HasMaxLength(300);
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
