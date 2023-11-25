using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Domain.Entities
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public string? CarNumber { get; set; }
        public decimal ? FineAmount { get; set; }   
        public DateTime DateTime { get; set; }
        public string Address { get; set; }






        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int OfficerId { get; set; }
        public Officer Officer { get; set; }

    }
}
