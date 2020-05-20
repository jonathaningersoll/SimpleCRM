using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.CustomerModel
{
    public class CustomerListItem
    {
        public int CustId { get; set; }
        public string FullName { get; set; }
        public int Points { get; set; }
        public Status Status { get; set; }
    }
}
