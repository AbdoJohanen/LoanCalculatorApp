using LoanCalculatorApp.Interfaces;
using LoanCalculatorApp.ViewModels;

namespace LoanCalculatorApp.Models;

public abstract class LoanType : ILoanType
{
    public decimal Amount { get; set; }
    public int Years { get; set; }
    public abstract decimal InterestRate { get; }
    public required IPaymentScheme PaymentScheme { get; set; }
    public abstract string DisplayName { get; }

    public List<Payment> CalculatePayments()
    {
        return PaymentScheme.CalculatePayments(Amount, Years, InterestRate);
    }
}