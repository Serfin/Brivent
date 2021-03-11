using System;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Application.Parcels;
using Brivent.Modules.Parcels.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brivent.API.Modules.Parcels
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParcelsController : ControllerBase
    {
        private readonly IParcelsModule _parcelsModule;

        public ParcelsController(IParcelsModule parcelsModule)
        {
            _parcelsModule = parcelsModule;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CreateParcelCommand createParcelCommand)
        {
            var parcelId = await _parcelsModule.ExecuteCommandAsync(createParcelCommand);

            return Ok(parcelId);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ParcelDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetParcelQuery getParcelQuery)
        {
            var parcel = await _parcelsModule.ExecuteQueryAsync(getParcelQuery);

            if (parcel is null)
            {
                return NotFound();
            }

            return Ok(parcel);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Patch([FromRoute] UpdateParcelCommand updateParcelCommand)
        {
            await _parcelsModule.ExecuteCommandAsync(updateParcelCommand);

            return Ok();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] DeleteParcelCommand deleteParcelCommand)
        {
            await _parcelsModule.ExecuteCommandAsync(deleteParcelCommand);

            return Ok();
        }
    }
}
