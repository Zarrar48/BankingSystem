using BankingSystem.domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> AuthenticateUser(string username, string password);
    }
}
