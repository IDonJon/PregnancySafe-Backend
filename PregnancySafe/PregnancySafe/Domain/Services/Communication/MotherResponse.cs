using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class MotherResponse : BaseResponse
    {
        public Mother Mother { get; private set; }
        public MotherResponse(bool success, string responseMessage, Mother mother) : base(success, responseMessage)
        {
            Mother = mother;
        }

        public MotherResponse(Mother mother) : this(true, string.Empty, mother) { }
        public MotherResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}