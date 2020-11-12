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
    public class PregnancyStageService : IPregnancyStageService
    {
        private readonly IPregnancyStageRepository _pregnancyStageRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PregnancyStageService(IPregnancyStageRepository pregnancyStageRepository,
            IUnitOfWork unitOfWork)
        {
            _pregnancyStageRepository = pregnancyStageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PregnancyStageResponse> DeleteAsync(int id)
        {
            var existingPregnancyStage = await _pregnancyStageRepository.FindByIdAsync(id);

            if (existingPregnancyStage == null)
                return new PregnancyStageResponse("Pregnancy Stage not found");

            try
            {
                _pregnancyStageRepository.Remove(existingPregnancyStage);
                await _unitOfWork.CompleteAsync();
                return new PregnancyStageResponse(existingPregnancyStage);
            }
            catch (Exception exception)
            {
                return new PregnancyStageResponse($"An error ocurred while deleting the Pregnancy Stage: {exception.Message}");
            }
        }

        public async Task<IEnumerable<PregnancyStage>> ListAsync()
        {
            return await _pregnancyStageRepository.ListAsync();
        }

        public async Task<PregnancyStageResponse> SaveAsync(PregnancyStage pregnancyStage)
        {
            try
            {
                await _pregnancyStageRepository.AddASync(pregnancyStage);
                await _unitOfWork.CompleteAsync();
                return new PregnancyStageResponse(pregnancyStage);
            }
            catch (Exception exception)
            {
                return new PregnancyStageResponse($"An error ocurred while saving the Pregnancy Stage: {exception.Message}");
            }
        }

        public async Task<PregnancyStageResponse> UpdateAsync(int id, PregnancyStage pregnancyStage)
        {
            var existingPregnancyStage = await _pregnancyStageRepository.FindByIdAsync(id);

            if (existingPregnancyStage == null)
                return new PregnancyStageResponse("Pregnancy Stage not found");

            try
            {
                _pregnancyStageRepository.Update(existingPregnancyStage);
                await _unitOfWork.CompleteAsync();
                return new PregnancyStageResponse(existingPregnancyStage);
            }
            catch (Exception exception)
            {
                return new PregnancyStageResponse($"An error ocurred while updating the Pregnancy Stage: {exception.Message}");
            }
        }
    }
}
