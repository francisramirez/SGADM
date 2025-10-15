using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.Dtos.Configuration.Ruta;
using SGA.Application.Interfaces;

namespace SGA.Configuration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly IRutaService _service;

        public RutaController(IRutaService service)
        {
            _service = service;
        }
        [HttpGet("get-ruta")]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllRutasAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("get-ruta-id")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetRutaByIdAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("create-ruta")]
        public async Task<IActionResult> Post(CreateRutaDto createRutaDto) 
        {
            var result = await _service.CreateRutaAsync(createRutaDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("update-ruta")]
        public async Task<IActionResult> Post(UpdateRutaDto updateRutaDto)
        {
            var result = await _service.UpdateRutaAsync(updateRutaDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("remove-ruta")]
        public async Task<IActionResult> Post(RemoveRutaDto removeRutaDto)
        {
            var result = await _service.DeleteRutaAsync(removeRutaDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
