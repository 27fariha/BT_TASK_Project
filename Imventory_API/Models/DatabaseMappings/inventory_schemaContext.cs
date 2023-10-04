using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Imventory_API.Models.DatabaseMappings
{
    public partial class inventory_schemaContext : DbContext
    {
        public inventory_schemaContext()
        {
        }

        public inventory_schemaContext(DbContextOptions<inventory_schemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<U01Item> U01Items { get; set; }
        public virtual DbSet<U01Ser> U01Sers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-17JC3IF\\SQLEXPRESS;Initial Catalog=inventory_schema; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<U01Item>(entity =>
            {
                entity.ToTable("u01_items");

                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Added_on");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on");

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<U01Ser>(entity =>
            {
                entity.ToTable("u01_sers");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginTimestamp).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uuid)
                    .HasMaxLength(225)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
