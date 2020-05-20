using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.InteractionModel
{
    public class InteractionEdit
    {
        public int InteractionId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int InteractionPointValue { get; set; }
        public string InteractionNotes { get; set; }
    }
}
