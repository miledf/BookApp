using BookApp.Domain.Dtos.BookRequest;
using BookApp.Domain.Dtos.SubjectRequest;
using BookApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using BookApp.Domain.Dtos.SubjectRequestMapper;

namespace BookApp.Domain.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly AppDbContext appDbContext;

        public SubjectService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<int> CreateAsync(SubjectRequest createRequest, CancellationToken token)
        {
            var subject = createRequest.Map();

            await appDbContext.Subjects.AddAsync(subject, token);
            await appDbContext.SaveChangesAsync(token);

            return subject.Id;
        }

        public async Task<int> UpdateAsync(int id, SubjectRequest updateRequest, CancellationToken token)
        {
            var book = await appDbContext.Subjects.FindAsync(id, token);

            if (book != null)
            {
                book.Description = updateRequest.Description;

                appDbContext.Update(book);

                await appDbContext.SaveChangesAsync(token);

                return book.Id;
            }

            return 0;
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            appDbContext.Subjects.Remove(await appDbContext.Subjects.SingleAsync(x=>x.Id == id, token));
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<SubjectDto>> GetAllAsync(CancellationToken token)
        {
            return await appDbContext.Subjects.Select(x => new SubjectDto(x.Id, x.Description)).ToListAsync(token);
        }

        public async Task<SubjectDto?> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await appDbContext.Subjects.FindAsync(id, token);

            return result != null ? new SubjectDto(result.Id, result.Description) : (SubjectDto?)null;
        }
    }
}
