using ERoadPolice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Domain.Models.DriverDTO
{
    public class DriverBaseDTO
    {
        public string FullName { get; set; }
        public string LicenseNumber { get; set; }
        public IEnumerable<int> Incidents { get; set; }
    }
}
