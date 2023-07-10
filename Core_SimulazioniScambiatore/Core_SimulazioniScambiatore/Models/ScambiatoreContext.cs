using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core_SimulazioniScambiatore.Models
{
    public partial class ScambiatoreContext : DbContext
    {
        public ScambiatoreContext()
        {
        }

        public ScambiatoreContext(DbContextOptions<ScambiatoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoefficentiDiTrasferimento> CoefficentiDiTrasferimentos { get; set; } = null!;
        public virtual DbSet<CoefficentiDiTrasferimento1> CoefficentiDiTrasferimentos1 { get; set; } = null!;
        public virtual DbSet<CoefficentiGlobali> CoefficentiGlobalis { get; set; } = null!;
        public virtual DbSet<Fluido> Fluidos { get; set; } = null!;
        public virtual DbSet<Fluido1> Fluidos1 { get; set; } = null!;
        public virtual DbSet<Flusso> Flussos { get; set; } = null!;
        public virtual DbSet<Scambiatore> Scambiatores { get; set; } = null!;
        public virtual DbSet<Scambiatore1> Scambiatores1 { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Scambiatore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoefficentiDiTrasferimento>(entity =>
            {
                entity.HasKey(e => e.IdCalcoli)
                    .HasName("PK_Calcoli");

                entity.ToTable("CoefficentiDiTrasferimento", "lato_anello");

                entity.HasOne(d => d.IdFlussoNavigation)
                    .WithMany(p => p.CoefficentiDiTrasferimentos)
                    .HasForeignKey(d => d.IdFlusso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoefficentiDiTrasferimento_Flusso");
            });

            modelBuilder.Entity<CoefficentiDiTrasferimento1>(entity =>
            {
                entity.HasKey(e => e.IdCalcoli)
                    .HasName("PK_Calcoli");

                entity.ToTable("CoefficentiDiTrasferimento", "lato_tubo");

                entity.HasOne(d => d.IdFlussoNavigation)
                    .WithMany(p => p.CoefficentiDiTrasferimento1s)
                    .HasForeignKey(d => d.IdFlusso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoefficentiDiTrasferimento_Flusso");
            });

            modelBuilder.Entity<CoefficentiGlobali>(entity =>
            {
                entity.ToTable("CoefficentiGlobali", "global");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.IdFlussoNavigation)
                    .WithMany(p => p.CoefficentiGlobalis)
                    .HasForeignKey(d => d.IdFlusso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoefficentiGlobali_Flusso");
            });

            modelBuilder.Entity<Fluido>(entity =>
            {
                entity.HasKey(e => e.IdFluido);

                entity.ToTable("Fluido", "lato_anello");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Fluido1>(entity =>
            {
                entity.HasKey(e => e.IdFluido);

                entity.ToTable("Fluido", "lato_tubo");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Flusso>(entity =>
            {
                entity.HasKey(e => e.IdFlusso);

                entity.ToTable("Flusso", "global");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFluidoNavigation)
                    .WithMany(p => p.Flussos)
                    .HasForeignKey(d => d.IdFluido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flusso_Fluido1");

                entity.HasOne(d => d.IdFluido1)
                    .WithMany(p => p.Flussos)
                    .HasForeignKey(d => d.IdFluido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flusso_Fluido");

                entity.HasOne(d => d.IdScambiatoreNavigation)
                    .WithMany(p => p.Flussos)
                    .HasForeignKey(d => d.IdScambiatore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flusso_Scambiatore1");

                entity.HasOne(d => d.IdScambiatore1)
                    .WithMany(p => p.Flussos)
                    .HasForeignKey(d => d.IdScambiatore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flusso_Scambiatore");
            });

            modelBuilder.Entity<Scambiatore>(entity =>
            {
                entity.HasKey(e => e.IdScambiatore);

                entity.ToTable("Scambiatore", "lato_anello");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Scambiatore1>(entity =>
            {
                entity.HasKey(e => e.IdScambiatore);

                entity.ToTable("Scambiatore", "lato_tubo");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
