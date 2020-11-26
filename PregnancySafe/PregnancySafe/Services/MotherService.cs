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
    public class MotherService : IMotherService
    {
        private readonly IMotherRepository _motherRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPregnancyStageRepository _pregnancyStageRepository;
        public MotherService(IMotherRepository motherRepository, IUnitOfWork unitOfWork,
            IPregnancyStageRepository pregnancyStageRepository)
        {
            _motherRepository = motherRepository;
            _unitOfWork = unitOfWork;
            _pregnancyStageRepository = pregnancyStageRepository;
        }

        public async Task<MotherResponse> DeleteAsync(int id)
        {
            var existingMother = await _motherRepository.FindByIdAsync(id);

            if (existingMother == null)
                return new MotherResponse("Mother not found");

            try
            {
                _motherRepository.Remove(existingMother);
                await _unitOfWork.CompleteAsync();
                return new MotherResponse(existingMother);
            }
            catch (Exception exception)
            {
                return new MotherResponse($"An error ocurred while deleting the Mother: {exception.Message}");
            }
        }

        public async Task<MotherResponse> GetByIdAsync(int id)
        {
            var existingMother = await _motherRepository.FindByIdAsync(id);

            if (existingMother == null)
                return new MotherResponse("Mother not found");
            return new MotherResponse(existingMother);
        }

        public async Task<IEnumerable<Mother>> ListAsync()
        {
            return await _motherRepository.ListAsync();
        }

        public async Task<MotherResponse> SaveAsync(Mother mother, int pregnancyStageId)
        {
            var existingPregnancyStage = await _pregnancyStageRepository
            .FindByIdAsync(pregnancyStageId);
            if (existingPregnancyStage == null)
                return new MotherResponse("Pregnancy Stage not found");

            mother.PregnancyStage = existingPregnancyStage;

            try
            {
                await _motherRepository.AddASync(mother);
                await _unitOfWork.CompleteAsync();
                return new MotherResponse(mother);
            }
            catch (Exception exception)
            {
                return new MotherResponse($"An error ocurred while saving the Mother: {exception.Message}");
            }
        }

        public async Task<MotherResponse> UpdateAsync(int id, Mother mother)
        {
            var existingMother = await _motherRepository.FindByIdAsync(id);

            if (existingMother == null)
                return new MotherResponse("Mother not found");
            existingMother.FirstName = mother.FirstName;
            existingMother.LastName = mother.LastName;
            existingMother.Email = mother.Email;
            existingMother.Age = mother.Age;

            try
            {
                _motherRepository.Update(existingMother);
                await _unitOfWork.CompleteAsync();
                return new MotherResponse(existingMother);
            }
            catch (Exception exception)
            {
                return new MotherResponse($"An error ocurred while updating the Mother: {exception.Message}");
            }
        }
    }
}
