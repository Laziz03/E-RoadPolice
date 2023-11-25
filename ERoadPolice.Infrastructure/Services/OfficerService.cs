using ERoadPolice.Application.Services;
using ERoadPolice.Domain.Entities;
using ERoadPolice.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ERoadPolice.Infrastructure.Services
{
    public class OfficerService : IOfficerService
    {
        private readonly PoliceRoadDbContext _context;

        public OfficerService(PoliceRoadDbContext context)
        {
            _context = context;
        }

        public async Task<Officer> CreateAsync(Officer entity)
        {
            await _context.Officers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
          Officer  ? entity = await _context.Officers.FindAsync(Id);
            if (entity == null)
                return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Officer>> GetAllAsync()
        {
            IEnumerable<Officer> officers = _context.Officers.AsNoTracking().AsEnumerable();
            return await Task.FromResult(officers);

        }

        public async Task<Officer> GetByIdAsync(int id)
        {
            Officer? officerEntity = await _context.Officers.FindAsync(id);
            return officerEntity;
        }

        public Task<Officer> GetByLoginAsync(string login)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Officer entity)
        {
            _context.Officers.Update(entity);
            var executedRows = await _context.SaveChangesAsync();

            return executedRows > 0;
        }
    }
}
