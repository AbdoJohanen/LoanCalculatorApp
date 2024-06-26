using LoanCalculatorApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LoanCalculatorApp.Services;
using LoanCalculatorApp.ViewModels;

namespace LoanCalculatorApp.Controllers;

public class HomeController : Controller
{
    private readonly LoanTypeService _loanTypeService;
    private readonly LoanSchemeService _loanSchemeService;

    public HomeController(LoanTypeService loanTypeService, LoanSchemeService loanSchemeService)
    {
        _loanTypeService = loanTypeService;
        _loanSchemeService = loanSchemeService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var loanTypes = _loanTypeService.GetLoanTypes();
        var loanSchemes = _loanSchemeService.GetLoanSchemes();
        var viewModel = new LoanViewModel
        {
            LoanTypes = loanTypes,
            LoanSchemes = loanSchemes
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Calculate([FromBody] LoanViewModel loanViewModel)
    {
        var loanType = _loanTypeService.GetLoanTypeByName(loanViewModel.LoanType);
        var loanScheme = _loanSchemeService.GetLoanSchemeByName(loanViewModel.LoanScheme);

        if (loanType != null && loanScheme != null)
        {
            // Create an instance of the loan type
            var loan = (ILoanType)Activator.CreateInstance(loanType)!;
            loan.Amount = loanViewModel.Amount;
            loan.Years = loanViewModel.Years;

            // Create an instance of the loan scheme and set it
            loan.PaymentScheme = (IPaymentScheme)Activator.CreateInstance(loanScheme)!;

            var payments = loan.CalculatePayments();

            var viewModel = new LoanViewModel
            {
                Amount = loan.Amount,
                Years = loan.Years,
                LoanType = loanViewModel.LoanType,
                LoanScheme = loanViewModel.LoanScheme,
                Payments = payments
            };

            return Json(viewModel);
        }

        return BadRequest("Invalid loan type or loan scheme");
    }
}