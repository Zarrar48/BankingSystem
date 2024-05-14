using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Entities
{
    public class CustomerAddress
    {

        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public string AddressType { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }

}
