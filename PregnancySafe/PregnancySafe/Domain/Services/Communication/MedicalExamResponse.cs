using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class MedicalExamResponse : BaseResponse
    {
        public MedicalExam MedicalExam { get; private set; }
        public MedicalExamResponse(bool success, string responseMessage, MedicalExam medicalExam) : base(success, responseMessage)
        {
            MedicalExam = medicalExam;
        }

        public MedicalExamResponse(MedicalExam medicalExam) : this(true, string.Empty, medicalExam) { }
        public MedicalExamResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}