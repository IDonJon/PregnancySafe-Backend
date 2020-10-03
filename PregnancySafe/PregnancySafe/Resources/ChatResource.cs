using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Resources
{
    public class ChatResource
    {
        public int Id { get; set; }
        public MotherResource Mother { get; set; }
        public ObstetricianResource Obstetrician { get; set; }
    }
}
