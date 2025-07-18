using Biogenom.DataTransfer;
using Biogenom.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.Controllers
{
    [ApiController]
    [Route ("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDataTransfer>> GetUserProfile()
        {
            try
            {
                var userProfile = await _userService.GetUserDataTransferAsync();
                return Ok(userProfile);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Произошла ошибка при обработке запроса");
            }
        }
    }
}
