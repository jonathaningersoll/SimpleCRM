using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data
{
    public class Interaction
    {
        [Required]
        public int InteractionId { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [ForeignKey("EventId")]
        public int? EventId { get; set; }
        public virtual Event Event { get; set; }

        [Display(Name = "Point Value")]
        public int InteractionPointValue { get; set; }

        [Display(Name = "Notes")]
        public string InteractionNotes { get; set; }
    }
}
