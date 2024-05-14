using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Entities
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        // Navigation properties
        public List<UserProfile> UserProfiles { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
