using BankingSystem.domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Interfaces
{
    public interface ICustomerAddressRepository
    {
        Task<CustomerAddress> GetCustomerAddressByID(int id);

        Task AddCustomerAddress(CustomerAddress customerAddress);

        Task UpdateCustomerAddress(CustomerAddress customerAddress);
    }
}
