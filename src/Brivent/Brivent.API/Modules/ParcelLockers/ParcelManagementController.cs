using System.Threading.Tasks;
using Brivent.Modules.ParcelLockers.Application.ParcelLockerContentManagement;
using Brivent.Modules.ParcelLockers.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Brivent.API.Modules.ParcelLockers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParcelManagementController : ControllerBase
    {
        private readonly IParcelLockersModule _parcelLockersModule;

        public ParcelManagementController(IParcelLockersModule parcelLockersModule)
        {
            _parcelLockersModule = parcelLockersModule;
        }

        public async Task<IActionResult> AddParcel(AddParcelToLockerCommand command)
        {
            await _parcelLockersModule.ExecuteCommandAsync(command);

            return Ok();
        }
    }
}
