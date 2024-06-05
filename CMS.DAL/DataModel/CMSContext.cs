using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CMS.DAL.DataModel
{
    public partial class CMSContext : IdentityDbContext<ApplicationUser>
    {
        public CMSContext()
        {
        }

        public CMSContext(DbContextOptions<CMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citatelji> Citatelji { get; set; }
        public virtual DbSet<Clanci> Clanci { get; set; }
        public virtual DbSet<Komentari> Komentari { get; set; }
        public virtual DbSet<Novinari> Novinari { get; set; }
        public virtual DbSet<Osobe> Osobe { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(x => x.UserId);
            }); 

            modelBuilder.Entity<Citatelji>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrojKomentara)
                    .HasColumnName("broj_komentara")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Citatelji)
                    .HasForeignKey<Citatelji>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Citatelji__id__3C69FB99");
            });

            modelBuilder.Entity<Clanci>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumIzmjene)
                    .HasColumnName("datum_izmjene")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatumKreiranja)
                    .HasColumnName("datum_kreiranja")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Kategorija)
                    .HasColumnName("kategorija")
                    .HasMaxLength(50);

                entity.Property(e => e.Naslov)
                    .IsRequired()
                    .HasColumnName("naslov")
                    .HasMaxLength(255);

                entity.Property(e => e.NovinarId).HasColumnName("novinar_id");

                entity.Property(e => e.Ocjena).HasColumnName("ocjena");

                entity.Property(e => e.Sadrzaj)
                    .IsRequired()
                    .HasColumnName("sadrzaj");

                entity.Property(e => e.Slika).HasColumnName("slika");

                entity.HasOne(d => d.Novinar)
                    .WithMany(p => p.Clanci)
                    .HasForeignKey(d => d.NovinarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clanci__novinar___44FF419A");
            });

            modelBuilder.Entity<Komentari>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CitateljId).HasColumnName("citatelj_id");

                entity.Property(e => e.ClanakId).HasColumnName("clanak_id");

                entity.Property(e => e.DatumKreiranja)
                    .HasColumnName("datum_kreiranja")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ocjena).HasColumnName("ocjena");

                entity.Property(e => e.Sadrzaj)
                    .IsRequired()
                    .HasColumnName("sadrzaj");

                entity.HasOne(d => d.Citatelj)
                    .WithMany(p => p.Komentari)
                    .HasForeignKey(d => d.CitateljId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Komentari__citat__49C3F6B7");

                entity.HasOne(d => d.Clanak)
                    .WithMany(p => p.Komentari)
                    .HasForeignKey(d => d.ClanakId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Komentari__clana__48CFD27E");
            });

            modelBuilder.Entity<Novinari>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrojClanaka)
                    .HasColumnName("broj_clanaka")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Novinari)
                    .HasForeignKey<Novinari>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Novinari__id__403A8C7D");
            });

            modelBuilder.Entity<Osobe>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Osobe__AB6E6164765749EB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumRegistracije)
                    .HasColumnName("datum_registracije")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(50);

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasColumnName("lozinka")
                    .HasMaxLength(255);

                entity.Property(e => e.OpisProfila)
                    .HasColumnName("opis_profila")
                    .HasMaxLength(255);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasColumnName("prezime")
                    .HasMaxLength(50);

                entity.Property(e => e.Uloga)
                    .IsRequired()
                    .HasColumnName("uloga")
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
