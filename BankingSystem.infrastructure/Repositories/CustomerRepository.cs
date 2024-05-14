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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            // Consider using AsNoTracking if updates are not needed after retrieving
            return await _context.Customers
                                 .Include(c => c.CustomerAddresses) // Load related data as necessary
                                 .Include(c => c.Accounts)
                                 .FirstOrDefaultAsync(c => c.CustomerID == id);
        }

        public async Task AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var existingCustomer = await _context.Customers.FindAsync(customer.CustomerID);
            if (existingCustomer == null)
                throw new InvalidOperationException("Customer not found.");

            _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

    }
}
