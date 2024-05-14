using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Entities
{
    public class UserRole
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Roles Role { get; set; }
    }
}
