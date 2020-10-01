using PregnancySafe.Domain.Models;
//using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services
{
    public interface IObstetricianService
    {
        Task<IEnumerable<Obstetrician>> ListAsync();
        //Task<ObstetricianResponse> SaveAsync(Obstetrician obstetrician);
        //Task<ObstetricianResponse> UpdateAsync(int id, Obstetrician obstetrician);
        //Task<ObstetricianResponse> DeleteAsync(int id);
    }
}