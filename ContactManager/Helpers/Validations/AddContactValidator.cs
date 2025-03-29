using ContactManager.Contracts.Requests;
using FluentValidation;

namespace ContactManager.Helpers.Validations;

public class AddContactValidator : AbstractValidator<AddContactRequest>
{
    public AddContactValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Address).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}
