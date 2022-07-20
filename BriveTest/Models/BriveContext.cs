using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BriveTest.Models
{
    public partial class BriveContext : DbContext
    {
        public BriveContext()
        {
        }

        public BriveContext(DbContextOptions<BriveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProdDeta> ProdDeta { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=BRZYRO;Database=Brive;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdDeta>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.Property(e => e.IdDetalle)
                    .HasColumnName("idDetalle")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodBarr).HasColumnName("codBarr");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecUnit).HasColumnName("precUnit");

                entity.HasOne(d => d.CodBarrNavigation)
                    .WithMany(p => p.ProdDeta)
                    .HasForeignKey(d => d.CodBarr)
                    .HasConstraintName("FK_ProdDeta_Producto");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.ProdDeta)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK_ProdDeta_ProdDeta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodBarr);

                entity.Property(e => e.CodBarr)
                    .HasColumnName("codBarr")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal);

                entity.Property(e => e.IdSucursal)
                    .HasColumnName("idSucursal")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
