using BookApp.Domain.Dtos.AuthorRequest;
using FluentValidation;

namespace BookApp.Domain.Validators
{
    public class AuthorRequestValidator : AbstractValidator<AuthorRequest>
    {
        public AuthorRequestValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                .Length(1,40);
        }
    }
}
