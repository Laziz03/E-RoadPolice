using ERoadPolice.Application.Services;
using ERoadPolice.Domain.Entities;
using ERoadPolice.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ERoadPolice.Infrastructure.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly PoliceRoadDbContext _context;

        public IncidentService(PoliceRoadDbContext context)
        {
            _context = context;
        }

        public async Task<Incident> CreateAsync(Incident entity)
        {
            await _context.Incidents.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            Incident? entity = await _context.Incidents.FindAsync(Id);
            if (entity == null)
                return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            IEnumerable<Incident> incidents = await _context.Incidents.AsNoTracking().ToListAsync();
            return incidents;
        }

        public async Task<Incident> GetByIdAsync(int id)
        {
            Incident? incidentEntity = await _context.Incidents.FindAsync(id);
            return incidentEntity;
        }

        public async Task<bool> UpdateAsync(Incident entity)
        {
            _context.Incidents.Update(entity);
            var executedRows = await _context.SaveChangesAsync();

            return executedRows > 0;
        }
    }
}
