﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Models.EventModel
{
    public class EventCreate
    {
        [Display(Name ="Event Start:")]
        public DateTimeOffset EventStartTime { get; set; }

        [Display(Name = "Event End:")]
        public DateTimeOffset EventEndTime { get; set; }

        [Display(Name = "Event Title:")]
        public string EventName { get; set; }

        [Display(Name = "Event Topic:")]
        public string EventTopic { get; set; }
    }
}
