using FluentValidation;

namespace Loans.Domain.ValueObjects;

public sealed record LoanRules(
    int Age,
    decimal MaximumAmount,
    decimal MinimumAmount,
    string Location) { }

internal sealed class LoanRulesValidator : AbstractValidator<LoanRules>
{
    public LoanRulesValidator()
    {
        RuleFor(_ => _.Age)
            .NotNull()
            .GreaterThan(0);

        RuleFor(_ => _.MaximumAmount)
            .NotNull()
            .GreaterThan(0);

        RuleFor(_ => _.Location)
            .NotEmpty()
            .MinimumLength(2)
            .MinimumLength(2);

        RuleFor(_ => _.MinimumAmount)
            .NotNull()
            .GreaterThan(0);
    }
}