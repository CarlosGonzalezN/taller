using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Taller.Model
{
    public partial class tallerMecanicoContext : DbContext
    {
        public tallerMecanicoContext()
        {
        }

        public tallerMecanicoContext(DbContextOptions<tallerMecanicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auto> Autos { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Tecnico> Tecnicos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("cadenaSQL");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>(entity =>
            {
                entity.ToTable("AUTO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Año).HasColumnName("año");

                entity.Property(e => e.Celular)
                    .HasMaxLength(15)
                    .HasColumnName("celular")
                    .IsFixedLength();

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasColumnName("color")
                    .IsFixedLength();

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");

                entity.Property(e => e.Km).HasColumnName("km");

                entity.Property(e => e.Marca)
                    .HasMaxLength(15)
                    .HasColumnName("marca")
                    .IsFixedLength();

                entity.Property(e => e.Modelo)
                    .HasMaxLength(15)
                    .HasColumnName("modelo")
                    .IsFixedLength();

                entity.Property(e => e.NChasis)
                    .HasMaxLength(25)
                    .HasColumnName("nChasis")
                    .IsFixedLength();

                entity.Property(e => e.Patente)
                    .HasMaxLength(15)
                    .HasColumnName("patente")
                    .IsFixedLength();

                entity.Property(e => e.Problema)
                    .HasMaxLength(500)
                    .HasColumnName("problema")
                    .IsFixedLength();

                entity.Property(e => e.Solucion)
                    .HasMaxLength(500)
                    .HasColumnName("solucion")
                    .IsFixedLength();

                entity.Property(e => e.TitularApellido)
                    .HasMaxLength(50)
                    .HasColumnName("titularApellido")
                    .IsFixedLength();

                entity.Property(e => e.TitularNombre)
                    .HasMaxLength(25)
                    .HasColumnName("titularNombre")
                    .IsFixedLength();

                entity.HasOne(d => d.oEstado)
                    .WithMany(p => p.Autos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_IDESTADO");

                entity.HasOne(d => d.oTecnico)
                    .WithMany(p => p.Autos)
                    .HasForeignKey(d => d.IdTecnico)
                    .HasConstraintName("FK_IDTECNICO");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("ESTADO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(15)
                    .HasColumnName("descripcion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.ToTable("TECNICO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(20)
                    .HasColumnName("apellido")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("nombre")
                    .IsFixedLength();

                entity.Property(e => e.Rol)
                    .HasMaxLength(10)
                    .HasColumnName("rol")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
