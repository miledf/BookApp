using BookApp.Domain.Dtos.BookRequest;

namespace BookApp.Domain.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooksAsync(CancellationToken token);

        Task<BookDto?> GetBookByIdAsync(int id, CancellationToken token);

        Task<int> CreateAsync(BookRequest createBookRequest,  CancellationToken token);
        
        Task<int> UpdateAsync(int id, BookRequest UpdateBookRequest,  CancellationToken token);

        Task DeleteAsync(int id, CancellationToken token);
    }
}