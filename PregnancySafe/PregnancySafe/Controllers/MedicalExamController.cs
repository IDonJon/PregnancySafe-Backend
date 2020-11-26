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
    [Route("/api/medicalexams")]
    public class MedicalExamController : Controller
    {
        private readonly IMedicalExamService _medicalExamService;
        private readonly IMapper _mapper;
        public MedicalExamController(IMedicalExamService medicalExamService, IMapper mapper)
        {
            _medicalExamService = medicalExamService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MedicalExamResource>> GetAllAsync()
        {
            var medicalExam = await _medicalExamService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<MedicalExam>, IEnumerable<MedicalExamResource>>(medicalExam);
            return resources;
        }

        [HttpPost("{motherId}/{obstetricianId}")]
        public async Task<IActionResult> PostAsync([FromBody] SaveMedicalExamResource resource,
             int motherId, int obstetricianId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var medicalExam = _mapper.Map<SaveMedicalExamResource, MedicalExam>(resource);
            var result = await _medicalExamService.SaveAsync(medicalExam, motherId, obstetricianId);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicalExamResource = _mapper.Map<MedicalExam, MedicalExamResource>(result.MedicalExam);
            return Ok(medicalExamResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMedicalExamResource resource)
        {
            var medicalExam = _mapper.Map<SaveMedicalExamResource, MedicalExam>(resource);
            var result = await _medicalExamService.UpdateAsync(id, medicalExam);

            if (!result.Success)
                return BadRequest(result.Message);
            var medicalExamResource = _mapper.Map<MedicalExam, MedicalExamResource>(result.MedicalExam);
            return Ok(medicalExamResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _medicalExamService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var medicalExamResource = _mapper.Map<MedicalExam, MedicalExamResource>(result.MedicalExam);
            return Ok(medicalExamResource);
        }
    }
}
