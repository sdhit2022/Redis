using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBase_Test.PostgreSQL;

public partial class PostgresTestDbContext : DbContext,IPostgresTestDbContext
{
    public PostgresTestDbContext()
    {
    }

    public PostgresTestDbContext(DbContextOptions<PostgresTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pobject> Pobjects { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseNpgsql("Host=localhost; Database=TestDB; Username=postgres; Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pobject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Object_pkey");

            entity.ToTable("PObject");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
