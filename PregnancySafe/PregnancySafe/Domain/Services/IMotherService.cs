using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services
{
    public interface IMotherService
    {
        Task<IEnumerable<Mother>> ListAsync();
        Task<MotherResponse> SaveAsync(Mother mother, int pregnancyStageId);
        Task<MotherResponse> UpdateAsync(int id, Mother mother);
        Task<MotherResponse> DeleteAsync(int id);
        Task<MotherResponse> GetByIdAsync(int id);
    }
}

