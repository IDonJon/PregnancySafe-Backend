using Microsoft.EntityFrameworkCore;
using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Repositories;
using PregnancySafe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Persistence.Repositories
{
    public class PregnancyStageRepository : BaseRepository, IPregnancyStageRepository
    {
        public PregnancyStageRepository(AppDbContext context) : base(context) { }

        public async Task AddASync(PregnancyStage pregnancyStage)
        {
            await _context.PregnancyStages.AddAsync(pregnancyStage);
        }

        public async Task<PregnancyStage> FindByIdAsync(int id)
        {
            return await _context.PregnancyStages.FindAsync(id);
        }

        public async Task<IEnumerable<PregnancyStage>> ListAsync()
        {
            return await _context.PregnancyStages.ToListAsync();
        }

        public void Remove(PregnancyStage pregnancyStage)
        {
            _context.PregnancyStages.Remove(pregnancyStage);
        }

        public void Update(PregnancyStage pregnancyStage)
        {
            _context.PregnancyStages.Update(pregnancyStage);
        }
    }
}
