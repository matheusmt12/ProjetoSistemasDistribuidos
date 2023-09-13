using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core
{
    public partial class PeladaContext : DbContext
    {
        public PeladaContext()
        {
        }

        public PeladaContext(DbContextOptions<PeladaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jogador> Jogadors { get; set; }
        public virtual DbSet<Partidum> Partida { get; set; }
        public virtual DbSet<Peladum> Pelada { get; set; }
        public virtual DbSet<Time> Times { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=Pelada");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>(entity =>
            {
                entity.HasKey(e => e.IdJogadores)
                    .HasName("PRIMARY");

                entity.ToTable("jogador");

                entity.HasIndex(e => e.TimeIdTime, "fk_Jogadores_Time_idx");

                entity.Property(e => e.IdJogadores).HasColumnName("idJogadores");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.PosicaoJogador)
                    .IsRequired()
                    .HasColumnType("enum('GOL','LINHA')");

                entity.Property(e => e.TimeIdTime).HasColumnName("Time_idTime");

                entity.HasOne(d => d.TimeIdTimeNavigation)
                    .WithMany(p => p.Jogadors)
                    .HasForeignKey(d => d.TimeIdTime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Jogadores_Time");
            });

            modelBuilder.Entity<Partidum>(entity =>
            {
                entity.HasKey(e => e.IdPartida)
                    .HasName("PRIMARY");

                entity.ToTable("partida");

                entity.HasIndex(e => e.TimeIdTime, "fk_Partida_Time1_idx");

                entity.Property(e => e.IdPartida).HasColumnName("idPartida");

                entity.Property(e => e.PlacarTimeCasa).HasMaxLength(45);

                entity.Property(e => e.PlacarTimeFora).HasMaxLength(45);

                entity.Property(e => e.TimeIdTime).HasColumnName("Time_idTime");

                entity.HasOne(d => d.TimeIdTimeNavigation)
                    .WithMany(p => p.Partida)
                    .HasForeignKey(d => d.TimeIdTime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Partida_Time1");
            });

            modelBuilder.Entity<Peladum>(entity =>
            {
                entity.HasKey(e => e.IdPelada)
                    .HasName("PRIMARY");

                entity.ToTable("pelada");

                entity.Property(e => e.IdPelada).HasColumnName("idPelada");

                entity.Property(e => e.CodigoPelada)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.HasKey(e => e.IdTime)
                    .HasName("PRIMARY");

                entity.ToTable("time");

                entity.HasIndex(e => e.PeladaIdPelada, "fk_Time_Pelada1_idx");

                entity.Property(e => e.IdTime).HasColumnName("idTime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.PeladaIdPelada).HasColumnName("Pelada_idPelada");

                entity.HasOne(d => d.PeladaIdPeladaNavigation)
                    .WithMany(p => p.Times)
                    .HasForeignKey(d => d.PeladaIdPelada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Time_Pelada1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
