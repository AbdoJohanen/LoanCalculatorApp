using LoanCalculatorApp.ViewModels;

namespace LoanCalculatorApp.Interfaces;

public interface IPaymentScheme
{
    string DisplayName { get; }
    List<Payment> CalculatePayments(decimal amount, int years, decimal interestRate);
}