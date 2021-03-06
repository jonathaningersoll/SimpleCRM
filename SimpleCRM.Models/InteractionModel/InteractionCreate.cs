﻿using SimpleCRM.Data;
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

        public int InteractionId { get; set; }

        [Display(Name ="Customer Name:")]
        public int CustomerId { get; set; }

        [Display(Name = "Event Name:")]
        public int EventId { get; set; }

        [Display(Name = "Point Value:")]
        public int PointValue { get; set; }

        [Display(Name = "Interaction Notes:")]
        public string InteractionNotes { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
