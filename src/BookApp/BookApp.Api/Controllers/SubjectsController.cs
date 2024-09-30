using BookApp.Domain.Dtos.SubjectRequest;
using BookApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IResult> Get(CancellationToken token)
        {
            return Results.Ok(await subjectService.GetAllAsync(token));
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById(int id, CancellationToken token)
        {
            var result = await subjectService.GetByIdAsync(id, token);

            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody]SubjectRequest request, CancellationToken token)
        {
            var result = await subjectService.UpdateAsync(id, request, token);
            if (result == 0)
            {
                return Results.BadRequest();
            }

            return Results.NoContent();
        }

        [HttpPost]
        public async Task<IResult> Post(SubjectRequest request, CancellationToken token)
        {
            var result = await subjectService.CreateAsync(request, token);

            return Results.Created("", result);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id, CancellationToken token)
        {
            await subjectService.DeleteAsync(id, token);

            return Results.NoContent();
        }
    }
}
