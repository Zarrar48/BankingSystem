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
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Address> GetAddressById(int id)
        {
            return await _context.Address.FindAsync(id);
        }

        public async Task AddAddress(Address address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            _context.Address.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddress(Address address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            var existingAddress = await _context.Address.FindAsync(address.AddressID);
            if (existingAddress == null) throw new InvalidOperationException("Address not found.");
            _context.Entry(existingAddress).CurrentValues.SetValues(address);
            await _context.SaveChangesAsync();
        }

    }
}
