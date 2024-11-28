using CareerPathCore.Contracts;
using CareerPathCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerPathCore.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly AppDbContext _context;

        public CatalogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EducationLevel>> GetEducationLevels()
        {
            return await _context.EducationLevels.ToListAsync();
        }
    }
}
