using FluentValidation.Results;

namespace Loans.Domain.Commons;
public interface IDomainValidation
{
    ValidationResult GetValidationResult();
}


