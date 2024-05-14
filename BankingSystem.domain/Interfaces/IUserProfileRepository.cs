using BankingSystem.domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> GetUserProfileById(int id);
        Task AddUserProfile(UserProfile user,string roleName);
        Task UpdateUserProfile(UserProfile user,string roleName);
        Task DeleteUserProfile(int id);
    }
}
