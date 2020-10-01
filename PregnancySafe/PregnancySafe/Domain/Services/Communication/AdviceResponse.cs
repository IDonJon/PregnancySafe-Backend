using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class AdviceResponse : BaseResponse
    {
        public Advice Advice { get; private set; }
        public AdviceResponse(bool success, string responseMessage, Advice advice) : base(success, responseMessage)
        {
            Advice = advice;
        }

        public AdviceResponse(Advice advice) : this(true, string.Empty, advice) { }
        public AdviceResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}
