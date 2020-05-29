using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.InteractionModel
{
    public class InteractionEdit
    {
        public int InteractionId { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Customer:")]
        public string CustomerFullName { get; set; }

        public int EventId { get; set; }

        [Display(Name = "Event:")]
        public string EventName { get; set; }

        [Display(Name = "Points to Award:")]
        public int InteractionPointValue { get; set; }

        [Display(Name = "Interaction Notes:")]
        public string InteractionNotes { get; set; }
    }
}
