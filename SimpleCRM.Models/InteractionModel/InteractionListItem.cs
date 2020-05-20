using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.InteractionModel
{
    public class InteractionListItem
    {
        public int InteractionId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
