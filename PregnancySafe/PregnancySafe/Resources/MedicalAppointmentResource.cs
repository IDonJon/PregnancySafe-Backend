using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Resources
{
    public class MedicalAppointmentResource
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public MotherResource Mother { get; set; }
        public ObstetricianResource Obstetrician { get; set; }

    }
}
