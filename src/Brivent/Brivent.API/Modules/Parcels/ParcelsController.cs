using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Brivent.API.Modules.Parcels
{
    [ApiController]
    [Route("api/v1/parcels")]
    public class ParcelsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;

            return Ok();
        }
    }
}
