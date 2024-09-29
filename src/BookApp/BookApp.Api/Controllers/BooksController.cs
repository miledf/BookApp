using BookApp.Domain.Dtos.BookRequest;
using BookApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IResult> GetBooks(CancellationToken token)
        {
            return Results.Ok(await bookService.GetAllBooksAsync(token));
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetBook(int id, CancellationToken token)
        {
            var book = await bookService.GetBookByIdAsync(id, token);

            if (book == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IResult> PutBook(int id, [FromBody]BookRequest bookRequest, CancellationToken token)
        {
            var result = await bookService.UpdateAsync(id, bookRequest, token);
            if (result == 0)
            {
                return Results.BadRequest();
            }

            return Results.NoContent();
        }

        [HttpPost]
        public async Task<IResult> PostBook(BookRequest bookRequest, CancellationToken token)
        {
            var result = await bookService.CreateAsync(bookRequest, token);

            return Results.Created("", result);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteBook(int id, CancellationToken token)
        {
            await bookService.DeleteAsync(id, token);

            return Results.NoContent();
        }
    }
}
