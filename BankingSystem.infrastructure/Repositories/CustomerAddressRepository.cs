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
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerAddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerAddress> GetCustomerAddressByID(int id)
        {
            return await _context.CustomerAddresses.FindAsync(id);
        }

        public async Task AddCustomerAddress(CustomerAddress customerAddress)
        {
            _context.CustomerAddresses.Add(customerAddress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAddress(CustomerAddress customerAddress)
        {
            _context.CustomerAddresses.Update(customerAddress);
            await _context.SaveChangesAsync();
        }
    }
}
