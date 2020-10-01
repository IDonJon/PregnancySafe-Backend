using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PregnancySafe.Resources
{
    public class SaveVideoResource
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Url { get; set; }

        [Required]
        public DateTime PostDate { get; set; }
    }
}
