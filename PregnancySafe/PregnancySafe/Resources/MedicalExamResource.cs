using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Resources
{
    public class MedicalExamResource
    {
        public int Id { get; set; }
        public string ExamType { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public MotherResource Mother { get; set; }
        public ObstetricianResource Obstetrician { get; set; }

    }
}