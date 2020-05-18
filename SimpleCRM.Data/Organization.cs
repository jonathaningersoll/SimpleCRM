using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data
{
    public class Organization
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string Address { get; set; }
        public string Industry { get; set; }
    }
}
