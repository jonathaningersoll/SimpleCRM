using SimpleCRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.InteractionModel
{
    public class InteractionListItem
    {
        public int InteractionId { get; set; }

        public int CustomerId { get; set; }

        [Display(Name ="Customer:")]
        public string CustomerFullName { get; set; }

        public int? EventId { get; set; }

        [Display(Name ="Event:")]
        public string EventName { get; set; }
    }
}
