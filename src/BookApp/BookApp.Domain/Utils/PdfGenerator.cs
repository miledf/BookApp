using BookApp.Infrastructure.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;

namespace BookApp.Domain.Utils
{
    public class PdfGenerator
    {
        public MemoryStream GeneratePdf(List<BooksView> books)
        {
            MemoryStream stream = new MemoryStream();
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Book List";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 12, XFontStyleEx.Regular);

            gfx.DrawString("Book List", new XFont("Verdana", 16, XFontStyleEx.Bold), XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.TopCenter);

            double yPos = 40;

            foreach (var book in books)
            {
                string text = $"{book.Title} - {book.Edition} ({book.YearPublication}) - ({book.Authors})- ({book.Subjects})";
                gfx.DrawString(text, font, XBrushes.Black, new XRect(40, yPos, page.Width - 80, page.Height), XStringFormats.TopLeft);                
                yPos += 25;
            }

            // Salvar o PDF no MemoryStream
            document.Save(stream, false);
            stream.Position = 0; // Resetar o fluxo para o início

            return stream;
        }
    }
}
