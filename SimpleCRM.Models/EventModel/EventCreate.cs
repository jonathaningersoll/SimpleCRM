using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.EventModel
{
    public class EventCreate
    {
        [Display(Name ="00/00/0000 00:00:00")]
        public DateTimeOffset EventStartTime { get; set; }
        [Display(Name = "00/00/0000 00:00:00")]
        public DateTimeOffset EventEndTime { get; set; }
        public string EventName { get; set; }
        public string EventTopic { get; set; }
    }
}
