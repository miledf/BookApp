namespace BookApp.Infrastructure.Models
{
    public class BooksView
    {
        public string Title { get; set; }

        public int Edition { get; set; }

        public string YearPublication { get; set; }

        public string? Authors { get; set; }

        public string? Subjects { get; set; }
    }
}
