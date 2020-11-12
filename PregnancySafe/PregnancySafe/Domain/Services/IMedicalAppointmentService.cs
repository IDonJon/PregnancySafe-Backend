using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services
{
    public interface IMedicalAppointmentService
    {
        Task<IEnumerable<MedicalAppointment>> ListAsync();
        Task<MedicalAppointmentResponse> SaveAsync(MedicalAppointment medicalAppointment);
        Task<MedicalAppointmentResponse> UpdateAsync(int id, MedicalAppointment medicalAppointment);
        Task<MedicalAppointmentResponse> DeleteAsync(int id);
        Task<MedicalAppointmentResponse> GetByIdAsync(int id);
    }
}