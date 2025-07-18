using Biogenom.DataTransfer;

namespace Biogenom.Interface
{
    public interface IUserService
    {
        Task<UserDataTransfer> GetUserDataTransferAsync();
    }
}
