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
        [Display(Name = "First Name")]
        public string CustFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string CustLastName { get; set; }

        [Display(Name= "Organization")]
        public int? OrganizationId { get; set; }
        public Role Role { get; set; }
        public int? Points { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
