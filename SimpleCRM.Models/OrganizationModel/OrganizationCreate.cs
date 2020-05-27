using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.OrganizationModel
{
    public class OrganizationCreate
    {
        public string OrganizationName { get; set; }
        public string OrganizationAddress { get; set; }
        public string OrganizationIndustry { get; set; }
    }
}
