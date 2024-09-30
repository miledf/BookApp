using BookApp.Common.report;
using BookApp.Domain.Services;
using BookApp.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Playwright;

namespace BookApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportBooksController : ControllerBase
    {
        private readonly IReportBookService reportBookService;
        private readonly PdfGenerator pdfGenerator;
        private readonly BookViewGenerate bookViewGenerate;

        public ReportBooksController(IReportBookService reportBookService, PdfGenerator pdfGenerator, BookViewGenerate bookViewGenerate)
        {
            this.reportBookService = reportBookService;
            this.pdfGenerator = pdfGenerator;
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

            //var result = await reportBookService.GetAllAsync(token);

            // Gerar o PDF
            //var pdfStream = pdfGenerator.GeneratePdf(result);

            // Retornar o PDF como arquivo para download
            //return File(pdfStream, "application/pdf", "BookList.pdf");
        }

    }
}
