using BookApp.Domain.Dtos.AuthorRequest;
using BookApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public async Task<IResult> Get(CancellationToken token)
        {
            return Results.Ok(await authorService.GetAllAsync(token));
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById(int id, CancellationToken token)
        {
            var result = await authorService.GetByIdAsync(id, token);

            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody]AuthorRequest request, CancellationToken token)
        {
            var result = await authorService.UpdateAsync(id, request, token);
            if (result == 0)
            {
                return Results.BadRequest();
            }

            return Results.NoContent();
        }

        [HttpPost]
        public async Task<IResult> Post(AuthorRequest request, CancellationToken token)
        {
            var result = await authorService.CreateAsync(request, token);

            return Results.Created("", result);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id, CancellationToken token)
        {
            await authorService.DeleteAsync(id, token);

            return Results.NoContent();
        }
    }
}
