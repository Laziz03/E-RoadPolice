using AutoMapper;
using ERoadPolice.Domain.Entities;
using ERoadPolice.Domain.Models.OfficerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Application
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Officer,OfficerBaseDTO>();  

        }
    }
}
