using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_Hroads_webAPI.Domains;

#nullable disable

namespace senai_Hroads_webAPI.Contexts
{
    public partial class HroadsContext : DbContext
    {
        public HroadsContext()
        {
        }

        public HroadsContext(DbContextOptions<HroadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MARC-NOTE; initial catalog=Hroads; user Id=sa; pwd=marcsql;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__Classe__60FFF80133C95E1A");

                entity.ToTable("Classe");

                entity.HasIndex(e => e.NomeClasse, "UQ__Classe__F1ED81020CE8481C")
                    .IsUnique();

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.ManaClasse)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("manaClasse");

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("nomeClasse");

                entity.Property(e => e.VidaClasse)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("vidaClasse");
            });

            modelBuilder.Entity<ClasseHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdClasseHabilidade)
                    .HasName("PK__Classe_H__5FC969721269D169");

                entity.ToTable("Classe_Habilidade");

                entity.Property(e => e.IdClasseHabilidade).HasColumnName("idClasseHabilidade");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Classe_Ha__idCla__3E52440B");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Classe_Ha__idHab__3F466844");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__655F75282D3896D0");

                entity.ToTable("Habilidade");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeHabilidade");

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__Habilidad__idTip__38996AB5");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72E73980A2C");

                entity.ToTable("Personagem");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DatAtualizacao)
                    .HasColumnType("date")
                    .HasColumnName("datAtualizacao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("date")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomePersonagem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomePersonagem");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__idCla__4222D4EF");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabilidade)
                    .HasName("PK__TipoHabi__B197B8327CD3DF93");

                entity.ToTable("TipoHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeTipoHabilidate)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoHabilidate");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFFC043C54F");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6C7DA958E");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
