using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.InteractionModel
{
    public class InteractionCreate
    {
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? EventId { get; set; }
        public Event Event { get; set; }

        public int PointValue { get; set; }
        public string InteractionNotes { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
