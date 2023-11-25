using ERoadPolice.Application.Repositories;
using ERoadPolice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Application.Services
{
    public interface IOfficerService : IRepository<Officer>
    {
        Task<Officer> GetByLoginAsync(string login);
    }
}
