using Biogenom.DataTransfer;
using Biogenom.Interface;

namespace Biogenom.Services
{
    public class SupplementService : ISupplementService
    {
        private readonly ISupplementRepository _supplementRepository;
        private readonly IUserRepository _userRepository;

        public SupplementService(
            ISupplementRepository supplementRepository,
            IUserRepository userRepository)
        {
            _supplementRepository = supplementRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<SupplementDataTransfer>> GetSupplementsAsync()
        {
            var user = await _userRepository.GetUserAsync();
            if (user == null)
            {
                throw new KeyNotFoundException("Пользователь не найден");
            }

            var supplements = await _supplementRepository.GetByUserIdAsync(user.Id);

            return supplements.Select(s => new SupplementDataTransfer
            {
                Id = s.Id,
                Name = s.NameSupplements
            });
        }
    }
}
