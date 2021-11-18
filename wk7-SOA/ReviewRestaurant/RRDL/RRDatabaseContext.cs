using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RRModels;

#nullable disable

namespace RRDL
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

                entity.HasKey(e => e.Id)
                    .HasName("PK__Restaura__9A2078C0B7A55AA5");

                entity.ToTable("Restaurant");

                entity.Property(e => e.Id).HasColumnName("rest_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rest_city");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rest_name");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rest_state");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Review__397465D62DF3E169");

                entity.ToTable("Review");

                entity.Property(e => e.Id).HasColumnName("rev_id");

                entity.Property(e => e.RestId).HasColumnName("rest_id");

                entity.Property(e => e.Rating).HasColumnName("rev_rating");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.RestId)
                    .OnDelete(DeleteBehavior.Cascade) //Find the relationship on the dbcontext and set it to DeleteBehavior.Cascade
                    .HasConstraintName("FK__Review__rest_id__01142BA1");
            }); 

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
