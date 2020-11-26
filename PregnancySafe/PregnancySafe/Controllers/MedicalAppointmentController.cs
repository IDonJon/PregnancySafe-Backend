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
    [Route("/api/medicalappointments")]
    public class MedicalAppointmentController : Controller
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly IMapper _mapper;
        public MedicalAppointmentController(IMedicalAppointmentService medicalAppointmentService, IMapper mapper)
        {
            _medicalAppointmentService = medicalAppointmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MedicalAppointmentResource>> GetAllAsync()
        {
            var medicalAppointment = await _medicalAppointmentService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<MedicalAppointment>, IEnumerable<MedicalAppointmentResource>>(medicalAppointment);
            return resources;
        }

        [HttpPost("{motherId}/{obstetricianId}")]
        public async Task<IActionResult> PostAsync([FromBody] SaveMedicalAppointmentResource resource,
            int motherId, int obstetricianId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var medicalAppointment = _mapper.Map<SaveMedicalAppointmentResource, MedicalAppointment>(resource);
            var result = await _medicalAppointmentService.SaveAsync(medicalAppointment, motherId, obstetricianId);

            if (!result.Success)
                return BadRequest(result.Message);

            var medicalAppointmentResource = _mapper.Map<MedicalAppointment, MedicalAppointmentResource>(result.MedicalAppointment);
            return Ok(medicalAppointmentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMedicalAppointmentResource resource)
        {
            var medicalAppointment = _mapper.Map<SaveMedicalAppointmentResource, MedicalAppointment>(resource);
            var result = await _medicalAppointmentService.UpdateAsync(id, medicalAppointment);

            if (!result.Success)
                return BadRequest(result.Message);
            var medicalAppointmentResource = _mapper.Map<MedicalAppointment, MedicalAppointmentResource>(result.MedicalAppointment);
            return Ok(medicalAppointmentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _medicalAppointmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var medicalAppointmentResource = _mapper.Map<MedicalAppointment, MedicalAppointmentResource>(result.MedicalAppointment);
            return Ok(medicalAppointmentResource);
        }
    }
}
