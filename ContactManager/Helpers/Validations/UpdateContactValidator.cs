using ContactManager.Contracts.Requests;
using FluentValidation;

namespace ContactManager.Helpers.Validations;

public class UpdateContactValidator : AbstractValidator<UpdateContactRequest>
{
    public UpdateContactValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Phone).NotEmpty().EgyptianPhoneNumber();
        RuleFor(x => x.Address).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}