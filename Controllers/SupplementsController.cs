using Biogenom.DataTransfer;
using Biogenom.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.Controllers
{
    [ApiController]
    [Route("api/supplements")]
    public class SupplementsController : ControllerBase
    {
        private readonly ISupplementService _supplementService;

        public SupplementsController(ISupplementService supplementService)
        {
            _supplementService = supplementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplementDataTransfer>>> GetSupplements()
        {
            try
            {
                var supplements = await _supplementService.GetSupplementsAsync();
                return Ok(supplements);
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
