using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class PregnancyStageResponse : BaseResponse
    {
        public PregnancyStage PregnancyStage { get; private set; }
        public PregnancyStageResponse(bool success, string responseMessage, PregnancyStage pregnancyStage) : base(success, responseMessage)
        {
            PregnancyStage = pregnancyStage;
        }

        public PregnancyStageResponse(PregnancyStage pregnancyStage) : this(true, string.Empty, pregnancyStage) { }
        public PregnancyStageResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}
