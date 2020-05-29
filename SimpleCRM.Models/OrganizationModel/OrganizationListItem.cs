using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.OrganizationModel
{
    public class OrganizationListItem
    {
        public int OrganizationId { get; set; }

        [Display(Name = "Organization:")]
        public string OrganizationName { get; set; }
    }
}
