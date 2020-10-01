using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Services.Communication
{
    public class ObstetricianResponse : BaseResponse
    {
        public Obstetrician Obstetrician { get; private set; }
        public ObstetricianResponse(bool success, string responseMessage, Obstetrician obstetrician) : base(success, responseMessage)
        {
            Obstetrician = obstetrician;
        }

        public ObstetricianResponse(Obstetrician obstetrician) : this(true, string.Empty, obstetrician) { }
        public ObstetricianResponse(string responseMessage) : this(false, responseMessage, null) { }
    }
}
