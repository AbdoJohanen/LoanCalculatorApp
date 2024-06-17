export function calculateLoan(amount, years, loanType, loanScheme) {
    fetch('/Home/Calculate', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ Amount: amount, Years: years, LoanType: loanType, LoanScheme: loanScheme })
    })
    .then(response => response.json())
    .then(data => {
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
