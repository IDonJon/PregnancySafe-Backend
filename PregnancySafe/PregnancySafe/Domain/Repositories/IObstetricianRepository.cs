using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Repositories
{
    public interface IObstetricianRepository
    {
        Task<IEnumerable<Obstetrician>> ListAsync();
        Task<Obstetrician> FindByIdAsync(int id);
        Task AddASync(Obstetrician obstetrician);
        void Update(Obstetrician obstetrician);
        void Remove(Obstetrician obstetrician);
        void GetByIdAsync(int id);
    }
}