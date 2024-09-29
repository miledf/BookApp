using BookApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Authors)
                .WithMany(e => e.Books)
                .UsingEntity(
                    "Livro_Autor",
                     j =>
                     {
                         j.Property("BooksId").HasColumnName("Livro_Codl");
                         j.Property("AuthorsId").HasColumnName("Autor_CodAu");
                     }
                );

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Subjects)
                .WithMany(e => e.Books)
                .UsingEntity(
                    "Livro_Assunto",
                    j =>
                    {
                        j.Property("BooksId").HasColumnName("Livro_Codl");
                        j.Property("SubjectsId").HasColumnName("Assunto_CodAs");                        
                    });
        }
    }
}
