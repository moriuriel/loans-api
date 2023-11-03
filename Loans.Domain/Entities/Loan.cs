using FluentValidation;
using Loans.Domain.Enums;
using Loans.Domain.ValueObjects;

namespace Loans.Domain.Entities;

public class Loan : AggregateRoot
{
    public Loan(
        Guid? id,
        LoanType type,
        decimal interestRate,
        LoanRules rules) : base(id: id ?? Guid.NewGuid())
    {
        Type = type;
        InterestRate = interestRate;
        Rules = rules;
    }

    public static Loan Factory(
        LoanType type,
        decimal interestRate,
        LoanRules rules,
        Guid? id = null)
    {
        return new Loan(
            id,
            type,
            interestRate,
            rules);
    }

    public LoanType Type { get; private set; }
    public decimal InterestRate { get; private set; }
    public LoanRules Rules { get; private set; }
}

internal sealed class LoanValidator : AbstractValidator<Loan>
{
    public LoanValidator()
    {
        RuleFor(_ => _.Id)
            .NotNull();

        RuleFor(_ => _.Type)
            .IsInEnum();

        RuleFor(_ => _.InterestRate)
            .NotNull();

        RuleFor(_ => _.Rules).SetValidator(new LoanRulesValidator());
    }
}