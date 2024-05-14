
using BankingSystem.domian.Entities;
using BankingSystem.domian.Interfaces;
using BankingSystem.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Accounts> GetAccountById(int accountId)
        {
            return await _context.Accounts.FindAsync(accountId);
        }

        public async Task<IEnumerable<Accounts>> GetAccountsByCustomerId(int customerId)
        {
            return await _context.Accounts.Where(a => a.CustomerID == customerId).ToListAsync();
        }

        public async Task AddAccount(Accounts account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccount(Accounts account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _context.Customers
                                 .Where(c => c.User.Email == email)
                                 .FirstOrDefaultAsync();
        }
    }
}
