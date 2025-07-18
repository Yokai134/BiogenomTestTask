using Biogenom.Data;
using Biogenom.Interface;
using Biogenom.Model;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.Repositories
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        public UserRepository(BiogenomDbContext context) : base(context)
        {
        }

        public async Task<Users> GetUserAsync()
        {
            return await _context.Users
                .Include(u => u.UserActivities)
                    .ThenInclude(ua => ua.ActivityLevel)
                .Include(u => u.ProductConsumptions)
                    .ThenInclude(pc => pc.ProductType)
                        .ThenInclude(pt => pt.Category)
                .Include(u => u.ProductConsumptions)
                    .ThenInclude(pc => pc.Frequency)
                .Include(u => u.ProductConsumptions)
                    .ThenInclude(pc => pc.AmountUnit)
                .Include(u => u.UserSupplements)
                    .ThenInclude(us => us.Supplement)
                .FirstOrDefaultAsync();
        }
    }
}
