using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RRDL.Entities
{
    public partial class RRDatabaseContext : DbContext
    {
        public RRDatabaseContext()
        {
        }

        public RRDatabaseContext(DbContextOptions<RRDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.RestId)
                    .HasName("PK__Restaura__9A2078C0B7A55AA5");

                entity.ToTable("Restaurant");

                entity.Property(e => e.RestId).HasColumnName("rest_id");

                entity.Property(e => e.RestCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rest_city");

                entity.Property(e => e.RestName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rest_name");

                entity.Property(e => e.RestState)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rest_state");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.RevId)
                    .HasName("PK__Review__397465D62DF3E169");

                entity.ToTable("Review");

                entity.Property(e => e.RevId).HasColumnName("rev_id");

                entity.Property(e => e.RestId).HasColumnName("rest_id");

                entity.Property(e => e.RevRating).HasColumnName("rev_rating");

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.RestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__rest_id__01142BA1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
