using LoanCalculatorApp.Interfaces;

namespace LoanCalculatorApp.Services;

public class LoanSchemeService
{
    private readonly List<Type> _loanSchemes;

    public LoanSchemeService()
    {
        _loanSchemes = LoadLoanSchemes();
    }
    
    private List<Type> LoadLoanSchemes()
    {
        // Load all types that implement IPaymentScheme from relevant assemblies
        return AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly => !assembly.IsDynamic)
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t => typeof(IPaymentScheme).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .ToList();
    }
    
    public List<(string Name, string DisplayName)> GetLoanSchemes()
    {
        // Return the internal name and display name
        return _loanSchemes.Select(t => (
            Name: t.Name,
            DisplayName: ((IPaymentScheme)Activator.CreateInstance(t)!).DisplayName
        )).ToList();
    }
    
    public Type GetLoanSchemeByName(string loanSchemeName)
    {
        // Find the loan scheme by name from the loaded types

        return _loanSchemes.FirstOrDefault(t => t.Name.Equals(loanSchemeName, StringComparison.OrdinalIgnoreCase))!;
    }
}