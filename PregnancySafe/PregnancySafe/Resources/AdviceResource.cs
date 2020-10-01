using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Resources
{
    public class AdviceResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public ObstetricianResource Obstetrician { get; set; }

    }
}

