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
    public class AdviceController : Controller
    {
        private readonly IAdviceService _adviceService;
        private readonly IMapper _mapper;
        public AdviceController(IAdviceService adviceService, IMapper mapper)
        {
            _adviceService = adviceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AdviceResource>> GetAllAsync()
        {
            var advices = await _adviceService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Advice>, IEnumerable<AdviceResource>>(advices);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAdviceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var advice = _mapper.Map<SaveAdviceResource, Advice>(resource);
            var result = await _adviceService.SaveAsync(advice);

            if (!result.Success)
                return BadRequest(result.Message);

            var adviceResource = _mapper.Map<Advice, AdviceResource>(result.Advice);
            return Ok(adviceResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveAdviceResource resource)
        {
            var advice = _mapper.Map<SaveAdviceResource, Advice>(resource);
            var result = await _adviceService.UpdateAsync(id, advice);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var adviceResource = _mapper.Map<Advice, AdviceResource>(result.Advice);
            return Ok(adviceResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _adviceService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var adviceResource = _mapper.Map<Advice, AdviceResource>(result.Advice);
            return Ok(adviceResource);
        }
    }
}
