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
    public class MedicalExamRepository : BaseRepository, IMedicalExamRepository
    {
        public MedicalExamRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<MedicalExam>> ListAsync()
        {
            return await _context.MedicalExams.ToListAsync();
        }
        public async Task AddASync(MedicalExam medicalExam)
        {
            await _context.MedicalExams.AddAsync(medicalExam);
        }
        public async Task<MedicalExam> FindByIdAsync(int id)
        {
            return await _context.MedicalExams.FindAsync(id);
        }
        public void Update(MedicalExam medicalExam)
        {
            _context.MedicalExams.Update(medicalExam);
        }
        public void Remove(MedicalExam medicalExam)
        {
            _context.MedicalExams.Remove(medicalExam);
        }
    }
}
