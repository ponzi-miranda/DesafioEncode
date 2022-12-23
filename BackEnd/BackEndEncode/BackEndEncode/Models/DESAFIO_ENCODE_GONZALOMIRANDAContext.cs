using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEndEncode.Models
{
    public partial class DESAFIO_ENCODE_GONZALOMIRANDAContext : DbContext
    {
        public DESAFIO_ENCODE_GONZALOMIRANDAContext()
        {
        }

        public DESAFIO_ENCODE_GONZALOMIRANDAContext(DbContextOptions<DESAFIO_ENCODE_GONZALOMIRANDAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.Property(e => e.ActividadDescripcion)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actividades_Usuarios");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.PaisResidencia)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Telefono).HasMaxLength(1000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
