using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace BookApp.Domain.models
{
    [Table("Livro")]
    public class Book
    {
        [Column("Codl")]
        public int Id { get; set; }

        [Column("Titulo", TypeName = "varchar(40)")]
        public string Title { get; set; }

        [Column("Editora", TypeName = "varchar(40)")]
        public string Publisher { get; set; }

        [Column("Edicao")]
        public int Edition { get; set; }

        [Column("AnoPublicacao", TypeName = "varchar(4)")]
        public string YearPublication { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
