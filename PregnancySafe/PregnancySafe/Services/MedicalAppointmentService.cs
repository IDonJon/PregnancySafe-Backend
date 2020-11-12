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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMotherRepository _motherRepository;
        private readonly IObstetricianRepository _obstetricianRepository;
        public MedicalAppointmentService(IMedicalAppointmentRepository medicalAppointmentRepository, 
            IUnitOfWork unitOfWork, IMotherRepository motherRepository, IObstetricianRepository obstetricianRepository)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
            _unitOfWork = unitOfWork;
            _motherRepository = motherRepository;
            _obstetricianRepository = obstetricianRepository;
        }

        public async Task<MedicalAppointmentResponse> DeleteAsync(int id)
        {
            var existingMedicalAppointment = await _medicalAppointmentRepository.FindByIdAsync(id);

            if (existingMedicalAppointment == null)
                return new MedicalAppointmentResponse("Medical Appointment not found");

            try
            {
                _medicalAppointmentRepository.Remove(existingMedicalAppointment);
                await _unitOfWork.CompleteAsync();
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

        public async Task<MedicalAppointmentResponse> SaveAsync(MedicalAppointment medicalAppointment,
            int motherId, int obstetricianId)
        {
            var existingObstetrician = await _obstetricianRepository
               .FindByIdAsync(obstetricianId);
            if (existingObstetrician == null)
                return new MedicalAppointmentResponse("Obstetrician not found");            

            var existingMother = await _motherRepository
                .FindByIdAsync(motherId);
            if (existingMother == null)
                return new MedicalAppointmentResponse("Mother not found");

            medicalAppointment.Obstetrician = existingObstetrician;
            medicalAppointment.Mother = existingMother;
            try
            {
                await _medicalAppointmentRepository.AddASync(medicalAppointment);
                await _unitOfWork.CompleteAsync();
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

            existingMedicalAppointment.AppointmentDate = medicalAppointment.AppointmentDate;

            try
            {
                _medicalAppointmentRepository.Update(existingMedicalAppointment);
                await _unitOfWork.CompleteAsync();
                return new MedicalAppointmentResponse(existingMedicalAppointment);
            }
            catch (Exception exception)
            {
                return new MedicalAppointmentResponse($"An error ocurred while updating Medical Appointment: {exception.Message}");
            }
        }
        public async Task<MedicalAppointmentResponse> GetByIdAsync(int id)
        {
            var existingMedicalAppointment = await _medicalAppointmentRepository.FindByIdAsync(id);

            if (existingMedicalAppointment == null)
                return new MedicalAppointmentResponse("Medical Appointment not found");
            return new MedicalAppointmentResponse(existingMedicalAppointment);
        }
    }
}
