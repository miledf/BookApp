namespace BookApp.Domain.Dtos.BookRequest
{
    public record BookRequest (string Title, string Publisher, int Edition, string YearPublication);
}
