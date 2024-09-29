using BookApp.Domain.Dtos.BookRequest;
using FluentValidation;

namespace BookApp.Domain.Validators
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        public BookRequestValidator()
        {
            RuleFor(x=>x.Title)
                .NotEmpty()
                .Length(1,40);

            RuleFor(x => x.Publisher)
                .NotEmpty()
                .MaximumLength(40);

            RuleFor(x => x.YearPublication)
                .NotEmpty()
                .MaximumLength(4);

            RuleFor(x => x.Edition)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
