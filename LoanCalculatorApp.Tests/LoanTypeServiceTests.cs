using LoanCalculatorApp.Services;

namespace LoanCalculatorApp.Tests;

public class LoanTypeServiceTests
{
    [Fact]
    public void GetLoanTypes_ShouldReturnListOfLoanTypes()
    {
        // Arrange
        var loanTypeService = new LoanTypeService();

        // Act
        var loanTypes = loanTypeService.GetLoanTypes();

        // Assert
        Assert.NotNull(loanTypes); // Check that the result is not null
        Assert.NotEmpty(loanTypes); // Check that the result is not empty
    }
}