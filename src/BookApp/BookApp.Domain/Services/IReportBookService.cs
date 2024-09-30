using BookApp.Domain.Dtos.BookRequest;
using BookApp.Infrastructure.Models;

namespace BookApp.Domain.Services
{
    public interface IReportBookService
    {
        Task<List<BooksView>> GetAllAsync(CancellationToken token);
    }
}