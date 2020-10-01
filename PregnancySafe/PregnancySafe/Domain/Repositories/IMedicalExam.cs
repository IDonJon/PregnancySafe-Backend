using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Repositories
{
    public interface IMedicalExamRepository
    {
        Task<IEnumerable<MedicalExam>> ListAsync();
        Task<MedicalExam> FindByIdAsync(int id);
        Task AddASync(MedicalExam medicalExam);
        void Update(MedicalExam medicalExam);
        void Remove(MedicalExam medicalExam);
    }
}
