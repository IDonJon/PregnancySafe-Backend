using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services;
using PregnancySafe.Extensions;
using PregnancySafe.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Controllers
{
    [Route("/api/mothers")]
    public class MotherController : Controller
    {
        private readonly IMotherService _motherService;
        private readonly IMapper _mapper;
        public MotherController(IMotherService motherService, IMapper mapper)
        {
            _motherService = motherService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MotherResource>> GetAllAsync()
        {
            var mothers = await _motherService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Mother>, IEnumerable<MotherResource>>(mothers);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMotherResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var mother = _mapper.Map<SaveMotherResource, Mother>(resource);
            var result = await _motherService.SaveAsync(mother);

            if (!result.Success)
                return BadRequest(result.Message);

            var motherResource = _mapper.Map<Mother, MotherResource>(result.Mother);
            return Ok(motherResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveMotherResource resource)
        {
            var mother = _mapper.Map<SaveMotherResource, Mother>(resource);
            var result = await _motherService.UpdateAsync(id, mother);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var motherResource = _mapper.Map<Mother, MotherResource>(result.Mother);
            return Ok(motherResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _motherService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var motherResource = _mapper.Map<Mother, MotherResource>(result.Mother);
            return Ok(motherResource);
        }
    }
}