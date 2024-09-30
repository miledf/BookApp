using BookApp.Domain.Dtos.AuthorRequest;

namespace BookApp.Domain.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAsync(CancellationToken token);

        Task<AuthorDto?> GetByIdAsync(int id, CancellationToken token);

        Task<int> CreateAsync(AuthorRequest createRequest,  CancellationToken token);
        
        Task<int> UpdateAsync(int id, AuthorRequest UpdateRequest,  CancellationToken token);

        Task DeleteAsync(int id, CancellationToken token);
    }
}