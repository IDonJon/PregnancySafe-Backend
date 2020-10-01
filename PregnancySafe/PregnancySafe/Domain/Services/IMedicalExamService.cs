using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services
{
    public interface IMedicalExamService
    {
        Task<IEnumerable<MedicalExam>> ListAsync();
        //Task<MedicalExamResponse> SaveAsync(MedicalExam medicalExam);
        //Task<MedicalExamResponse> UpdateAsync(int id, MedicalExam medicalExam);
        //Task<MedicalExamResponse> DeleteAsync(int id);
    }
}
