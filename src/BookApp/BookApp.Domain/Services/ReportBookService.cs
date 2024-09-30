using BookApp.Domain.Dtos.BookRequest;
using BookApp.Infrastructure.Context;
using BookApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Domain.Services
{
    public class ReportBookService : IReportBookService
    {
        private readonly AppDbContext appDbContext;


        public ReportBookService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<BookDto>> GetAllBooksAsync(CancellationToken token)
        {
            return await appDbContext.Books.Select(x => new BookDto(x.Id, x.Title, x.Publisher, x.Edition, x.YearPublication)).ToListAsync(token);
        }

        public async Task<List<BooksView>> GetAllAsync(CancellationToken token)
        {
            return await appDbContext.BooksView.ToListAsync(token);
        }
    }
}
