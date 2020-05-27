using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.CustomerModel
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string OrganizationName { get; set; }
        public Role Role { get; set; }
        public int? Points { get; set; }
        public Status Status { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
