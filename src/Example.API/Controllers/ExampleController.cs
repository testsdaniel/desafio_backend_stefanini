using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response;
using Example.Application.ExampleService.Service;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : BaseController
    {
        private readonly IExampleService _service;

        public ExampleController(IExampleService service) : base()
        {
            _service = service;
        }

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
        public async Task<IActionResult> Post([FromBody] CreateExampleRequest request)
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
        public async Task<IActionResult> Put([FromBody] UpdateExampleRequest request)
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
        public async Task<IActionResult> Delete([FromBody] DeleteExampleRequest request)
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
