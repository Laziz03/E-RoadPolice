using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Domain.Models.OfficerDTO
{
    public class OfficerBaseDTO
    {
        public string FullName { get; set; }
        public string BadgeNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
