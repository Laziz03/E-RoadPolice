using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Domain.Entities
{
    public class Officer
    {
        public int OfficerId { get; set; }
        public string FullName { get; set; }
        public string BadgeNumber { get; set; }
        public string Login {get;set; }
        public string Password { get; set; }
     
        public ICollection<Incident> Incidents { get; set; }
    }
}


