using LoanCalculatorApp.Interfaces;
using LoanCalculatorApp.ViewModels;

namespace LoanCalculatorApp.Models;

public abstract class PaymentScheme : IPaymentScheme
{
    public abstract string DisplayName { get; }

    public abstract List<Payment> CalculatePayments(decimal amount, int years, decimal interestRate);
}