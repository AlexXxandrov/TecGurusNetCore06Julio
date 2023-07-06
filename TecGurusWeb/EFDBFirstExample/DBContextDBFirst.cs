using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TecGurusWeb.EFDBFirstExample;

public partial class DBContextDBFirst : DbContext
{
    public DBContextDBFirst()
    {
    }

    public DBContextDBFirst(DbContextOptions<DBContextDBFirst> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-6FFTOKJ\\RUBEM;Database=DBFirst;Encrypt=False;Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Car");

            entity.ToTable("Animal");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(250);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.CreatedBy).HasMaxLength(500);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.CreatedBy).HasMaxLength(500);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Students_Students");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
