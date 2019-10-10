using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InfoClient.DM.Database
{
    public partial class _10PearlBDClientContext : DbContext
    {
        public _10PearlBDClientContext()
        {
        }

        public _10PearlBDClientContext(DbContextOptions<_10PearlBDClientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<SaleRepresentative> SaleRepresentative { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity)
                    .HasName("PK__City__394B023A676F1C57");

                entity.Property(e => e.Comment)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__Client__C1961B33D98EEEB4");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
                
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK__Country__F99F104DDF7D48F0");

                entity.Property(e => e.Comment)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SaleRepresentative>(entity =>
            {
                entity.HasKey(e => e.IdSrepresentative)
                    .HasName("PK__SaleRepr__4DEC00CE94C5A7E7");

                entity.Property(e => e.IdSrepresentative).HasColumnName("IdSRepresentative");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.IdState)
                    .HasName("PK__State__2E1972BC86AEB602");

                entity.Property(e => e.Comment)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
                
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasKey(e => e.IdVisit)
                    .HasName("PK__Visit__58A5F8D2ECC7B9FC");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IdSrepresentative).HasColumnName("IdSRepresentative");

                entity.Property(e => e.VisitDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit__IdClient__1CF15040");

                entity.HasOne(d => d.IdSrepresentativeNavigation)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.IdSrepresentative)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit__IdSRepres__1DE57479");
            });
        }
    }
}
