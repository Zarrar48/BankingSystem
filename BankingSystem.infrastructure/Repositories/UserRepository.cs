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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Check if the email already exists in the database
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
                throw new ArgumentException("A user with the given email already exists.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Retrieve the user from the database
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
            if (existingUser == null)
                throw new InvalidOperationException("User not found.");

            // Update properties
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.UserProfile = user.UserProfile;
            existingUser.Customers = user.Customers; // Handle with care, especially if you have a large or complex graph

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }

}
