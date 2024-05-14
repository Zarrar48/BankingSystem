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
    public class UserProfileRepository : IUserProfileRepository
    {

        private readonly ApplicationDbContext _context;
        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserProfile> GetUserProfileById(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        //public async Task<IEnumerable<User>> GetAllUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}
       
        public async Task AddUserProfile(UserProfile userProfile, string roleName)
        {
            if (userProfile == null)
                throw new ArgumentNullException(nameof(userProfile));

            // Resolve RoleID from RoleName
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName.ToLower() == roleName.ToLower());

            if (role == null)
                throw new ArgumentException("Invalid role name.");

            int roleId = role.RoleID;
            userProfile.RoleID = roleId;


            var existingProfile = await _context.UserProfiles.FindAsync(userProfile.UserID);
            if (existingProfile != null)
                throw new InvalidOperationException("A profile already exists for this user.");

            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateUserProfile(UserProfile userProfile, string roleName)
        {
            if (userProfile == null)
                throw new ArgumentNullException(nameof(userProfile));

            // Resolve RoleID from RoleName
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName.ToLower() == roleName.ToLower());

            if (role == null)
                throw new ArgumentException("Invalid role name.");

            int roleId = role.RoleID;

            var existingProfile = await _context.UserProfiles.FindAsync(userProfile.UserID);
            if (existingProfile == null)
                throw new InvalidOperationException("User profile not found.");

            existingProfile.FirstName = userProfile.FirstName;
            existingProfile.LastName = userProfile.LastName;
            existingProfile.PhoneNumber = userProfile.PhoneNumber;
            existingProfile.RoleID = roleId;
            existingProfile.LastLogin = userProfile.LastLogin;

            _context.UserProfiles.Update(existingProfile);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteUserProfile(int id)
        {
            var user = await _context.UserProfiles.FindAsync(id);
            if (user != null)
            {
                _context.UserProfiles.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
