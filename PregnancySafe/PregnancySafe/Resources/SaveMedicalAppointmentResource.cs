using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Resources
{
    public class SaveMedicalAppointmentResource
    {
        [Required]
        public DateTime AppointmentDate { get; set; }
    }
}
