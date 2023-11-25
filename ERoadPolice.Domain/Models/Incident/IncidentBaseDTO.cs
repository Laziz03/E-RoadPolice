using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Domain.Models.Incident
{
    public class IncidentBaseDTO
    {
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }
    }
}
