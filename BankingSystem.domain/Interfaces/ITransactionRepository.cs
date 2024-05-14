using BankingSystem.domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Interfaces
{
    public interface ITransactionRepository
    {
        Task<bool> TransferMoney(int fromAccountId, int toAccountId, decimal amount, string description);
        Task<bool> Deposit(int accountId, decimal amount, string description);
        Task<bool> Withdraw(int accountId, decimal amount, string description);
        Task<IEnumerable<Transaction>> GetTransactionHistory(int accountId);

    }
}
