using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data;

public partial class SuperHeroDbContext : DbContext
{
    public SuperHeroDbContext()
    {
    }

    public SuperHeroDbContext(DbContextOptions<SuperHeroDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExampleTable> ExampleTables { get; set; }

    public virtual DbSet<SuperHero> SuperHeroes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:superherosqlserver.database.windows.net,1433;Initial Catalog=SuperHeroDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExampleTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__example___3213E83FC19CACF9");

            entity.ToTable("example_table");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SuperHero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SuperHer__3214EC07E20B7648");

            entity.ToTable("SuperHero");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
