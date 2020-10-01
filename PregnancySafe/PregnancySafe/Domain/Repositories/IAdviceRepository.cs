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
        Task<Advice> FindByIdAsync(int id);
        Task AddASync(Advice advice);
        void Update(Advice advice);
        void Remove(Advice advice);
    }
}
