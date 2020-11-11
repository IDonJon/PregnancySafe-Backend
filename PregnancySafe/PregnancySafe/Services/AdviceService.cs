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
    public class AdviceService : IAdviceService
    {
        private readonly IAdviceRepository _adviceRepository;
        public AdviceService(IAdviceRepository adviceRepository)
        {
            _adviceRepository = adviceRepository;
        }

        public async Task<AdviceResponse> DeleteAsync(int id)
        {
            var existingAdvice = await _adviceRepository.FindById(id);

            if (existingAdvice == null)
                return new AdviceResponse("Advice not found");

            try
            {
                _adviceRepository.Remove(existingAdvice);
                return new AdviceResponse(existingAdvice);
            }
            catch (Exception exception)
            {
                return new AdviceResponse($"An error ocurred while deleting the Advice: {exception.Message}");
            }
        }

        public async Task<IEnumerable<Advice>> ListAsync()
        {
            return await _adviceRepository.ListAsync();
        }

        public  IEnumerable<Advice> ListByObstetricianId(int obstetricianId)
        {
            return  _adviceRepository.ListByObstetricianId(obstetricianId);
        }

        public async Task<AdviceResponse> SaveAsync(Advice advice)
        {
            try
            {
                await _adviceRepository.AddASync(advice);
                return new AdviceResponse(advice);
            }
            catch (Exception exception)
            {
                return new AdviceResponse($"An error ocurred while saving the Advice: {exception.Message}");
            }
        }

        public async Task<AdviceResponse> UpdateAsync(int id, Advice advice)
        {
            var existingAdvice = await _adviceRepository.FindById(id);

            if (existingAdvice == null)
                return new AdviceResponse("Advice not found");
            existingAdvice.Title = advice.Title;
            existingAdvice.Text = advice.Text;
            existingAdvice.PostDate = advice.PostDate;

            try
            {
                _adviceRepository.Update(existingAdvice);
                return new AdviceResponse(existingAdvice);
            }
            catch (Exception exception)
            {
                return new AdviceResponse($"An error ocurred while updating the Advice: {exception.Message}");
            }
        }


    }
}
