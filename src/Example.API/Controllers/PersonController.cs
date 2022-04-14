using Example.Application.PersonService.Models.Request;
using Example.Application.PersonService.Service;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service) : base()
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
        public async Task<IActionResult> Post([FromBody] CreatePersonRequest request)
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
        public async Task<IActionResult> Put([FromBody] UpdatePersonRequest request)
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
        public async Task<IActionResult> Delete([FromBody] DeletePersonRequest request)
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
