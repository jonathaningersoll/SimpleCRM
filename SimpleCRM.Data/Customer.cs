using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data
{
    public enum Status { New=1, Engaged, Donor, FollowUp, Uninterested}
    public enum Role { Owner=1, Manager, Employee, Individual }
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public string CustFirstName { get; set; }

        [Required]
        public string CustLastName { get; set; }

        public string CustFullname { 
            get
            {
                return CustFirstName + CustLastName;
            }
         }

        [ForeignKey("Organization")]
        public int? OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }


        public int? Points { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
