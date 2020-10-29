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
        public MedicalExamService(IMedicalExamRepository medicalExamRepository, IUnitOfWork unitOfWork)
        {
            _medicalExamRepository = medicalExamRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MedicalExamResponse> DeleteAsync(int id)
        {
            var existingMedicalExam = await _medicalExamRepository.FindByIdAsync(id);

            if (existingMedicalExam == null)
                return new MedicalExamResponse("Medical Exam not found");

            try
            {
                _medicalExamRepository.Remove(existingMedicalExam);

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

        public async Task<MedicalExamResponse> SaveAsync(MedicalExam medicalExam)
        {
            try
            {
                await _medicalExamRepository.AddASync(medicalExam);

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

            try
            {
                _medicalExamRepository.Update(existingMedicalExam);

                return new MedicalExamResponse(existingMedicalExam);
            }
            catch (Exception exception)
            {
                return new MedicalExamResponse($"An error ocurred while updating the Medical Exam: {exception.Message}");
            }
        }
    }
}