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
using Map.Vision.Data.ViewModels.Input;
using Map.Vision.BI.Interfaces;
using Map.Vision.Data.Dto;

namespace Map.Vision.API.Controllers
{
    [ApiController]
    [Route("map/[Controller]")]
    public class AdminController : BaseController
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IMapper _mapper;
        private readonly IAdmin _admin;

        public AdminController(ILogger<AdminController> logger, IMapper mapper, IAdmin admin)
        {
            _logger = logger;
            _mapper = mapper;
            _admin = admin;
        }

        [HttpPost("add-sensor")]
        public async Task<IActionResult> AddSensor([FromForm] SensorCreate model)
        {
            var result = await _admin.CreateSensor(_mapper.Map<SensorInputDto>(model));

            if (!result)
                return BadRequest("Непредвиденная ошибка!");

            return Ok(result);
        }

        [HttpPost("update-sensor")]
        public async Task<IActionResult> UpdateSensor([FromForm] SensorCreate model)
        {
            var result = await _admin.UpdateSensor(_mapper.Map<SensorInputDto>(model));

            if (!result)
                return BadRequest("Непредвиденная ошибка!");

            return Ok(result);
        }
    }
}
