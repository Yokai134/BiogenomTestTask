using Biogenom.Model;

namespace Biogenom.Interface
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> GetUserAsync();
    }
}
