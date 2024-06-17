# Loan Calculator Application

This project is a Loan Calculator application built using ASP.NET Core. The application allows users to specify the desired loan amount, payback time, and choose different loan types and payback schemes. The calculator then generates a monthly payback plan based on the selected options.

## How to Build and Run

1. Clone the repository.
2. Open the project in your preferred IDE.
4. Build and run the application.

## How to Add New Loan Types

1. **Create a New Loan Type Class** in `LoanTypes` directory:
   ```csharp
   public class NewLoanType : Loan
   {
       public override decimal InterestRate => 0.045m; // Example interest rate
       public override string DisplayName => "New Loan Type"; // User-friendly name
   }

2. **Register the Loan Type**: The `LoanTypeService` dynamically loads all classes implementing `ILoan`. Ensure your new loan type is within the discoverable namespace.

3. **Use the New Loan Type**: The new loan type will automatically appear in the loan type dropdown on the front end.



## How to Add New Loan Schemes

1. **Create a New Loan Scheme Class** in `LoanSchemes` directory:
   ```csharp
   public class NewLoanScheme : IPaymentScheme
   {
       public string DisplayName => "New Loan Scheme"; // User-friendly name
       public List<Payment> CalculatePayments(decimal amount, int years, decimal interestRate)
       {
            // Implement the payment calculation logic
       }
   }

2. **Register the Loan Scheme**: The `LoanSchemeService` dynamically loads all classes implementing `IPaymentScheme`. Ensure your new loan scheme is within the discoverable namespace.

3. **Use the New Loan Scheme**: The new loan scheme will automatically appear in the loan scheme dropdown on the front end.   
