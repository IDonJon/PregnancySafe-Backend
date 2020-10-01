using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class MedicalAppointmentResponse : BaseResponse
    {
        public MedicalAppointment MedicalAppointment { get; private set; }
        public MedicalAppointmentResponse(bool success, string responseMessage, MedicalAppointment medicalAppointment) : base(success, responseMessage)
        {
            MedicalAppointment = medicalAppointment;
        }

        public MedicalAppointmentResponse(MedicalAppointment medicalAppointment) : this(true, string.Empty, medicalAppointment) { }
        public MedicalAppointmentResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}
