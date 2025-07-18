using Biogenom.Model;

namespace Biogenom.Interface
{
    public interface IProductConsumptionRepository : IRepository<ProductConsumption>
    {
        Task<IEnumerable<ProductConsumption>> GetByUserIdAsync(int userId);
    }
}
