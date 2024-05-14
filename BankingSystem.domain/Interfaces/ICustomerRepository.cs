using BankingSystem.domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
