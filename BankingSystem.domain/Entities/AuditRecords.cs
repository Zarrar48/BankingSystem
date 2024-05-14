using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Entities
{
    public class AuditRecords
    {
        [Key]
        public int AuditID { get; set; }
        public string TableName { get; set; }
        public int RecordID { get; set; }
        public string OperationType { get; set; }  // e.g., INSERT, UPDATE, DELETE
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
