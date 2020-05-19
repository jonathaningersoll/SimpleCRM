using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public DateTimeOffset EventStartTime { get; set; }

        [Required]
        public DateTimeOffset EventEndTime { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        public string EventName { get; set; }

        [Display(Name = "Topic")]
        public string EventTopic { get; set; }
    }
}
