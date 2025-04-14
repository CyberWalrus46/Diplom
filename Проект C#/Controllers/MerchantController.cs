using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Some_API.Abstractions;
using Some_API.Contracts;
using System;
using System.Runtime.CompilerServices;

namespace Some_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService _merchantService;

        public MerchantController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MerchantResponse>>> GetMerchants()
        {
            var merchants = await _merchantService.GetAllMerchants();

            var response = merchants.Select(b => new MerchantResponse(b.Id, b.Title, b.Status, b.Description));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMerchants([FromBody] MerchantRequest request)
        {
            var (merchant, error) = Merchant.Create(
                Guid.NewGuid(),
                request.title,
                request.status,
                request.description);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var merchantId = await _merchantService.CreateMerchants(merchant);

            return Ok(merchantId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateMerchants([FromBody] MerchantRequest request, Guid id)
        {
            var merchantId = await _merchantService.UpdateMerchants(id, request.title, request.status, request.description);
            return Ok(merchantId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteMerchants(Guid id)
        {
            var merchantId = await _merchantService.DeleteMerchants(id);
            return Ok(merchantId);
        }
    }
}
