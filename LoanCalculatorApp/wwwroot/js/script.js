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

        if (amount && years && loanType && loanScheme) {
            calculateLoan(amount, years, loanType, loanScheme);
        } else {
            clearTable();
        }
    }

    function clearTable() {
        document.getElementById("monthlyPayment").innerText = "";
        const tableBody = document.getElementById("paymentTable");
        tableBody.innerHTML = "";
    }

    loanTypeSelect.addEventListener("change", checkAndSubmitForm);
    loanSchemeSelect.addEventListener("change", checkAndSubmitForm);
    amountInput.addEventListener("input", checkAndSubmitForm);
    yearsInput.addEventListener("input", function() {
        // Remove non-numeric characters and ensure only whole numbers up to 100 years
        yearsInput.value = yearsInput.value.replace(/[^0-9]/g, '');
        if (parseInt(yearsInput.value, 10) > 100) {
            yearsInput.value = 100;
        }
        checkAndSubmitForm();
    });

    function calculateLoan(amount, years, loanType, loanScheme) {
        fetch('/Home/Calculate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ Amount: amount, Years: years, LoanType: loanType, LoanScheme: loanScheme })
        })
            .then(response => response.json())
            .then(data => {
                document.getElementById("monthlyPayment").innerText = data.monthlyPayment.toFixed(2);
                
                const tableBody = document.getElementById("paymentTable");
                tableBody.innerHTML = "";
                data.payments.forEach(payment => {
                    const row = tableBody.insertRow();
                    row.insertCell(0).innerText = payment.month;
                    row.insertCell(1).innerText = payment.principal.toFixed(2);
                    row.insertCell(2).innerText = payment.interest.toFixed(2);
                    row.insertCell(3).innerText = payment.totalPayment.toFixed(2);
                });
            });
    }
    checkAndSubmitForm();
});
