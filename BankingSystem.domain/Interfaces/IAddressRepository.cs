using BankingSystem.domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressById(int id);
        Task AddAddress(Address address);
        Task UpdateAddress(Address address);
    }
}
