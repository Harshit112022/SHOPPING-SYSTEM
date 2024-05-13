using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModel
{
    public class Customer
    {
        public int CustomerId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }
        public string PhoneNumber
        {
            get; set;
        }
        public bool IsActive
        {
            get; set;
        }
        public string CreatedBy
        {
            get; set;
        }
        public DateTime CreatedOn
        {
            get; set;
        }
        public string LastLastModifiedBy
        {
            get; set;
        }
        public DateTime LastModifiedOn
        {
            get; set;
        }
    }
}
