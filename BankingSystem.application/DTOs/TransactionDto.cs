using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.application.DTOs
{
    public class TransactionDto
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
