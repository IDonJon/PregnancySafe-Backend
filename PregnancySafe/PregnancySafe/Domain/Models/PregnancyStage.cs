using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Models
{
    public class PregnancyStage
    {
        public int Id { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public virtual IList<Mother> Mothers { get; set; } = new List<Mother>();
    }
}
