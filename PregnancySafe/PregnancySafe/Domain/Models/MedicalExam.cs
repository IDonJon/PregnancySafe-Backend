using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Models
{
    public class MedicalExam
    {
        public int Id { get; set; }
        public string ExamType { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int MotherId { get; set; }
        public Mother Mother { get; set; }
        public int ObstetricianId { get; set; }
        public Obstetrician Obstetrician { get; set; }
    }
}
