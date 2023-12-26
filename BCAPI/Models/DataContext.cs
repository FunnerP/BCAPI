using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BCAPI.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Brigade> Brigades { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=BCDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brigade>(entity =>
        {
            entity.HasKey(e => e.IdBrigade).HasName("PK__Brigade__9F275447066CD991");

            entity.ToTable("Brigade");

            entity.Property(e => e.BrigadeName).HasMaxLength(255);
            entity.Property(e => e.BrigadeSpec).HasMaxLength(255);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Client__C1961B33E5E555DC");

            entity.ToTable("Client");

            entity.Property(e => e.Adress).HasMaxLength(255);
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.Number).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Order__C38F30090339E1A5");

            entity.ToTable("Order");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.IdBrigadeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdBrigade)
                .HasConstraintName("FK_Order_Brigade");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK__Order__IdClient__2A4B4B5E");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.IdWorker).HasName("PK__Workers__18714E8A03A090B9");

            entity.Property(e => e.Adress).HasMaxLength(255);
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.Number).HasMaxLength(255);
            entity.Property(e => e.Post).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(255);

            entity.HasOne(d => d.IdBrigadeNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.IdBrigade)
                .HasConstraintName("FK__Workers__IdBriga__2B3F6F97");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
