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
    public class ObstetricianRepository : BaseRepository, IObstetricianRepository
    {
        public ObstetricianRepository(AppDbContext context) : base(context) { }

        public async Task AddASync(Obstetrician obstetrician)
        {
            await _context.Obstetricians.AddAsync(obstetrician);
        }

        public async Task<Obstetrician> FindByIdAsync(int id)
        {
            return await _context.Obstetricians.FindAsync(id);
        }

        public void GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Obstetrician>> ListAsync()
        {
            return await _context.Obstetricians.
                Include(p=> p.Advices).ToListAsync();
        }

        public void Remove(Obstetrician obstetrician)
        {
            _context.Obstetricians.Remove(obstetrician);
        }

        public void Update(Obstetrician obstetrician)
        {
            _context.Obstetricians.Update(obstetrician);
        }
    }
}
