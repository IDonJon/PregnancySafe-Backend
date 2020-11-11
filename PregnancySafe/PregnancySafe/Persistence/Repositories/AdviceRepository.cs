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
    public class AdviceRepository : BaseRepository, IAdviceRepository
    {
        public AdviceRepository(AppDbContext context) : base(context) { }

        public async Task AddASync(Advice advice)
        {
            await _context.Advices.AddAsync(advice);
        }
        public async Task<Advice> FindById(int id)
        {
            return await _context.Advices.FindAsync(id);
        }
        public async Task<IEnumerable<Advice>> ListAsync()
        {
            return await _context.Advices
                .Include(p => p.Obstetrician).ToListAsync();
        }

        public  IEnumerable<Advice> ListByObstetricianId(int obstetricianId)
        {
            return _context.Advices
                .Where(p => p.ObstetricianId == obstetricianId)
                .Include(p => p.Obstetrician)
                .ToList();
        }

        public void Remove(Advice advice)
        {
            _context.Advices.Remove(advice);
        }
        public void Update(Advice advice)
        {
            _context.Advices.Update(advice);
        }
    }
}
