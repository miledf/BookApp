using BookApp.Infrastructure.Models;

namespace BookApp.Domain.Dtos.AuthorRequest
{
    public static class AuthorRequestMapper
    {
        public static  Author Map(this AuthorRequest request)
        {
            return new Author
            {
                Name = request.Name
            };
        }

        public static AuthorDto Map(this Author author)
        {
            return new AuthorDto(author.Id, author.Name);
        }
    }
}
