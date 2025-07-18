using Biogenom.DataTransfer;
using Biogenom.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.Controllers
{
    [ApiController]
    [Route("api/consumption")]
    public class ConsumptionController : ControllerBase
    {
        private readonly IProductConsumptionService _consumptionService;

        public ConsumptionController(IProductConsumptionService consumptionService)
        {
            _consumptionService = consumptionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductConsumptionDataTransfer>>> GetConsumptions()
        {
            try
            {
                var consumptions = await _consumptionService.GetConsumptionsAsync();
                return Ok(consumptions);
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
