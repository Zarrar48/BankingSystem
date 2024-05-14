using BankingSystem.domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Interfaces
{
    public interface ILoanRepository
    {
        Task<bool> CreateLoan(int customerId, decimal amount);
        Task<bool> RepayLoan(int loanId,decimal paymentAmount);
        Task RepayMultipleLoans(Dictionary<int, decimal> payments);

        Task<Loans> GetCurrentLoan(int customerId);  // Get the current active loan for a customer
        Task<List<Loans>> GetLoanHistory(int customerId);  // Get the historical loans for a customer
    }
}
