using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Repositories;
using PregnancySafe.Domain.Services;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Services
{
    public class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
        public MedicalAppointmentService(IMedicalAppointmentRepository medicalAppointmentRepository)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
        }

        public async Task<MedicalAppointmentResponse> DeleteAsync(int id)
        {
            var existingMedicalAppointment = await _medicalAppointmentRepository.FindByIdAsync(id);

            if (existingMedicalAppointment == null)
                return new MedicalAppointmentResponse("Medical Appointment not found");

            try
            {
                _medicalAppointmentRepository.Remove(existingMedicalAppointment);

                return new MedicalAppointmentResponse(existingMedicalAppointment);
            }
            catch (Exception exception)
            {
                return new MedicalAppointmentResponse($"An error ocurred while deleting Medical Appointment: {exception.Message}");
            }
        }

        public async Task<IEnumerable<MedicalAppointment>> ListAsync()
        {
            return await _medicalAppointmentRepository.ListAsync();
        }

        public async Task<MedicalAppointmentResponse> SaveAsync(MedicalAppointment medicalAppointment)
        {
            try
            {
                await _medicalAppointmentRepository.AddASync(medicalAppointment);

                return new MedicalAppointmentResponse(medicalAppointment);
            }
            catch (Exception exception)
            {
                return new MedicalAppointmentResponse($"An error ocurred while saving Medical Appointment: {exception.Message}");
            }
        }

        public async Task<MedicalAppointmentResponse> UpdateAsync(int id, MedicalAppointment medicalAppointment)
        {
            var existingMedicalAppointment = await _medicalAppointmentRepository.FindByIdAsync(id);

            if (existingMedicalAppointment == null)
                return new MedicalAppointmentResponse("Medical Appointment not found");

            try
            {
                _medicalAppointmentRepository.Update(existingMedicalAppointment);

                return new MedicalAppointmentResponse(existingMedicalAppointment);
            }
            catch (Exception exception)
            {
                return new MedicalAppointmentResponse($"An error ocurred while updating Medical Appointment: {exception.Message}");
            }
        }
    }
}
