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
        public MotherService(IMotherRepository motherRepository, IUnitOfWork unitOfWork)
        {
            _motherRepository = motherRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MotherResponse> DeleteAsync(int id)
        {
            var existingMother = await _motherRepository.FindByIdAsync(id);

            if (existingMother == null)
                return new MotherResponse("Mother not found");

            try
            {
                _motherRepository.Remove(existingMother);
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

        public async Task<MotherResponse> SaveAsync(Mother mother)
        {
            try
            {
                await _motherRepository.AddASync(mother);
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

            try
            {
                _motherRepository.Update(existingMother);
                return new MotherResponse(existingMother);
            }
            catch (Exception exception)
            {
                return new MotherResponse($"An error ocurred while updating the Mother: {exception.Message}");
            }
        }
    }
}
