using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.EventModel
{
    public class EventCreate
    {
        public DateTimeOffset EventStartTime { get; set; }
        public DateTimeOffset EventEndTime { get; set; }
        public string EventName { get; set; }
        public string EventTopic { get; set; }
    }
}
