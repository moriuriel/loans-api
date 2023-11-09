using Loans.Domain.Entities;
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

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void UpdateActive_WithValidValues_ShouldBeReturnExpectedValue(bool status)
    {
        //Arrange
        var rules = new LoanRules(
            Age: 30,
            MinimumAmount: 3000,
            MaximumAmount: 1500,
            Location: "SP");

        var entity = Loan.Factory(
            type: Loans.Domain.Enums.LoanType.PERSONAL,
            interestRate: 5,
            rules: rules);


        //Act
        entity.Value.UpdateActive(status);

        //Assert
        Assert.Equal(entity.Value.Active, status);
    }
}


