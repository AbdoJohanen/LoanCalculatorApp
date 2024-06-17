using LoanCalculatorApp.Interfaces;

namespace LoanCalculatorApp.Services;

public class LoanTypeService
{
    private readonly List<Type> _loanTypes;

    public LoanTypeService()
    {
        _loanTypes = LoadLoanTypes();
    }
    
    private List<Type> LoadLoanTypes()
    {
        // Load all types that implement ILoan from relevant assemblies
        return AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly => !assembly.IsDynamic)
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t => typeof(ILoan).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .ToList();
    }

    public List<(string Name, string DisplayName)> GetLoanTypes()
    {
        // Return the internal name and display name
        return _loanTypes.Select(t => (
            Name: t.Name,
            DisplayName: ((ILoan)Activator.CreateInstance(t)!).DisplayName
        )).ToList();
    }
    
    public Type GetLoanTypeByName(string loanTypeName)
    {
        // Find the loan type by name from the loaded types
        return _loanTypes.FirstOrDefault(t => t.Name.Equals(loanTypeName, StringComparison.OrdinalIgnoreCase))!;
    }
}