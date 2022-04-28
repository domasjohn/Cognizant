using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// CognizantContext.cs and Warehouse.cs files were created automatically 
// by pasting this code into the Package Manager Console
//
// Scaffold-DbContext "Data Source=localhost\sqlexpress;Initial Catalog=Cognizant;Integrated Security=True"
// Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

namespace Cognizant.Models
{
    public partial class CognizantContext : DbContext
    {
        public CognizantContext()
        {
        }

        public CognizantContext(DbContextOptions<CognizantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost\\sqlexpress;Initial Catalog=Cognizant;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Warehouse");

                entity.Property(e => e.DateAdded)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Date_Added");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Licensed)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Make)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.YearModel)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Year_Model");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
