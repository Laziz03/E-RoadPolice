using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Domain.Entities
{
    public  class RefreshToken
    {
        public int Id { get; set; }
        public int DriverId {  get; set; }  

        public Driver Driver { get; set; }
        public string RefreshTokenValue { get; set; }
        public DateTime ExpireTime { get; set; }
        public int DriverIds { get; set; }
    }
}
