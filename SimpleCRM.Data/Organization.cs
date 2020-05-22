using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data
{
    public class Organization
    {
        [Required]
        [Key]
        public int OrganizationId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }
        public string OrganizationAddress { get; set; }
        public string OrganizationIndustry { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
