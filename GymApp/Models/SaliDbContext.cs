using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Models
{
    public partial class SaliDbContext : DbContext
    {
        public SaliDbContext()
        {
        }

        public SaliDbContext(DbContextOptions<SaliDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sali> Sali { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sali>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
