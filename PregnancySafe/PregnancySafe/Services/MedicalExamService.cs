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
    public class MedicalExamService : IMedicalExamService
    {
        private readonly IMedicalExamRepository _medicalExamRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMotherRepository _motherRepository;
        private readonly IObstetricianRepository _obstetricianRepository;
        public MedicalExamService(IMedicalExamRepository medicalExamRepository, IUnitOfWork unitOfWork,
             IMotherRepository motherRepository, IObstetricianRepository obstetricianRepository)
        {
            _medicalExamRepository = medicalExamRepository;
            _unitOfWork = unitOfWork;
            _motherRepository = motherRepository;
            _obstetricianRepository = obstetricianRepository;
        }

        public async Task<MedicalExamResponse> DeleteAsync(int id)
        {
            var existingMedicalExam = await _medicalExamRepository.FindByIdAsync(id);

            if (existingMedicalExam == null)
                return new MedicalExamResponse("Medical Exam not found");

            try
            {
                _medicalExamRepository.Remove(existingMedicalExam);
                await _unitOfWork.CompleteAsync();
                return new MedicalExamResponse(existingMedicalExam);
            }
            catch (Exception exception)
            {
                return new MedicalExamResponse($"An error ocurred while deleting the Medical Exam: {exception.Message}");
            }
        }

        public async Task<MedicalExamResponse> GetByIdAsync(int id)
        {
            var existingMedicalExam = await _medicalExamRepository.FindByIdAsync(id);

            if (existingMedicalExam == null)
                return new MedicalExamResponse("Medical Exam not found");
            return new MedicalExamResponse(existingMedicalExam);
        }

        public async Task<IEnumerable<MedicalExam>> ListAsync()
        {
            return await _medicalExamRepository.ListAsync();
        }

        public async Task<MedicalExamResponse> SaveAsync(MedicalExam medicalExam,
            int motherId, int obstetricianId)
        {
            var existingObstetrician = await _obstetricianRepository
               .FindByIdAsync(obstetricianId);
            if (existingObstetrician == null)
                return new MedicalExamResponse("Obstetrician not found");

            medicalExam.Obstetrician = existingObstetrician;

            var existingMother = await _motherRepository
                .FindByIdAsync(motherId);
            if (existingMother == null)
                return new MedicalExamResponse("Mother not found");

            medicalExam.Mother = existingMother;

            try
            {
                await _medicalExamRepository.AddASync(medicalExam);
                await _unitOfWork.CompleteAsync();
                return new MedicalExamResponse(medicalExam);
            }
            catch (Exception exception)
            {
                return new MedicalExamResponse($"An error ocurred while saving the Medical Exam: {exception.Message}");
            }
        }

        public async Task<MedicalExamResponse> UpdateAsync(int id, MedicalExam medicalExam)
        {
            var existingMedicalExam = await _medicalExamRepository.FindByIdAsync(id);

            if (existingMedicalExam == null)
                return new MedicalExamResponse("Medical Exam not found");

            existingMedicalExam.ExamType = medicalExam.ExamType;
            existingMedicalExam.Description = medicalExam.Description;
            existingMedicalExam.Result = medicalExam.Result;
            existingMedicalExam.PrescriptionDate = medicalExam.PrescriptionDate;

            try
            {
                _medicalExamRepository.Update(existingMedicalExam);
                await _unitOfWork.CompleteAsync();
                return new MedicalExamResponse(existingMedicalExam);
            }
            catch (Exception exception)
            {
                return new MedicalExamResponse($"An error ocurred while updating the Medical Exam: {exception.Message}");
            }
        }
    }
}