using System;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brivent.API.Modules.Parcels
{
    [ApiController]
    [Route("api/v1/parcels")]
    public class ParcelsController : ControllerBase
    {
        private readonly IMediator _mediatoR;

        public ParcelsController(IMediator mediatoR)
        {
            _mediatoR = mediatoR;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateParcelCommand createParcelCommand)
            => Ok(await _mediatoR.Send(createParcelCommand));

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetParcelQuery getParcelQuery)
            => Ok(await _mediatoR.Send(getParcelQuery));
    }
}
