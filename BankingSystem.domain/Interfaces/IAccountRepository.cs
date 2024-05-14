using BankingSystem.domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Interfaces
{
    public interface IAccountRepository
    {
        Task<Accounts> GetAccountById(int accountId);
        Task<IEnumerable<Accounts>> GetAccountsByCustomerId(int customerId);
        Task AddAccount(Accounts account);
        Task UpdateAccount(Accounts account);
        Task<Customer> GetCustomerByEmail(string email);
    }
}
