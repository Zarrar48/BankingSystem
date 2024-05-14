using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public User User { get; set; }
        public List<CustomerAddress> CustomerAddresses { get; set; }
        public List<Accounts> Accounts { get; set; }
        public List<Loans> Loans { get; set; }
    }

}
