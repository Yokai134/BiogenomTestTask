using Biogenom.Data;
using Biogenom.Interface;
using Biogenom.Model;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.Repositories
{
    public class SupplementRepository : BaseRepository<Supplement>, ISupplementRepository
    {
        public SupplementRepository(BiogenomDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Supplement>> GetByUserIdAsync(int userId)
        {
            return await _context.UserSupplements
                .Where(us => us.UserId == userId)
                .Include(us => us.Supplement)
                .Select(us => us.Supplement)
                .ToListAsync();
        }
    }
}
