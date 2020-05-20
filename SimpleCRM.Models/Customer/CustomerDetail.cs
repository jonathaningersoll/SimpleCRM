using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.Customer
{
    public class CustomerDetail
    {
        public int CustId { get; set; }
        public string CustFullName { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public Role Role { get; set; }
        public int? Points { get; set; }
        public Status Status { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
