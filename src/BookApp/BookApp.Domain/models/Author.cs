using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Domain.models
{
    [Table("Autor")]
    public class Author
    {
        [Column("CodAu")]
        public int Id { get; set; }

        [Column("Nome", TypeName = "varchar(40)")]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
