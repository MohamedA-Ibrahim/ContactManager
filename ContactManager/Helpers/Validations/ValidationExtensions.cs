using FluentValidation;

namespace ContactManager.Helpers.Validations;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string> EgyptianPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches("^01[0-2,5][0-9]{8}$")
            .WithMessage("Invalid Egyptian phone number format. It must be 11 digits starting with 010, 011, 012, or 015.");
    }
}
