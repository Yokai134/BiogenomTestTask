using Biogenom.DataTransfer;

namespace Biogenom.Interface
{
    public interface ISupplementService
    {
        Task<IEnumerable<SupplementDataTransfer>> GetSupplementsAsync();
    }
}
