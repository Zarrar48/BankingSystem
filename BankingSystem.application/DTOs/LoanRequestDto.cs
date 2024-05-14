using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.application.DTOs
{
    public class LoanRequestDto
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

}
