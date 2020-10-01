using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Resources
{
    public class MessageResource
    {
        public int Id { get; set; }
        public ChatResource Chat { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
