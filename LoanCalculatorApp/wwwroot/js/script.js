import { calculateLoan } from './loanCalculator.js';

document.addEventListener("DOMContentLoaded", function() {
    const form = document.getElementById("loanForm");
    const amountInput = document.getElementById("amount");
    const yearsInput = document.getElementById("years");
    const loanTypeSelect = document.getElementById("loanType");
    const loanSchemeSelect = document.getElementById("loanScheme");

    function checkAndSubmitForm() {
        const amount = amountInput.value;
        const years = yearsInput.value;
        const loanType = loanTypeSelect.value;
        const loanScheme = loanSchemeSelect.value;

        if (amount && years && loanType && loanScheme && years != 0) {
            calculateLoan(amount, years, loanType, loanScheme);
        } else {
            clearTable();
        }
    }

    function clearTable() {
        document.getElementById("paymentTable").innerHTML = "";
    }

    loanTypeSelect.addEventListener("change", checkAndSubmitForm);
    loanSchemeSelect.addEventListener("change", checkAndSubmitForm);
    
    amountInput.addEventListener("input", function() {
        // Ensure only numeric values and set a maximum limit for loan amount
        amountInput.value = amountInput.value.replace(/[^0-9]/g, '');
        if (parseInt(amountInput.value, 10) > 10000000) {
            amountInput.value = 10000000;
        }
        checkAndSubmitForm();
    });

    yearsInput.addEventListener("input", function() {
        // Ensure only numeric values and set a maximum limit for years
        yearsInput.value = yearsInput.value.replace(/[^0-9]/g, '');
        if (parseInt(yearsInput.value, 10) > 100) {
            yearsInput.value = 100;
        }
        checkAndSubmitForm();
    });

    checkAndSubmitForm();
});
