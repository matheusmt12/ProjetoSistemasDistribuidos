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
        public virtual DbSet<Listajogador> Listajogadors { get; set; }
        public virtual DbSet<Partidum> Partida { get; set; }
        public virtual DbSet<Peladum> Pelada { get; set; }
        public virtual DbSet<Time> Times { get; set; }
        public virtual DbSet<Timejogador> Timejogadors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=Pelada");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>(entity =>
            {
                entity.HasKey(e => e.IdJogador)
                    .HasName("PRIMARY");

                entity.ToTable("jogador");

                entity.HasIndex(e => e.UserName, "UserName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdJogador).HasColumnName("idJogador");

                entity.Property(e => e.NomeJogador)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.PosicaoJogador).HasColumnType("enum('GOL','LINHA')");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Listajogador>(entity =>
            {
                entity.HasKey(e => new { e.JogadorIdJogador, e.PeladaIdPelada })
                    .HasName("PRIMARY");

                entity.ToTable("listajogador");

                entity.HasIndex(e => e.JogadorIdJogador, "fk_Jogador_has_Pelada_Jogador1_idx");

                entity.HasIndex(e => e.PeladaIdPelada, "fk_Jogador_has_Pelada_Pelada1_idx");

                entity.Property(e => e.JogadorIdJogador).HasColumnName("Jogador_idJogador");

                entity.Property(e => e.PeladaIdPelada).HasColumnName("Pelada_idPelada");

                entity.HasOne(d => d.JogadorIdJogadorNavigation)
                    .WithMany(p => p.Listajogadors)
                    .HasForeignKey(d => d.JogadorIdJogador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Jogador_has_Pelada_Jogador1");

                entity.HasOne(d => d.PeladaIdPeladaNavigation)
                    .WithMany(p => p.Listajogadors)
                    .HasForeignKey(d => d.PeladaIdPelada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Jogador_has_Pelada_Pelada1");
            });

            modelBuilder.Entity<Partidum>(entity =>
            {
                entity.HasKey(e => e.IdPartida)
                    .HasName("PRIMARY");

                entity.ToTable("partida");

                entity.HasIndex(e => e.TimeIdTimeCasa, "fk_Partida_Time1_idx");

                entity.HasIndex(e => e.TimeIdTimeFora, "fk_Partida_Time2_idx");

                entity.Property(e => e.IdPartida).HasColumnName("idPartida");

                entity.Property(e => e.PlacarTimeCasa).HasMaxLength(45);

                entity.Property(e => e.PlacarTimeFora).HasMaxLength(45);

                entity.Property(e => e.TempoDePartida)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.TimeIdTimeCasa).HasColumnName("Time_idTime_Casa");

                entity.Property(e => e.TimeIdTimeFora).HasColumnName("Time_idTime_Fora");

                entity.HasOne(d => d.TimeIdTimeCasaNavigation)
                    .WithMany(p => p.PartidumTimeIdTimeCasaNavigations)
                    .HasForeignKey(d => d.TimeIdTimeCasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Partida_Time1");

                entity.HasOne(d => d.TimeIdTimeForaNavigation)
                    .WithMany(p => p.PartidumTimeIdTimeForaNavigations)
                    .HasForeignKey(d => d.TimeIdTimeFora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Partida_Time2");
            });

            modelBuilder.Entity<Peladum>(entity =>
            {
                entity.HasKey(e => e.IdPelada)
                    .HasName("PRIMARY");

                entity.ToTable("pelada");

                entity.HasIndex(e => e.CodigoPelada, "CodigoPelada_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPelada).HasColumnName("idPelada");

                entity.Property(e => e.CodigoPelada)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Local).HasMaxLength(200);

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

            modelBuilder.Entity<Timejogador>(entity =>
            {
                entity.HasKey(e => new { e.TimeIdTime, e.JogadorIdJogador })
                    .HasName("PRIMARY");

                entity.ToTable("timejogador");

                entity.HasIndex(e => e.JogadorIdJogador, "fk_Time_has_Jogador_Jogador1_idx");

                entity.HasIndex(e => e.TimeIdTime, "fk_Time_has_Jogador_Time1_idx");

                entity.Property(e => e.TimeIdTime).HasColumnName("Time_idTime");

                entity.Property(e => e.JogadorIdJogador).HasColumnName("Jogador_idJogador");

                entity.HasOne(d => d.JogadorIdJogadorNavigation)
                    .WithMany(p => p.Timejogadors)
                    .HasForeignKey(d => d.JogadorIdJogador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Time_has_Jogador_Jogador1");

                entity.HasOne(d => d.TimeIdTimeNavigation)
                    .WithMany(p => p.Timejogadors)
                    .HasForeignKey(d => d.TimeIdTime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Time_has_Jogador_Time1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
