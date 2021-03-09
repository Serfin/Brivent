using System;
using System.Threading.Tasks;
using Brivent.Modules.ParcelLockers.Application.ParcelLockers;
using Brivent.Modules.ParcelLockers.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brivent.API.Modules.ParcelLockers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParcelLockersController : ControllerBase
    {
        private readonly IParcelLockersModule _parcelLockersModeule;

        public ParcelLockersController(IParcelLockersModule parcelLockersModeule)
        {
            _parcelLockersModeule = parcelLockersModeule;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] CreateParcelLockerCommand command)
        {
            var parcelLockerId = await _parcelLockersModeule.ExecuteCommandAsync(command);

            return Ok(parcelLockerId);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ParcelLockerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetParcelLockerQuery query)
        {
            var parcelLockerDto = await _parcelLockersModeule.ExecuteQueryAsync(query);

            if (parcelLockerDto is null)
            {
                return NotFound();
            }

            return Ok(parcelLockerDto);
        }
    }
}
