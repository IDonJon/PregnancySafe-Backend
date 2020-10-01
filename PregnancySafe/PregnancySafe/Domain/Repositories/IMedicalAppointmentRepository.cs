using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Repositories
{
    public interface IMedicalAppointmentRepository
    {
        Task<IEnumerable<MedicalAppointment>> ListAsync();
        Task<MedicalAppointment> FindByIdAsync(int id);
        Task AddASync(MedicalAppointment medicalAppointment);
        void Update(MedicalAppointment medicalAppointment);
        void Remove(MedicalAppointment medicalAppointment);
    }
}
