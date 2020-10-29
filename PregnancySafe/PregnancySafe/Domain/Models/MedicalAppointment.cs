using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Models
{
    public class MedicalAppointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int MotherId { get; set; }
        public virtual Mother Mother { get; set; }
        public int ObstetricianId { get; set; }
        public virtual Obstetrician Obstetrician { get; set; }
    }
}
