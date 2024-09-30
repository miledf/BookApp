using BookApp.Domain.Dtos.AuthorRequest;
using BookApp.Domain.Dtos.BookRequest;
using BookApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext appDbContext;

        public AuthorService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<int> CreateAsync(AuthorRequest createRequest, CancellationToken token)
        {
            var author = createRequest.Map();

            await appDbContext.Authors.AddAsync(author, token);
            await appDbContext.SaveChangesAsync(token);

            return author.Id;
        }

        public async Task<int> UpdateAsync(int id, AuthorRequest updateRequest, CancellationToken token)
        {
            var author = await appDbContext.Authors.FindAsync(id, token);

            if (author != null)
            {
                author.Name = updateRequest.Name;

                appDbContext.Update(author);

                await appDbContext.SaveChangesAsync(token);

                return author.Id;
            }

            return 0;
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            appDbContext.Authors.Remove(await appDbContext.Authors.SingleAsync(x=>x.Id == id, token));
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<AuthorDto>> GetAllAsync(CancellationToken token)
        {
            return await appDbContext.Authors.Select(x => new AuthorDto(x.Id, x.Name)).ToListAsync(token);
        }

        public async Task<AuthorDto?> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await appDbContext.Authors.FindAsync(id, token);

            return result != null ? new AuthorDto(result.Id, result.Name) : (AuthorDto?)null;
        }
    }
}
