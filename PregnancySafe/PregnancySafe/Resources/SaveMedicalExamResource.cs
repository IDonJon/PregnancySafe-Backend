using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Resources
{
    public class SaveMedicalExamResource
    {
        [Required]
        [MaxLength(50)]
        public string ExamType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Result { get; set; }

        [Required]
        public DateTime PrescriptionDate { get; set; }
    }
}
