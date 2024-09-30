using BookApp.Domain.Dtos.SubjectRequest;

namespace BookApp.Domain.Services
{
    public interface ISubjectService
    {
        Task<List<SubjectDto>> GetAllAsync(CancellationToken token);

        Task<SubjectDto?> GetByIdAsync(int id, CancellationToken token);

        Task<int> CreateAsync(SubjectRequest createRequest,  CancellationToken token);
        
        Task<int> UpdateAsync(int id, SubjectRequest UpdateRequest,  CancellationToken token);

        Task DeleteAsync(int id, CancellationToken token);
    }
}