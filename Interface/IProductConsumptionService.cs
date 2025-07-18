using Biogenom.DataTransfer;

namespace Biogenom.Interface
{
    public interface IProductConsumptionService
    {
        Task<IEnumerable<ProductConsumptionDataTransfer>> GetConsumptionsAsync();
    }
}
