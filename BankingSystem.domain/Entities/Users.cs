using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation properties
        public UserProfile UserProfile { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
