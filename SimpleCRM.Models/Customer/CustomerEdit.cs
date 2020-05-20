using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.Customer
{
    class CustomerEdit
    {
        public int CustId { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }

        [ForeignKey("OrganizationId")]
        public int? OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public int? Points { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
