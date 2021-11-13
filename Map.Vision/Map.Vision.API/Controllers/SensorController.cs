using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Map.Vision.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Map.Vision.Data.Base;
using Map.Vision.Data.Filters;
using Map.Vision.BI.Interfaces;

namespace Map.Vision.API.Controllers
{
    [ApiController]
    [Route("map/[Controller]")]
    public class SensorController : BaseController
    {
        private readonly ILogger<SensorController> _logger;
        private readonly IMapper _mapper;
        private readonly ISensors _sensor;

        public SensorController(ILogger<SensorController> logger, IMapper mapper, ISensors sensor)
        {
            _logger = logger;
            _mapper = mapper;
            _sensor = sensor;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] SensorFilter filter)
        {
            var result = await _sensor.GetAll(filter);

            return Ok(result);
        }

        [HttpGet("all/full-data")]
        public async Task<IActionResult> GetFullData([FromQuery] SensorFilter filter)
        {
            var result = await _sensor.GetAllFull(filter);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensor(int id)
        {
            var result = await _sensor.Get(id);

            return Ok(result);
        }
    }
}
