using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public int ObstetricianId { get; set; }
        public Obstetrician Obstetrician { get; set; }
    }
}

