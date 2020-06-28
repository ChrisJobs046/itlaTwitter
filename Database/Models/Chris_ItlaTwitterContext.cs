using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.Models
{
    public partial class Chris_ItlaTwitterContext : DbContext
    {
        public Chris_ItlaTwitterContext()
        {
        }

        public Chris_ItlaTwitterContext(DbContextOptions<Chris_ItlaTwitterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amigo> Amigo { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Publicaciones> Publicaciones { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=WINDOWS-A16290P;Database=Chris_ItlaTwitter;persist security info=True;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amigo>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.NUsuario1 });

                entity.HasIndex(e => e.NUsuario1)
                    .HasName("IX_FK_Amigo_Usuario1");

                entity.Property(e => e.NUsuario1).HasColumnName("N_Usuario1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AmigoIdUsuarioNavigation)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Amigo_Usuario");

                entity.HasOne(d => d.NUsuario1Navigation)
                    .WithMany(p => p.AmigoNUsuario1Navigation)
                    .HasForeignKey(d => d.NUsuario1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Amigo_Usuario1");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario);

                entity.HasIndex(e => e.IdPublicaciones)
                    .HasName("IX_FK__Comentario_IdPubblicaciones");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IX_FK__Comentarios_IdUsuario");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.NComentario1)
                    .HasColumnName("N_Comentario1")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPublicacionesNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdPublicaciones)
                    .HasConstraintName("FK__Comentario__Id");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Comentario_IdUsuario");
            });

            modelBuilder.Entity<Publicaciones>(entity =>
            {
                entity.HasKey(e => e.IdPublicaciones);

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IX_FK__Publicaciones_IdUsuario");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(1200)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Publicaciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Publicaciones_IdUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Correo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NUsuario)
                    .HasColumnName("N_Usuario")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
