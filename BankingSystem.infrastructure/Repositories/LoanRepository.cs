using BankingSystem.domian.Interfaces;
using BankingSystem.domian.Entities;
using BankingSystem.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

       public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateLoan(int customerId, decimal amount)
        {
            if (amount > 1000)
            {
                throw new ArgumentException("Loan amount cannot exceed $1000.");
            }

            // Calculate the total current loan amount for this customer
            var totalLoans = _context.Loans.Where(l => l.CustomerID == customerId && l.Status == "Active").Sum(l => l.LoanAmount);

            if (totalLoans + amount > 1000)
            {
                throw new InvalidOperationException("Total loan amount exceeds the limit of $1000 for the customer.");
            }

            var loan = new Loans
            {
                CustomerID = customerId,
                LoanAmount = amount,
                StartDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(7),  // Due in one week
                Status = "Active",
                Fine = 0,
                RepaymentAmount = amount  // No interest
            };

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RepayLoan(int loanId, decimal paymentAmount)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(l => l.LoanID == loanId && l.Status == "Active");
            if (loan == null)
            {
                throw new ArgumentException("Loan not found or is already repaid.");
            }

            if (paymentAmount > loan.RepaymentAmount)
            {
                throw new ArgumentException("Payment exceeds the total loan due amount.");
            }

            // Apply payment
            loan.RepaymentAmount -= paymentAmount;

            // If fully paid, update status and preserve the history
            if (loan.RepaymentAmount == 0)
            {
                loan.Status = "Repaid";
                _context.Update(loan);
                _context.Remove(loan);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task RepayMultipleLoans(Dictionary<int, decimal> payments)
        {
            foreach (var payment in payments)
            {
                int loanId = payment.Key;
                decimal paymentAmount = payment.Value;

                // This uses the single loan repayment logic
                await RepayLoan(loanId, paymentAmount);
            }
        }


        public async Task<Loans> GetCurrentLoan(int customerId)
        {
            return await _context.Loans
                                 .Where(l => l.CustomerID == customerId && l.Status == "Active")
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Loans>> GetLoanHistory(int customerId)
        {
            // Assuming Loans is a system-versioned temporal table
            // Adjust the query to access the historical data appropriately depending on your DB setup
            return await _context.Loans
                                 .FromSqlInterpolated($"SELECT * FROM LoansHistory WHERE CustomerID = {customerId} AND Status = 'Repaid'")
                                 .ToListAsync();
        }

    }
}
