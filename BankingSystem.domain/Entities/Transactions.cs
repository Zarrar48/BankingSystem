using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public int TransactionTypeID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime TransactionDate { get; set; }

        // Navigation properties
        public Accounts Account { get; set; }
        public TransactionTypes TransactionType { get; set; }
    }

}
