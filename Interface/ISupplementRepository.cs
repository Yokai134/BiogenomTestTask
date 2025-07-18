using Biogenom.Model;

namespace Biogenom.Interface
{
    public interface ISupplementRepository : IRepository<Supplement>
    {
        Task<IEnumerable<Supplement>> GetByUserIdAsync(int userId);
    }
}
