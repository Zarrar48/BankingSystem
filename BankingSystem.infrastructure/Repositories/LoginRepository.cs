using BankingSystem.domian.Interfaces;
using BankingSystem.domian.Entities;
using BankingSystem.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            var hashedPassword = HashPassword(password);
            return await _context.Users
                                 .Where(u => u.Email == email && u.PasswordHash == hashedPassword)
                                 .FirstOrDefaultAsync();
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);

        }
    }

}
