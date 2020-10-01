using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services
{
    public interface IPregnancyStageService
    {
        Task<IEnumerable<PregnancyStage>> ListAsync();
        //Task<PregnancyStageResponse> SaveAsync(PregnancyStage pregnancyStage);
        //Task<PregnancyStageResponse> UpdateAsync(int id, PregnancyStage pregnancyStage);
        //Task<PregnancyStageResponse> DeleteAsync(int id);
    }
}
