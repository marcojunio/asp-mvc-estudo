using Atividade.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Models.Buffet
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Descrition { get; set; }
        public Client Client { get; set; }
        public Local Local { get; set; }
        public string Observation { get; set; }
        public DateTime DayStart { get; set; }
        public TypeEvent TypeEvent { get; set; }
        public SituationEvent SituationEvent{ get; set; }
        public virtual IEnumerable<Guest> Guests { get; set; }
    }
}
