using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Entities
{
    public class Loans
    {
        [Key]
        public int LoanID { get; set; }
        public int CustomerID { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Fine { get; set; }
        public decimal RepaymentAmount { get; set; }
        public string Status { get; set; }
    }

}
