namespace Loans.Domain.ValueObjects;

public sealed record LoanRules(
    int Age,
    decimal MaximumAmount,
    decimal MinimumAmount,
    string Location) { }

