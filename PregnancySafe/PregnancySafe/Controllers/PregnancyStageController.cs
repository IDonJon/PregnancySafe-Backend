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
    [Route("/api/pregnancystages")]
    public class PregnancyStageController : Controller
    {
        private readonly IPregnancyStageService _pregnancyStageService;
        private readonly IMapper _mapper;
        public PregnancyStageController(IPregnancyStageService pregnancyStageService, IMapper mapper)
        {
            _pregnancyStageService = pregnancyStageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PregnancyStageResource>> GetAllAsync()
        {
            var pregnancyStages = await _pregnancyStageService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<PregnancyStage>, IEnumerable<PregnancyStageResource>>(pregnancyStages);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePregnancyStageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var pregnancyStage = _mapper.Map<SavePregnancyStageResource, PregnancyStage>(resource);
            var result = await _pregnancyStageService.SaveAsync(pregnancyStage);

            if (!result.Success)
                return BadRequest(result.Message);

            var pregnancyStageResource = _mapper.Map<PregnancyStage, PregnancyStageResource>(result.PregnancyStage);
            return Ok(pregnancyStageResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SavePregnancyStageResource resource)
        {
            var pregnancyStage = _mapper.Map<SavePregnancyStageResource, PregnancyStage>(resource);
            var result = await _pregnancyStageService.UpdateAsync(id, pregnancyStage);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var pregnancyStageResource = _mapper.Map<PregnancyStage, PregnancyStageResource>(result.PregnancyStage);
            return Ok(pregnancyStageResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _pregnancyStageService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var pregnancyStageResource = _mapper.Map<PregnancyStage, PregnancyStageResource>(result.PregnancyStage);
            return Ok(pregnancyStageResource);
        }
    }
}
