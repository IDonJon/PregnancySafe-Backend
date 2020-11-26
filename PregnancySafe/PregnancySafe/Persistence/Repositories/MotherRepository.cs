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
    public class MotherRepository : BaseRepository, IMotherRepository
    {
        public MotherRepository(AppDbContext context) : base(context) { }

        public async Task AddASync(Mother mother)
        {
            await _context.Mothers.AddAsync(mother);
        }

        public async Task<Mother> FindByIdAsync(int id)
        {
            return await _context.Mothers.FindAsync(id);
        }

        public void GetByIdAsync(int motherId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Mother>> ListAsync()
        {
            return await _context.Mothers.ToListAsync();
        }

        public void Remove(Mother mother)
        {
            _context.Mothers.Remove(mother);
        }

        public void Update(Mother mother)
        {
            _context.Mothers.Update(mother);
        }
    }
}