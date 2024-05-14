using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingSystem.domian.Entities
{
    public class Accounts
    {
        [Key]
        public int AccountID { get; set; }
        public int CustomerID { get; set; }
        public decimal Balance { get; set; }
        public string AccountStatus { get; set; }
        public DateTime? LastTransactionDate { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public List<Transaction> Transactions { get; set; }
    }

}
