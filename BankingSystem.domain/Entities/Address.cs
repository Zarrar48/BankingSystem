using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.domian.Entities
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        // Navigation properties
        public List<CustomerAddress> CustomerAddresses { get; set; }
    }

}
