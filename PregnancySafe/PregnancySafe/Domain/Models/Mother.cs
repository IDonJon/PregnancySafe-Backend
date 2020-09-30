using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Models
{
    public class Mother
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int PregnancyStageId { get; set; }
        //public PregnancyStage PregnancyStage { get; set; }
        //public IList<Chat> Chats { get; set; } = new List<Chat>();
        //public IList<MedicalAppointment> MedicalAppointments { get; set; } = new List<MedicalAppointment>();
        //public IList<MedicalExam> MedicalExams { get; set; } = new List<MedicalExam>();
    }
}