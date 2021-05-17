using Atividade.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Models.Buffet
{
    public class Guest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public Event Event { get; set; }
        public GuestSituation GuestSituation { get; set; }
    }
}
