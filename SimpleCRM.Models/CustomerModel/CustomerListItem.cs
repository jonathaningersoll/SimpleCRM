using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.CustomerModel
{
    public class CustomerListItem
    {
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerFullName { get; set; }

        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }
        public int? Points { get; set; }
        public Status Status { get; set; }
    }
}
