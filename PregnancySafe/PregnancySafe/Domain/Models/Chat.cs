using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public IList<Message> Messages { get; set; } = new List<Message>();
        public int MotherId { get; set; }
        public Mother Mother { get; set; }
        public int ObstetricianId { get; set; }
        public virtual Obstetrician Obstetrician { get; set; }
    }
}