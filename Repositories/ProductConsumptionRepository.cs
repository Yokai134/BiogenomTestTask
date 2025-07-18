using Biogenom.Data;
using Biogenom.Interface;
using Biogenom.Model;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.Repositories
{
    public class ProductConsumptionRepository : BaseRepository<ProductConsumption>, IProductConsumptionRepository
    {
        public ProductConsumptionRepository(BiogenomDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductConsumption>> GetByUserIdAsync(int userId)
        {
            return await _context.ProductConsumptions
                .Where(pc => pc.UserId == userId)
                .Include(pc => pc.ProductType)
                    .ThenInclude(pt => pt.Category)
                .Include(pc => pc.Frequency)
                .Include(pc => pc.AmountUnit)
                .ToListAsync();
        }
    }
}
