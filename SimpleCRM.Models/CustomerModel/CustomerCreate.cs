using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.CustomerModel
{
    public class CustomerCreate
    {
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public Role Role { get; set; }
        public int? Points { get; set; }
        [Required]
        public Status Status { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
