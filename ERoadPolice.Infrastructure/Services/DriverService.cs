using ERoadPolice.Application.Services;
using ERoadPolice.Domain.Entities;
using ERoadPolice.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ERoadPolice.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly PoliceRoadDbContext _context;
            
        public DriverService(PoliceRoadDbContext context)
        {
            _context = context;
        }

        public async Task<Driver> CreateAsync(Driver entity)
        {
           await _context.Drivers.AddAsync(entity); 
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            Driver? entity = await _context.Drivers.FindAsync(Id);
            if (entity == null)
                return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<Driver>> GetAllAsync()
        {
            IEnumerable<Driver> drivers = _context.Drivers.AsNoTracking().AsEnumerable();
            return Task.FromResult(drivers);
        }

        public async Task<Driver?> GetByIdAsync(int id)
        {
            Driver? driverEntity = await _context.Drivers.FindAsync(id);
            return driverEntity;
        }

        public async Task<bool> UpdateAsync(Driver entity)
        {
            _context.Drivers.Update(entity);
            var executedRows = await _context.SaveChangesAsync();

            return executedRows > 0;
        }
    }
}
