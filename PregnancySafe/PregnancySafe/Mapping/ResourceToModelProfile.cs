using AutoMapper;
using PregnancySafe.Domain.Models;
using PregnancySafe.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            //CreateMap<SaveAdviceResource, Advice>();
            //CreateMap<SaveChatResource, Chat>();
            //CreateMap<SaveMedicalAppointmentResource, MedicalAppointment>();
            //CreateMap<SaveMedicalExamResource, MedicalExam>();
            //CreateMap<SaveMessageResource, Message>();
            CreateMap<SaveMotherResource, Mother>();
            //CreateMap<SaveObstetricianResource, Obstetrician>();
            //CreateMap<SavePregnancyStageResource, PregnancyStage>();
            //CreateMap<SaveVideoResource, Video>();
        }
    }
}
