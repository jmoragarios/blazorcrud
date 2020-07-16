using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebServiceBlazorCrud.Models
{
    public partial class blazorcrudContext : DbContext
    {
        public blazorcrudContext()
        {
        }

        public blazorcrudContext(DbContextOptions<blazorcrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cattle> Cattle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=JMORAGARIOS-ASU\\JMORAGARIOS;Database=blazorcrud; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cattle>(entity =>
            {
                entity.ToTable("cattle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Breed)
                    .HasColumnName("breed")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
