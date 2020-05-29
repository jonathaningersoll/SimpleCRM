using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.EventModel
{
    public class EventListItem
    {
        public int EventId { get; set; }

        [Display(Name = "Event Name:")]
        public string EventName { get; set; }
    }
}
