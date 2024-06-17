namespace LoanCalculatorApp.ViewModels;

public class Payment
{
    public int Month { get; set; }
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public decimal TotalPayment { get; set; }
}