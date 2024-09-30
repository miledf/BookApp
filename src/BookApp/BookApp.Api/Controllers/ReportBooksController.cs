using BookApp.Common.report;
using BookApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Playwright;

namespace BookApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportBooksController : ControllerBase
    {
        private readonly IReportBookService reportBookService;
        private readonly BookViewGenerate bookViewGenerate;

        public ReportBooksController(IReportBookService reportBookService, BookViewGenerate bookViewGenerate)
        {
            this.reportBookService = reportBookService;
            this.bookViewGenerate = bookViewGenerate;
        }

        [HttpGet]
        public async Task<IResult> GetBooks(CancellationToken token)
        {
            return Results.Ok(await reportBookService.GetAllAsync(token));
        }

        [HttpGet("Download")]
        public async Task<IActionResult> Download(CancellationToken token)
        {
            var books = await reportBookService.GetAllAsync(token);

            if (!books.Any())
                return NotFound();

            using var plaiwright = await Playwright.CreateAsync();
            var browser = await plaiwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            await page.SetContentAsync(await bookViewGenerate.ToHtmlAsync(books));

            var pdf = await page.PdfAsync(new PagePdfOptions { Format = "A4" });

            return File(pdf, "application/pdf", "reportBook.pdf");
        }

    }
}
