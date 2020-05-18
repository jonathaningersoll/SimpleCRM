using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data
{
    public class Interaction
    {
        public int InteractionId { get; set; }
        public Customer Customer { get; set; }
        public Event Event { get; set; }
        public int InteractionPoints { get; set; }
        public string InteractionNotes { get; set; }
    }
}
