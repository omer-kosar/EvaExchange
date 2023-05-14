using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace EvaExchange.API.Controllers
{
    [Route("api/shares")]
    [ApiController]
    public class SharesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public SharesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id:int}", Name = "ShareById")]
        public async Task<IActionResult> GetShare(int id)
        {
            var shareDto = _serviceManager.ShareService.GetShareAsync(id, false);
            return Ok(shareDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShare([FromBody] ShareForCreationDto share)
        {
            var createdShare = await _serviceManager.ShareService.CreateShareAsync(share);
            return CreatedAtRoute("ShareById", new { id = createdShare.Id }, createdShare);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSharePrice(int id, [FromBody] ShareForUpdateDto share)
        {
            await _serviceManager.ShareService.UpdateShareAsync(id, share, true);
            return NoContent();
        }
        //todo: delete will be written
    }
}
