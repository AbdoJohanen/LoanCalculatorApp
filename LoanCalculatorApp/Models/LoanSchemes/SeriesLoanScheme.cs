using LoanCalculatorApp.ViewModels;

namespace LoanCalculatorApp.Models.LoanSchemes;

public class SeriesLoanScheme : PaymentScheme
{
    public override string DisplayName => "Series Loan Principle";
    public override List<Payment> CalculatePayments(decimal amount, int years, decimal interestRate)
    {
        var payments = new List<Payment>();
        var monthlyInterestRate = interestRate / 12;
        var numberOfPayments = years * 12;
        var principalPayment = amount / numberOfPayments;
        var remainingBalance = amount;

        for (int month = 1; month <= numberOfPayments; month++)
        {
            var interestPayment = remainingBalance * monthlyInterestRate;
            var totalPayment = principalPayment + interestPayment;

            payments.Add(new Payment
            {
                Month = month,
                Principal = principalPayment,
                Interest = interestPayment,
                TotalPayment = totalPayment
            });

            remainingBalance -= principalPayment;
        }

        return payments;
    }
}