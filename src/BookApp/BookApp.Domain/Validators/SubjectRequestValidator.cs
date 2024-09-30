using BookApp.Domain.Dtos.SubjectRequest;
using FluentValidation;

namespace BookApp.Domain.Validators
{
    public class SubjectRequestValidator : AbstractValidator<SubjectRequest>
    {
        public SubjectRequestValidator()
        {
            RuleFor(x=>x.Description)
                .NotEmpty()
                .Length(1,20);
        }
    }
}
