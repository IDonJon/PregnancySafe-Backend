using PregnancySafe.Domain.Models;
//using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services
{
    public interface IAdviceService
    {
        Task<IEnumerable<Advice>> ListAsync();
        //Task<AdviceResponse> SaveAsync(Advice advice);
        //Task<AdviceResponse> UpdateAsync(int id, Advice advice);
        //Task<AdviceResponse> DeleteAsync(int id);
    }
}
