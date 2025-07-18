using Biogenom.DataTransfer;
using Biogenom.Interface;

namespace Biogenom.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDataTransfer> GetUserDataTransferAsync()
        {
            var user = await _userRepository.GetUserAsync();

            if (user == null)
            {
                throw new KeyNotFoundException("Пользователь не найден");
            }

            var activityLevel = user.UserActivities.FirstOrDefault()?.ActivityLevel?.NameLevels;

            return new UserDataTransfer
            {
                Id = user.Id,
                FullName = $"{user.LastName} {user.FirstName} {user.PatronomycName}".Trim(),
                BirthDate = user.BirthDate,
                Height = user.Height,
                Weight = user.Weight,
                ActivityLevel = activityLevel
            };
        }
    }
}
