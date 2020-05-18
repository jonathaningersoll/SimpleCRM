using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data
{
    public enum Status { New=1, Engaged, Donor, FollowUp, Uninterested}
    public enum Role { Owner=1, Manager, Employee, Individual }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public int Organization { get; set; }
        public int Points { get; set; }
        public Status Status { get; set; }
        public int MyProperty { get; set; }
    }
}
