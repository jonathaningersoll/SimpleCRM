using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.OrganizationModel
{
    public class OrganizationCreate
    {
        [Display(Name = "Organization:")]
        public string OrganizationName { get; set; }
        
        [Display(Name = "Location:")]
        public string OrganizationAddress { get; set; }

        [Display(Name = "Industry:")]
        public string OrganizationIndustry { get; set; }
    }
}
