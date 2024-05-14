using BankingSystem.domian.Interfaces;
using BankingSystem.domian.Entities;
using BankingSystem.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

       public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> TransferMoney(int fromAccountId, int toAccountId, decimal amount, string description)
        {
            var fromAccount = _context.Accounts.FirstOrDefault(a => a.AccountID == fromAccountId);
            var toAccount = _context.Accounts.FirstOrDefault(a => a.AccountID == toAccountId);

            if (fromAccount == null || toAccount == null || fromAccount.Balance < amount)
                return false;

            // Perform transaction
            fromAccount.Balance -= amount;
            fromAccount.LastTransactionDate = DateTime.UtcNow; // Update LastTransactionDate
            toAccount.Balance += amount;
            toAccount.LastTransactionDate = DateTime.UtcNow; // Update LastTransactionDate

            var transaction = new Transaction
            {
                AccountID = fromAccountId,
                Amount = -amount,
                Description = description,
                Status = "Completed",
                TransactionDate = DateTime.Now,
                TransactionTypeID = 1 // Assuming 1 is Transfer
            };
            _context.Transactions.Add(transaction);

            var transactionTo = new Transaction
            {
                AccountID = toAccountId,
                Amount = amount,
                Description = description,
                Status = "Completed",
                TransactionDate = DateTime.Now,
                TransactionTypeID = 1 // Assuming 1 is Transfer
            };
            _context.Transactions.Add(transactionTo);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Deposit(int accountId, decimal amount, string description)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountID == accountId);
            if (account == null)
                return false;

            account.Balance += amount;
            account.LastTransactionDate = DateTime.UtcNow; // Update LastTransactionDate

            var transaction = new Transaction
            {
                AccountID = accountId,
                Amount = amount,
                Description = description,
                Status = "Completed",
                TransactionDate = DateTime.Now,
                TransactionTypeID = 2 // 2 is Deposit
            };
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Withdraw(int accountId, decimal amount, string description)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountID == accountId);
            if (account == null || account.Balance < amount)
                return false;

            account.Balance -= amount;
            account.LastTransactionDate = DateTime.UtcNow; // Update LastTransactionDate

            var transaction = new Transaction
            {
                AccountID = accountId,
                Amount = -amount, // Negative because it's a withdrawal
                Description = description,
                Status = "Completed",
                TransactionDate = DateTime.Now,
                TransactionTypeID = 3 // 3 is Withdraw
            };
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionHistory(int accountId)
        {
            return _context.Transactions
                           .Where(t => t.AccountID == accountId)
                           .OrderByDescending(t => t.TransactionDate)
                           .ToList();
        }
    }
}
