using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Resources
{
    public class SaveMessageResource
    {
        [Required]
        public int SenderId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
