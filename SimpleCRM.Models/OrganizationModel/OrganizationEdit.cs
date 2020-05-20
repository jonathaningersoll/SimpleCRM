using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.OrganizationModel
{
    public class OrganizationEdit
    {
        public int OrganizationId { get; set; }
        public string OrgName { get; set; }
        public string OrgAddress { get; set; }
        public string OrgIndustry { get; set; }
    }
}
