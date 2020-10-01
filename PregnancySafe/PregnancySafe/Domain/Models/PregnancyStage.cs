using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Models
{
    public class PregnancyStage
    {
        public int Id { get; set; }
        public string Range { get; set; }
        public string Description { get; set; }
        public IList<Mother> Mothers { get; set; } = new List<Mother>();
    }
}
