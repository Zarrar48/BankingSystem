using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.application.DTOs
{
    public class AccountDTO
    {
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public string AccountStatus { get; set; }
    }

}
