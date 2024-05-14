using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.application.DTOs
{
    public class UserManagementDTO
    {
        // User information
        public string Password { get; set; }
        public string Email { get; set; }

        // UserProfile information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }

        // Customer information
        public DateTime DateOfBirth { get; set; }
        public string CustomerStatus { get; set; }
    }
}
