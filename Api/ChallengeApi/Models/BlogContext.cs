using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ChallengeApi.Models
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Noticium> Noticia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9J8HBQA\\LOCAL;Database=Blog;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Noticium>(entity =>
            {
                entity.HasKey(e => e.IdNoticia);

                entity.Property(e => e.Contenido)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fechacrea)
                    .HasColumnType("datetime")
                    .HasColumnName("fechacrea");

                entity.Property(e => e.Fechamodifica)
                    .HasColumnType("datetime")
                    .HasColumnName("fechamodifica");

                entity.Property(e => e.IdSecundario)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("idSecundario");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.Property(e => e.Usuariocrea)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usuariocrea");

                entity.Property(e => e.Usuariomodifica)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usuariomodifica");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
