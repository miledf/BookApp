using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Domain.models
{
    [Table("Assunto")]
    public class Subject
    {
        [Column("CodAs")]
        public int Id { get; set; }

        [Column("Descricao", TypeName = "varchar(20)")]
        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
