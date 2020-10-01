using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Repositories
{
    public interface IPregnancyStageRepository
    {
        Task<IEnumerable<PregnancyStage>> ListAsync();
        Task<PregnancyStage> FindByIdAsync(int id);
        Task AddASync(PregnancyStage pregnancyStage);
        void Update(PregnancyStage pregnancyStage);
        void Remove(PregnancyStage pregnancyStage);
    }
}
