using BookApp.Domain.Dtos.BookRequest;
using BookApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext appDbContext;

        public BookService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<int> CreateAsync(BookRequest createBookRequest, CancellationToken token)
        {
            var book = createBookRequest.Map();

            await appDbContext.Books.AddAsync(book, token);
            await appDbContext.SaveChangesAsync(token);

            return book.Id;
        }

        public async Task<int> UpdateAsync(int id, BookRequest updateBookRequest, CancellationToken token)
        {
            var book = await appDbContext.Books.FindAsync(id, token);

            if (book != null)
            {
                book.Publisher = updateBookRequest.Publisher;
                book.Title = updateBookRequest.Title;
                book.Edition = updateBookRequest.Edition;
                book.YearPublication = updateBookRequest.YearPublication;

                appDbContext.Update(book);

                await appDbContext.SaveChangesAsync(token);

                return book.Id;
            }

            return 0;
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            appDbContext.Books.Remove(await appDbContext.Books.SingleAsync(x=>x.Id == id, token));
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<BookDto>> GetAllBooksAsync(CancellationToken token)
        {
            return await appDbContext.Books.Select(x => new BookDto(x.Id, x.Title, x.Publisher, x.Edition, x.YearPublication)).ToListAsync(token);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id, CancellationToken token)
        {
            var result = await appDbContext.Books.FindAsync(id, token);

            return result != null ? new BookDto(result.Id, result.Title, result.Publisher, result.Edition, result.YearPublication) : (BookDto?)null;
        }
    }
}
