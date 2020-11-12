using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Resources
{
    public class SavePregnancyStageResource
    {
        [Required]
        public string Extension { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
