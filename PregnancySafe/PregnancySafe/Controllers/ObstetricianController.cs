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
    [Route("/api/[controller]")]
    public class ObstetricianController : Controller
    {
        private readonly IObstetricianService _obstetricianService;
        private readonly IMapper _mapper;
        public ObstetricianController(IObstetricianService obstetricianService, IMapper mapper)
        {
            _obstetricianService = obstetricianService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ObstetricianResource>> GetAllAsync()
        {
            var obstetricians = await _obstetricianService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Obstetrician>, IEnumerable<ObstetricianResource>>(obstetricians);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveObstetricianResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var obstetrician = _mapper.Map<SaveObstetricianResource, Obstetrician>(resource);
            var result = await _obstetricianService.SaveAsync(obstetrician);

            if (!result.Success)
                return BadRequest(result.Message);

            var obstetricianResource = _mapper.Map<Obstetrician, ObstetricianResource>(result.Obstetrician);
            return Ok(obstetricianResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveObstetricianResource resource)
        {
            var obstetrician = _mapper.Map<SaveObstetricianResource, Obstetrician>(resource);
            var result = await _obstetricianService.UpdateAsync(id, obstetrician);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var obstetricianResource = _mapper.Map<Obstetrician, ObstetricianResource>(result.Obstetrician);
            return Ok(obstetricianResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _obstetricianService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var obstetricianResource = _mapper.Map<Obstetrician, ObstetricianResource>(result.Obstetrician);
            return Ok(obstetricianResource);
        }
    }
}
