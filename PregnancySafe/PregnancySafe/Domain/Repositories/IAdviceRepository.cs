using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Repositories
{
    public interface IAdviceRepository
    {
        Task<IEnumerable<Advice>> ListAsync();
        IEnumerable<Advice> ListByObstetricianId(int obstetricianId);
        Task<Advice> FindById(int id);
        Task AddASync(Advice advice);
        void Update(Advice advice);
        void Remove(Advice advice);
    }
}
