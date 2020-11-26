using AutoMapper;
using PregnancySafe.Domain.Models;
using PregnancySafe.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Advice, AdviceResource>();
            CreateMap<Chat, ChatResource>();
            CreateMap<MedicalAppointment, MedicalAppointmentResource>();
            CreateMap<MedicalExam, MedicalExamResource>();
            CreateMap<Message, MessageResource>();
            CreateMap<Mother, MotherResource>();
            CreateMap<Obstetrician, ObstetricianResource>();
            CreateMap<PregnancyStage, PregnancyStageResource>();
            CreateMap<Video, VideoResource>();
            CreateMap<User, UserResource>();
        }
    }
}
