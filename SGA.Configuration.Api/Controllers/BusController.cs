using Microsoft.AspNetCore.Mvc;
using SGA.Application.Base;
using SGA.Application.Dtos.Configuration.Bus;
using SGA.Application.Interfaces;

namespace SGA.Configuration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }
        // GET: api/<BusController>
        [HttpGet("getBuses")]
        public async Task<IActionResult> Get()
        {
            ServiceResult result = await _busService.GetBuses();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<BusController>/5
        [HttpGet("getBusById")]
        public async Task<IActionResult> Get(int id)
        {
            ServiceResult result = await _busService.GetBusById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/<BusController>
        [HttpPost("create-bus")]
        public async Task<IActionResult> Post([FromBody] CreateBusDto createBusDto)
        {
            ServiceResult result = await _busService.CreateBus(createBusDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<BusController>/5
        [HttpPut("update-bus")]
        public async Task<IActionResult> Put([FromBody] UpdateBusDto updateBusDto)
        {
            ServiceResult result = await _busService.UpdateBus(updateBusDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT api/<BusController>/5
        [HttpPut("remove-bus")]
        public async Task<IActionResult> Put([FromBody] RemoveBusDto removeBusDto)
        {
            ServiceResult result = await _busService.RemoveBus(removeBusDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
