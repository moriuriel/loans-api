using FluentValidation;
using FluentValidation.Results;
using Loans.Domain.Commons;
using Loans.Domain.Enums;
using Loans.Domain.ValueObjects;

namespace Loans.Domain.Entities;

public class Loan : AggregateRoot, IDomainValidation
{
    public Loan(
        Guid? id,
        LoanType type,
        decimal interestRate,
        LoanRules rules,
        bool active = true) : base(id: id ?? Guid.NewGuid())
    {
        Type = type;
        InterestRate = interestRate;
        Rules = rules;
        Active = active;
    }

    public static Result<Loan> Factory(
        LoanType type,
        decimal interestRate,
        LoanRules rules,
        Guid? id = null)
    {
        var entity = new Loan(
            id,
            type,
            interestRate,
            rules);

        if (!entity.GetValidationResult().IsValid)
            return Result.Failure<Loan>(errors:
                entity.GetValidationResult().Errors.Select(_ => new Error(
                    _.ErrorCode,
                    _.ErrorMessage
               )));

        return entity;
    }

    public ValidationResult GetValidationResult()
        => new LoanValidator().Validate(this);

    public LoanType Type { get; private set; }
    public decimal InterestRate { get; private set; }
    public LoanRules Rules { get; private set; }
    public bool Active { get; private set; }

    public void UpdateActive(bool status)
    {
        Active = status;
    }
}

internal sealed class LoanValidator : AbstractValidator<Loan>
{
    public LoanValidator()
    {
        RuleFor(_ => _.Id)
            .NotEmpty();

        RuleFor(_ => _.Type)
            .IsInEnum();

        RuleFor(_ => _.InterestRate)
            .NotNull()
            .GreaterThanOrEqualTo(0);

        RuleFor(_ => _.Active)
            .NotEmpty();

        RuleFor(_ => _.Rules).SetValidator(new LoanRulesValidator());
    }
}