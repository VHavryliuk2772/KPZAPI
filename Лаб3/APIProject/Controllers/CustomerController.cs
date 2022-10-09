using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels.CustomerDTOs;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CustomerController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("shortList")]
        public async Task<IActionResult> GetShortListAsync()
        {
            var result = await _serviceManager.CustomerService.GetAllAsync<ShortCustomerDTO>();
            return Ok(result);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int customerId)
        {
            await _serviceManager.CustomerService.DeleteByIdAsync(customerId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] UpdateCreateCustomerDTO model)
        {
            var result = await _serviceManager.CustomerService.CreateAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] UpdateCreateCustomerDTO model)
        {
            await _serviceManager.CustomerService.UpdateAsync(model);
            return Ok();
        }
    }
}
