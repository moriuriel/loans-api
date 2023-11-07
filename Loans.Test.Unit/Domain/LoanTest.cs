﻿using Loans.Domain.Entities;
using Loans.Domain.ValueObjects;

namespace Loans.Test.Unit.Domain;

public class LoanTest
{
    [Fact]
    public void CalledFactory_WithValidValues_ShouldBeReturnSuccess()
    {
        //Arrange
        var rules = new LoanRules(
            Age: 30,
            MinimumAmount: 3000,
            MaximumAmount: 1500,
            Location: "SP");

        //Act
        var entity = Loan.Factory(
            type: Loans.Domain.Enums.LoanType.PERSONAL,
            interestRate: 5,
            rules: rules);

        //Assert
        Assert.True(entity.IsSuccess);
    }
}


