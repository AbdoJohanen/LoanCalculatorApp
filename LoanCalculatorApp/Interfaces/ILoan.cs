using LoanCalculatorApp.ViewModels;

namespace LoanCalculatorApp.Interfaces;

public interface ILoan
{
    decimal Amount { get; set; }
    int Years { get; set; }
    decimal InterestRate { get; }
    public IPaymentScheme PaymentScheme { set; }
    string DisplayName { get; }
    List<Payment> CalculatePayments();
}