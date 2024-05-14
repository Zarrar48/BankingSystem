using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingSystem.domian.Entities
{
    public class TransactionTypes
    {
        [Key]
        public int TransactionTypeID { get; set; }
        public string TypeName { get; set; }

        // Navigation properties
        public List<Transaction> Transactions { get; set; }
    }

}
