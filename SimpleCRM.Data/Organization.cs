﻿using System;
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
        public int OrgId { get; set; }

        [Required]
        [Display(Name = "Organization Name")]
        public string OrgName { get; set; }
        public string OrgAddress { get; set; }
        public string OrgIndustry { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
