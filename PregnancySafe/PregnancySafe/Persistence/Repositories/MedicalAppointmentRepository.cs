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
    public class MedicalAppointmentRepository : BaseRepository, IMedicalAppointmentRepository
    {
        public MedicalAppointmentRepository(AppDbContext context) : base(context) { }

        public async Task AddASync(MedicalAppointment medicalAppointment)
        {
            await _context.MedicalAppointments.AddAsync(medicalAppointment);
        }

        public async Task<MedicalAppointment> FindByIdAsync(int id)
        {
            return await _context.MedicalAppointments.FindAsync(id);
        }

        public async Task<IEnumerable<MedicalAppointment>> ListAsync()
        {
            return await _context.MedicalAppointments.
                Include(p=> p.Obstetrician).Include(q=> q.Mother).ToListAsync();
        }

        public void Remove(MedicalAppointment medicalAppointment)
        {
            _context.MedicalAppointments.Remove(medicalAppointment);
        }

        public void Update(MedicalAppointment medicalAppointment)
        {
            _context.MedicalAppointments.Update(medicalAppointment);
        }
    }
}
