using Biogenom.DataTransfer;
using Biogenom.Interface;

namespace Biogenom.Services
{
    public class ProductConsumptionService : IProductConsumptionService
    {
        private readonly IProductConsumptionRepository _consumptionRepository;
        private readonly IUserRepository _userRepository;

        public ProductConsumptionService(
            IProductConsumptionRepository consumptionRepository,
            IUserRepository userRepository)
        {
            _consumptionRepository = consumptionRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ProductConsumptionDataTransfer>> GetConsumptionsAsync()
        {
            var user = await _userRepository.GetUserAsync();
            if (user == null)
            {
                throw new KeyNotFoundException("Пользователь не найден");
            }

            var consumptions = await _consumptionRepository.GetByUserIdAsync(user.Id);

            return consumptions.Select(pc => new ProductConsumptionDataTransfer
            {
                Id = pc.Id,
                ProductName = pc.ProductType.NameProduct,
                Category = pc.ProductType.Category.NameCategories,
                Frequency = pc.Frequency.NameFrequencies,
                Amount = pc.Amount,
                Unit = pc.AmountUnit.NameUnit
            });
        }
    }
}
