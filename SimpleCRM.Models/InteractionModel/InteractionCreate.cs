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
        //maybe removable
        public int InteractionId { get; set; }

        [Display(Name ="Customer Name")]
        public int CustomerId { get; set; }

        [Display(Name = "Event Name")]
        public int EventId { get; set; }

        public int PointValue { get; set; }
        public string InteractionNotes { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
