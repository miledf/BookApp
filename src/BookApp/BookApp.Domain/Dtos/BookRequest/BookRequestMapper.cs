using BookApp.Infrastructure.Models;

namespace BookApp.Domain.Dtos.BookRequest
{
    public static class BookRequestMapper
    {
        public static Book Map(this BookRequest bookRequest)
        {
            return new Book
            {
                Title = bookRequest.Title,
                YearPublication = bookRequest.YearPublication,
                Publisher = bookRequest.Publisher,
                Edition = bookRequest.Edition
            };
        }

        public static BookDto Map(this Book book)
        {
            return new BookDto(book.Id, book.Title, book.Publisher, book.Edition, book.YearPublication);
        }
    }
}
