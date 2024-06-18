namespace LoanCalculatorApp.Models.LoanTypes;

public class HousingLoanType : LoanType
{
    public override decimal InterestRate => 0.035m;
    public override string DisplayName => "Housing Loan";
}