using BookApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<BooksView> BooksView { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<BooksView>().HasNoKey().ToView("vw_Detailed_Books");
        }
    }
}
