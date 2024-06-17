namespace LoanCalculatorApp.ViewModels;

public class LoanViewModel
{
    public LoanViewModel()
    {
        Payments = new List<Payment>();
        LoanTypes = new List<(string Name, string DisplayName)>();
        LoanSchemes = new List<(string Name, string DisplayName)>();
    }
    public decimal Amount { get; set; }
    public int Years { get; set; }
    public decimal MonthlyPayment { get; set; }
    public List<Payment> Payments { get; set; }
    public string LoanType { get; set; }
    public string LoanScheme { get; set; }
    public List<(string Name, string DisplayName)> LoanTypes { get; set; }
    public List<(string Name, string DisplayName)> LoanSchemes { get; set; }
}