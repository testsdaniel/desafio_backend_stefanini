using Example.Application.CityService.Models.Request;
using Example.Application.CityService.Service;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly ICityService _service;

        public CityController(ICityService service) : base()
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _service.GetAllAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _service.GetByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCityRequest request)
        {
            try
            {
                var response = await _service.CreateAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCityRequest request)
        {
            try
            {
                await _service.UpdateAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCityRequest request)
        {
            try
            {
                await _service.DeleteAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }
    }
}
