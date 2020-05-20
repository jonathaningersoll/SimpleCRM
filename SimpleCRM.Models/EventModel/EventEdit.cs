using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.EventModel
{
    public class EventEdit
    {
        public int EventId { get; set; }
        public DateTimeOffset EventStartTime { get; set; }
        public DateTimeOffset EventEndTime { get; set; }

        [Display(Name = "Event Title")]
        public string EventName { get; set; }

        [Display(Name = "Topic")]
        public string EventTopic { get; set; }
    }
}
