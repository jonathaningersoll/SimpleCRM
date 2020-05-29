using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.CustomerModel
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }

        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }

        public int? Points { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
